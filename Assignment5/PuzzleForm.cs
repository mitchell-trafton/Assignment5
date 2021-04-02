using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/************************************************************
 * Assignment 5
 * Programmers: Robert Tyler Trotter z1802019
 *              Mitchell Trafton     z1831076
 ***********************************************************/

namespace Assignment5
{

    public partial class PuzzleForm : Form
    {
        static int NUMBERBOX_WIDTH = 22; //width of a single textbox for number input
        static int NUMBERBOX_HEIGHT = 30; //width of a single textbox for number input

        private Form parentForm = null;//refrence to the calling form, used to close the calling form when this form is closed

        List<TextBox> numberBoxes = new List<TextBox>();//stores the various textboxes to be drawn to the form

        List<Tuple<List<int>, int>> rowGroups = new List<Tuple<List<int>, int>>();//stores the indexes of the number boxes in each row along with their totals
        List<Tuple<List<int>, int>> columnGroups = new List<Tuple<List<int>, int>>();//stores the indexes of the number boxes in each column along with their totals
        List<Tuple<List<int>, Tuple<string, int>>> diagGroups = new List<Tuple<List<int>, Tuple<string, int>>>();//stores the indexes of the number boxes in each down-right (excluding one-long) diagonal row along with their totals

        List<Label> rowTotals = new List<Label>();//labels storing totals for each row
        List<Label> columnTotals = new List<Label>();//labels storing totals for each column
        List<Label> diagTotals = new List<Label>();//labels storing totals for each down-right row

        Clock timer = new Clock();//timer for game
        bool paused = false; //true when the timer is paused

        public PuzzleForm(Form callingForm = null)
        {
            /****************************************
             * Params:
             * 
             * @callingForm = The form that called this form. Used to close parent form when this form is closed.
             ****************************************/

            parentForm = callingForm;
            InitializeComponent();

            ///add puzzle to list of played puzzles
            using (StreamWriter playedFile = File.AppendText(@"./a5/played.txt"))
                playedFile.WriteLine(Globals.savePath.Split('5')[1].Remove(0,1));


            ////build the puzzle

            //adjust size of numberBoxHolder
            numberBoxHolder.Width = (NUMBERBOX_WIDTH + 9) * (Globals.selectedPuzzle.Columns+1);
            numberBoxHolder.Height = (NUMBERBOX_HEIGHT + 9) * (Globals.selectedPuzzle.Rows+1);

            //populate numberBoxes list with textboxes
            for (int i = 1; i <= Globals.selectedPuzzle.Columns * Globals.selectedPuzzle.Rows; i++)
            {
                //set parameters for new textboxes
                numberBoxes.Add(new TextBox());
                numberBoxes[numberBoxes.Count - 1].Font = new Font(numberBoxes[numberBoxes.Count - 1].Font.FontFamily, 15);
                numberBoxes[numberBoxes.Count - 1].Width = NUMBERBOX_WIDTH;
                numberBoxes[numberBoxes.Count - 1].Height = NUMBERBOX_HEIGHT;
                numberBoxes[numberBoxes.Count - 1].MaxLength = 1;//each textbox can only have one character


                numberBoxes[numberBoxes.Count - 1].Name = i.ToString();//set name of text box to it's index + 1

                //populate each text box with numbers from the Global Sudoku() object's indexer
                if (Globals.selectedPuzzle[(int)((numberBoxes.Count - 1) / Globals.selectedPuzzle.Columns), (numberBoxes.Count - 1) % Globals.selectedPuzzle.Columns] != 0)
                {
                    numberBoxes[numberBoxes.Count - 1].Text =
                        Globals.selectedPuzzle.Solution[(int)((numberBoxes.Count - 1) / Globals.selectedPuzzle.Columns), (numberBoxes.Count - 1) % Globals.selectedPuzzle.Columns].ToString();
                }
                else//if a number is 0, leave text box blank
                    numberBoxes[numberBoxes.Count - 1].Text = "";

                //make textboxes uneditable where the corresponding ValidInput values for the global Sudoku() object = false
                if (!Globals.selectedPuzzle.ValidInput[(int)((numberBoxes.Count - 1) / Globals.selectedPuzzle.Columns), (numberBoxes.Count - 1) % Globals.selectedPuzzle.Columns])
                {
                    numberBoxes[numberBoxes.Count - 1].Enabled = false;
                }


                numberBoxes[numberBoxes.Count - 1].TextChanged += (sender, e) =>//TextChanged event
                {
                    TextBox sender_ = (TextBox)sender;

                    if (sender_.Text == "") return;
                    //make sure that the entered text is numeric between 1 and 9, erase text if otherwise
                    if (!(Char.IsNumber(sender_.Text[0]) && sender_.Text[0] != '0'))
                        sender_.Clear();
                    //if input was numeric, update totals and send focus to next availible textbox if there is one
                    else
                    {
                        UpdateRowTotal(Int32.Parse(sender_.Name) - 1);
                        UpdateColumnTotal(Int32.Parse(sender_.Name) - 1);
                        UpdateDiagTotal(Int32.Parse(sender_.Name) - 1);

                        //check if user has entered all the numbers correctly (win condition)
                        CheckIfWon();

                        if (sender_.Name != numberBoxes.Count.ToString())
                        {
                            int nextIndex = Int32.Parse(sender_.Name);
                            while (nextIndex >= numberBoxes.Count || numberBoxes[nextIndex].Enabled == false)
                            {
                                if (nextIndex >= numberBoxes.Count) return;

                                nextIndex++;
                            }

                            numberBoxes[nextIndex].Focus();
                        }
                    }
                };
            }

            //add numberbox textboxes, as well as row and column indicators to numberBoxHolder
            int rowNum = 1; //current row being built
            foreach (TextBox t in numberBoxes)
            {
                numberBoxHolder.Controls.Add(t);

                if (Int32.Parse(t.Name) % Globals.selectedPuzzle.Columns == 0)
                {
                    Label r = new Label();
                    r.Text = "R" + rowNum.ToString();
                    r.Width = NUMBERBOX_WIDTH+10;
                    r.Height = NUMBERBOX_HEIGHT;
                    r.Font = new Font(r.Font.FontFamily, 8);
                    r.Padding = new Padding(5,10,5,5);
                    numberBoxHolder.Controls.Add(r);

                    rowNum++;
                }
            }
            for (int i = 1; i <= Globals.selectedPuzzle.Columns; i++)
            {
                Label c = new Label();
                c.Text = "C" + i.ToString();
                c.Width = NUMBERBOX_WIDTH;
                c.Height = NUMBERBOX_HEIGHT+15;
                c.Font = new Font(c.Font.FontFamily, 8);
                c.Padding = new Padding(5, 10, 5, 5);
                numberBoxHolder.Controls.Add(c);
            }


            ///line up expected sums panel and populate it
            ///also, populate the row/column/diagonal groups
            sums_pnl.Location = new Point(sums_pnl.Location.X, numberBoxHolder.Height + 30);

            //populate row totals
            for (int r = 0; r < Globals.selectedPuzzle.Rows; r++)
            {
                int total = 0;

                List<int> rowGroup = new List<int>();

                for (int c = 0; c < Globals.selectedPuzzle.Columns; c++)
                {
                    total += Globals.selectedPuzzle.Solution[r, c];

                    rowGroup.Add((r * Globals.selectedPuzzle.Columns) + c);
                }

                rowsSums_lbl.Text += "R" + (r + 1).ToString() + " = " + total.ToString() + "\n";

                rowGroups.Add(new Tuple<List<int>, int>(rowGroup, total));
            }
            //populate column totals
            for (int c = 0; c < Globals.selectedPuzzle.Columns; c++)
            {
                int total = 0;

                List<int> columnGroup = new List<int>();

                for (int r = 0; r < Globals.selectedPuzzle.Rows; r++)
                {
                    total += Globals.selectedPuzzle.Solution[r, c];

                    columnGroup.Add((r * Globals.selectedPuzzle.Columns) + c);
                }
                    
                columnsSums_lbl.Text += "C" + (c + 1).ToString() + " = " + total.ToString() + "\n";

                columnGroups.Add(new Tuple<List<int>, int>(columnGroup, total));
            }
            //populate diagonal totals (down-right)
            //diagonals that only have one text box will not be counted
            for (int r = Globals.selectedPuzzle.Rows - 2; r >= 0; r--)//diagonals starting on left-most column
            {
                int total = 0;
                int c = 0;
                int final_r = 0;

                List<int> diagGroup = new List<int>();

                for (int rr = r; rr < Globals.selectedPuzzle.Rows; rr++)
                {
                    total += Globals.selectedPuzzle.Solution[rr, c];
                    final_r = rr + 1;

                    diagGroup.Add((rr * Globals.selectedPuzzle.Columns) + c);
                    c++;
                }

                diagonalsSums_lbl.Text += "(C1,R" + (r + 1).ToString() + ") -> (C" + c.ToString() + ",R" + final_r.ToString() + ") = " + total.ToString() + "\n";

                Tuple<string, int> infoTuple = new Tuple<string, int>("(C1,R" + (r + 1).ToString() + ") -> (C" + c.ToString() + ",R" + final_r.ToString() + ") = ", total);
                diagGroups.Add(new Tuple<List<int>, Tuple<string, int>>(diagGroup, infoTuple));
            }
            for (int c = 1; c < Globals.selectedPuzzle.Columns - 1; c++)//diagonals starting on top row (excluding first one)
            {
                int total = 0;
                int r = 0;
                int final_c = 0;

                List<int> diagGroup = new List<int>();

                for (int cc = c; cc < Globals.selectedPuzzle.Columns; cc++)
                {
                    total += Globals.selectedPuzzle.Solution[r, cc];
                    final_c = cc + 1;

                    diagGroup.Add((r * Globals.selectedPuzzle.Columns) + cc);
                    r++;
                }

                diagonalsSums_lbl.Text += "(C" + (c + 1).ToString() + ",R1) -> (C" + final_c.ToString() + ",R" + r.ToString() + ") = " + total.ToString() + "\n";

                Tuple<string, int> infoTuple = new Tuple<string, int>("(C" + (c + 1).ToString() + ",R1) -> (C" + final_c.ToString() + ",R" + r.ToString() + ") = ", total);
                diagGroups.Add(new Tuple<List<int>, Tuple<string, int>>(diagGroup, infoTuple));
            }

            ///build the actual_sums panel
            actualSums_pnl.Location = new Point(actualSums_pnl.Location.X, numberBoxHolder.Height + 30);

            int currentY = 59; //current y coordinate of labels being added
            int currentX = 9; //current x coordinate of labels being added
            //build row sums
            foreach (Tuple<List<int>, int> r in rowGroups)
            {
                rowTotals.Add(new Label());
                rowTotals[rowTotals.Count - 1].Location = new Point(currentX, currentY);
                rowTotals[rowTotals.Count - 1].Name = "R" + rowTotals.Count.ToString();
                rowTotals[rowTotals.Count - 1].AutoSize = true;

                actualSums_pnl.Controls.Add(rowTotals[rowTotals.Count - 1]);

                currentY += 20;

                UpdateRowTotal(r.Item1[0]);
            }
            //build column sums
            currentY = 60;
            currentX = 78;
            foreach (Tuple<List<int>, int> c in columnGroups)
            {
                columnTotals.Add(new Label());
                columnTotals[columnTotals.Count - 1].Location = new Point(currentX, currentY);
                columnTotals[columnTotals.Count - 1].Name = "C" + columnTotals.Count.ToString();
                columnTotals[columnTotals.Count - 1].AutoSize = true;

                actualSums_pnl.Controls.Add(columnTotals[columnTotals.Count - 1]);

                currentY += 20;

                UpdateColumnTotal(c.Item1[0]);
            }
            //build diagonal sums
            currentY = 60;
            currentX = 174;
            foreach (Tuple<List<int>, Tuple<string, int>> d in diagGroups)
            {
                diagTotals.Add(new Label());
                diagTotals[diagTotals.Count - 1].Location = new Point(currentX, currentY);
                diagTotals[diagTotals.Count - 1].Name = "D" + diagTotals.Count.ToString();
                diagTotals[diagTotals.Count - 1].AutoSize = true;

                actualSums_pnl.Controls.Add(diagTotals[diagTotals.Count - 1]);

                currentY += 20;

                UpdateDiagTotal(d.Item1[0]);
            }

            ///align options_pnl
            options_pnl.Location = new Point(numberBoxHolder.Size.Width + 30, options_pnl.Location.Y);


            ///start timer
            timer.Time = Globals.selectedPuzzle.Time;
            timer.Start();
        }

        private void UpdateRowTotal(int idx)
        {
            /************************************************************
             * Updates the actual total for the row that the specified
             * index belongs to. 
             * 
             * Reflects that total in the appropriate label in actualSums_pnl.
             * 
             * 
             * Parameters:
             * 
             * @idx = Index of textbox (in numberBoxes) who's corresponding row total needs
             *        to be updated.
             ************************************************************/

            int groupIdx = 0;//index of rowGroups that idx belongs to

            foreach (Tuple<List<int>, int> r in rowGroups)
            {
                if (r.Item1.Contains(idx))
                {
                    int total = 0;//calculated (user-entered) total for row
                    int expectedTotal = 0;//expected total for row

                    for (int i = 0; i < Globals.selectedPuzzle.Columns; i++)//calculate expected total using solution in global Sudoku() object
                    {
                        expectedTotal += Globals.selectedPuzzle.Solution[groupIdx, i];
                    }

                    foreach(int i in r.Item1)//calculate actual total for row
                    {
                        if (numberBoxes[i].Text != "") total += Int32.Parse(numberBoxes[i].Text);//only calculate for textboxes that have text
                    }

                    rowTotals[groupIdx].Text = "R" + (groupIdx + 1).ToString() + " = " + total;

                    //change color of corresponding totals label depending on how the calculated total relates to the expected total
                    if (total < expectedTotal) rowTotals[groupIdx].ForeColor = Color.Black;//total < expected
                    else if (total == expectedTotal) rowTotals[groupIdx].ForeColor = Color.Green;//total = expected
                    else rowTotals[groupIdx].ForeColor = Color.Red;//total > expected

                    return;
                }
                groupIdx++;
            }
        }

        private void UpdateColumnTotal(int idx)
        {
            /************************************************************
             * Updates the actual total for the column that the specified
             * index belongs to. 
             * 
             * Reflects that total in the appropriate label in actualSums_pnl.
             * 
             * 
             * Parameters:
             * 
             * @idx = Index of textbox (in numberBoxes) who's corresponding column total needs
             *        to be updated.
             ************************************************************/

            int groupIdx = 0;//index of columnGroups that idx belongs to

            foreach (Tuple<List<int>, int> c in columnGroups)
            {
                if (c.Item1.Contains(idx))
                {
                    int total = 0;//calculated (user-entered) total
                    int expectedTotal = 0;//expected total for column

                    for (int i = 0; i < Globals.selectedPuzzle.Rows; i++)//calculate expected total using solution in global Sudoku() object
                    {
                        expectedTotal += Globals.selectedPuzzle.Solution[i, groupIdx];
                    }

                    foreach (int i in c.Item1)//calculate actual total for column
                    {
                        if (numberBoxes[i].Text != "") total += Int32.Parse(numberBoxes[i].Text);//only calculate for textboxes that have text
                    }

                    columnTotals[groupIdx].Text = "C" + (groupIdx + 1).ToString() + " = " + total;

                    //change color of corresponding totals label depending on how the calculated total relates to the expected total
                    if (total < expectedTotal) columnTotals[groupIdx].ForeColor = Color.Black;//calculated < expected
                    else if (total == expectedTotal) columnTotals[groupIdx].ForeColor = Color.Green;//calculated = expected
                    else columnTotals[groupIdx].ForeColor = Color.Red;//calcluated > expected

                    return;
                }
                groupIdx++;
            }
        }

        private void UpdateDiagTotal(int idx)
        {
            /************************************************************
             * Updates the actual total for the down-right diagonal row 
             * that the specified index belongs to. 
             * 
             * Reflects that total in the appropriate label in actualSums_pnl.
             * 
             * 
             * Parameters:
             * 
             * @idx = Index of textbox (in numberBoxes) who's corresponding diagonal total needs
             *        to be updated.
             ************************************************************/

            int groupIdx = 0;//index of diagGroups that idx belongs to

            foreach (Tuple<List<int>, Tuple<string, int>> d in diagGroups)
            {
                if (d.Item1.Contains(idx))
                {
                    int total = 0;//calculated (user-entered) total
                    int expectedTotal = 0;//expected total for diagonal row

                    foreach (int i in d.Item1)//calculate expected and calculated totals
                    {
                        if (numberBoxes[i].Text != "") total += Int32.Parse(numberBoxes[i].Text);//calculated total; only calculate for textboxes that have text
                        expectedTotal += Globals.selectedPuzzle.Solution[(int)(i / Globals.selectedPuzzle.Rows), (i % Globals.selectedPuzzle.Rows)];//expected total
                    }

                    diagTotals[groupIdx].Text = d.Item2.Item1 + total;


                    //change color of corresponding totals label depending on how the calculated total relates to the expected total
                    if (total < expectedTotal) diagTotals[groupIdx].ForeColor = Color.Black;//calcluated < expected
                    else if (total == expectedTotal) diagTotals[groupIdx].ForeColor = Color.Green;//calculated = expected
                    else diagTotals[groupIdx].ForeColor = Color.Red;//calculated > expected

                    return;
                }
                groupIdx++;
            }
        }

        private void PuzzleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //close parent form when this form is closed
            if (parentForm != null) parentForm.Close();
        }

        private void progress_btn_Click(object sender, EventArgs e)
        {
            /**************************************************************
             * onClick handler for progress_btn.
             * 
             * Checks each textbox in numberboxes and sees if it's correct
             * according to the puzzles solution. 
             * 
             * Highlights textboxes red that are incorrect and displays an appropriate 
             * message in progress_lbl.
             **************************************************************/

            bool allGood = true; //true if all filled in boxes are correct

            foreach (TextBox t in numberBoxes)
            {
                int idx = Int32.Parse(t.Name) - 1;

                if (t.Enabled && t.Text != "")
                    if (Int32.Parse(t.Text) != Globals.selectedPuzzle.Solution[(int)(idx / Globals.selectedPuzzle.Rows), (idx % Globals.selectedPuzzle.Rows)])
                    {
                        t.BackColor = Color.Salmon;
                        allGood = false;
                    }
                    else t.BackColor = Color.White;
                else t.BackColor = Color.White;
            }

            if (!allGood)
            {
                progress_lbl.Text = "I see some mistakes!";
                progress_lbl.ForeColor = Color.Red;
            }
            else
            {
                progress_lbl.Text = "All good so far!";
                progress_lbl.ForeColor = Color.Green;
            }
        }

        private void playPause_btn_Click(object sender, EventArgs e)
        {
            /********************************************************
             * onClick handler for playPause_btn.
             * 
             * Pauses/unpauses puzzle timer.
             * 
             * Makes puzzle elements disapear if timer is paused.
             * 
             * Updates text in playPause_button to reflact play/pause state.
             ********************************************************/

            if (!paused)
            {
                paused = true;

                foreach (Control c in numberBoxHolder.Controls)
                    c.Visible = false;

                timer.Pause();

                playPause_btn.Text = "Play ▶️";
            }
            else
            {
                paused = false;

                foreach (Control c in numberBoxHolder.Controls)
                    c.Visible = true;

                timer.Start();

                playPause_btn.Text = "Pause ⏸️";
            }
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            /**************************************************
             * onClick handler for reset_btn.
             * 
             * Resets the puzzle/timer.
             **************************************************/

            //display a warning message before puzzle is reset
            DialogResult confirmation = MessageBox.Show("Are you sure you want to reset? All your progress will be permanently deleted.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //only reset puzzle if user has agreed to warning message
            if (confirmation == DialogResult.Yes)
            {
                foreach (TextBox t in numberBoxes)
                {
                    if (t.Enabled) t.Text = "";
                    t.BackColor = Color.White;

                    UpdateRowTotal(Int32.Parse(t.Name) - 1);
                    UpdateColumnTotal(Int32.Parse(t.Name) - 1);
                    UpdateDiagTotal(Int32.Parse(t.Name) - 1);
                }

                timer.Stop();
                timer.Start();
            }
        }

        private void CheckIfWon()
        {
            /********************************************************************
             * Checks if user has successfully completed the puzzle.
             * 
             * If all textboxes in numberBoxes match the solution to the puzzle, 
             * pause timer, record time, and display the user's time along with the 
             * best and average time for the current puzzle's difficulty.
             ********************************************************************/

            bool won = true;//true if use has won the game

            foreach (TextBox t in numberBoxes)//check all textboxes against puzzle's solution
            {
                if (t.Text == "") return;//return function if any text box is blank (puzzle incomplete)

                int idx = Int32.Parse(t.Name) - 1;

                if (Int32.Parse(t.Text) != Globals.selectedPuzzle.Solution[(int)(idx / Globals.selectedPuzzle.Rows), (idx % Globals.selectedPuzzle.Rows)])
                    won = false;
            }
            
            if (won)
            {//user has successfully completed puzzle
                timer.Pause();

                foreach (TextBox t in numberBoxes)
                {   
                    t.Enabled = false;
                    t.BackColor = Color.Green;
                }

                int avgTime;//average time for puzzles in current difficulty (seconds)
                int bestTime;//best time in current difficulty (seconds)
                int currentTime; //current time (in seconds)

                TimeSpan avgTimeTS;//average time in timestamp form
                TimeSpan bestTimeTS;//best time in timestamp form

                string winMessage = "Congratulations! You completed the puzzle!\n\nYour time: ";

                //determine which high score file to open
                if (Globals.savePath.Split('/')[2] == "easy")//easy
                {
                    StreamReader hsFile = new StreamReader(@"./a5/high_scores_easy.txt");

                    //retrieve average and best times from high score file
                    bestTime = Int32.Parse(hsFile.ReadLine());
                    avgTime = Int32.Parse(hsFile.ReadLine());
                    //get current time in seconds
                    currentTime = (int)timer.Time.TotalSeconds;

                    if (avgTime == 0) avgTime = currentTime;//set average time to current time if no average time is on file yet

                    hsFile.Close();

                    bestTimeTS = TimeSpan.FromSeconds(bestTime);

                    if (timer.Time > bestTimeTS) bestTimeTS = timer.Time;//update best time if current time beats it


                    avgTime = (int)((avgTime + currentTime) / 2);//update average time

                    avgTimeTS = TimeSpan.FromSeconds(avgTime);//save new average time in timestampp form

                    winMessage += timer.getTime() + "\n";
                    winMessage += "Best time (easy): " + bestTimeTS.Hours.ToString() + ":" + bestTimeTS.Minutes.ToString() + ":" + bestTimeTS.Seconds.ToString() + "\n";
                    winMessage += "Average time (easy): " + avgTimeTS.Hours.ToString() + ":" + avgTimeTS.Minutes.ToString() + ":" + avgTimeTS.Seconds.ToString();

                    
                    //write updated time statistics to high score file
                    using (File.Create(@"./a5/hs_tmp.txt")) { }//create temporary file for rewriting save file

                    bestTime = (int)bestTimeTS.TotalSeconds;

                    StreamWriter sw = new StreamWriter(@"./a5/hs_tmp.txt");
                    sw.WriteLine(bestTime);
                    sw.WriteLine(avgTime);
                    sw.Close();

                    File.Copy(@"./a5/hs_tmp.txt", "./a5/high_scores_easy.txt", true);//copy temporary hs file to perminant high score file
                    File.Delete(@"./a5/hs_tmp.txt");//delete temporary file
                }
                else if (Globals.savePath.Split('/')[2] == "medium")//medium
                {
                    StreamReader hsFile = new StreamReader(@"./a5/high_scores_medium.txt");

                    //retrieve average and best times from high score file
                    bestTime = Int32.Parse(hsFile.ReadLine());
                    avgTime = Int32.Parse(hsFile.ReadLine());
                    //get current time in seconds
                    currentTime = (int)timer.Time.TotalSeconds;

                    if (avgTime == 0) avgTime = currentTime;//set average time to current time if no average time is on file yet

                    hsFile.Close();

                    bestTimeTS = TimeSpan.FromSeconds(bestTime);

                    if (timer.Time > bestTimeTS) bestTimeTS = timer.Time;//update best time if current time beats it


                    avgTime = (int)((avgTime + currentTime) / 2);//update average time

                    avgTimeTS = TimeSpan.FromSeconds(avgTime);//save new average time in timestampp form

                    winMessage += timer.getTime() + "\n";
                    winMessage += "Best time (medium): " + bestTimeTS.Hours.ToString() + ":" + bestTimeTS.Minutes.ToString() + ":" + bestTimeTS.Seconds.ToString() + "\n";
                    winMessage += "Average time (medium): " + avgTimeTS.Hours.ToString() + ":" + avgTimeTS.Minutes.ToString() + ":" + avgTimeTS.Seconds.ToString();


                    //write updated time statistics to high score file
                    using (File.Create(@"./a5/hs_tmp.txt")) { }//create temporary file for rewriting save file

                    bestTime = (int)bestTimeTS.TotalSeconds;

                    StreamWriter sw = new StreamWriter(@"./a5/hs_tmp.txt");
                    sw.WriteLine(bestTime);
                    sw.WriteLine(avgTime);
                    sw.Close();

                    File.Copy(@"./a5/hs_tmp.txt", "./a5/high_scores_medium.txt", true);//copy temporary hs file to perminant high score file
                    File.Delete(@"./a5/hs_tmp.txt");//delete temporary file
                }
                else if (Globals.savePath.Split('/')[2] == "hard")//hard
                {
                    StreamReader hsFile = new StreamReader(@"./a5/high_scores_hard.txt");

                    //retrieve average and best times from high score file
                    bestTime = Int32.Parse(hsFile.ReadLine());
                    avgTime = Int32.Parse(hsFile.ReadLine());
                    //get current time in seconds
                    currentTime = (int)timer.Time.TotalSeconds;

                    if (avgTime == 0) avgTime = currentTime;//set average time to current time if no average time is on file yet

                    hsFile.Close();

                    bestTimeTS = TimeSpan.FromSeconds(bestTime);

                    if (timer.Time > bestTimeTS) bestTimeTS = timer.Time;//update best time if current time beats it


                    avgTime = (int)((avgTime + currentTime) / 2);//update average time

                    avgTimeTS = TimeSpan.FromSeconds(avgTime);//save new average time in timestampp form

                    winMessage += timer.getTime() + "\n";
                    winMessage += "Best time (hard): " + bestTimeTS.Hours.ToString() + ":" + bestTimeTS.Minutes.ToString() + ":" + bestTimeTS.Seconds.ToString() + "\n";
                    winMessage += "Average time (hard): " + avgTimeTS.Hours.ToString() + ":" + avgTimeTS.Minutes.ToString() + ":" + avgTimeTS.Seconds.ToString();


                    //write updated time statistics to high score file
                    using (File.Create(@"./a5/hs_tmp.txt")) { }//create temporary file for rewriting save file

                    bestTime = (int)bestTimeTS.TotalSeconds;

                    StreamWriter sw = new StreamWriter(@"./a5/hs_tmp.txt");
                    sw.WriteLine(bestTime);
                    sw.WriteLine(avgTime);
                    sw.Close();

                    File.Copy(@"./a5/hs_tmp.txt", "./a5/high_scores_hard.txt", true);//copy temporary hs file to perminant high score file
                    File.Delete(@"./a5/hs_tmp.txt");//delete temporary file
                }


                MessageBox.Show(winMessage, "Congratulations!");
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            /**************************************************************
             * onClick handler for save_btn.
             * 
             * Pauses timer and saves current time to global Sudoku() object.
             * 
             * Saves current puzzle state to global Sudoku() object.
             * 
             * Calls SaveForm as a popup to prompt user on where to save their progress.
             **************************************************************/

            timer.Pause();
            Globals.selectedPuzzle.Time = timer.Time;
            
            foreach (TextBox t in numberBoxes)//save current puzzle satate
            {
                int idx = Int32.Parse(t.Name) - 1;

                if (t.Text != "") Globals.selectedPuzzle[(int)(idx / Globals.selectedPuzzle.Rows), (idx % Globals.selectedPuzzle.Rows)] = Int32.Parse(t.Text);
                else Globals.selectedPuzzle[(int)(idx / Globals.selectedPuzzle.Rows), (idx % Globals.selectedPuzzle.Rows)] = 0;
            }

            SaveForm sf = new SaveForm();
            sf.ShowDialog();
        }
    }
}
