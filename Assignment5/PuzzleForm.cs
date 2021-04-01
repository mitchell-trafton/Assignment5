using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment5
{

    public partial class PuzzleForm : Form
    {
        static int NUMBERBOX_WIDTH = 22; //width of a single textbox for number input
        static int NUMBERBOX_HEIGHT = 30; //width of a single textbox for number input

        private Form parentForm = null;//refrence to the calling form, used to close the calling form when this form is closed

        List<TextBox> numberBoxes = new List<TextBox>();//stores the various textboxes to be drawn to the form

        public PuzzleForm(Form callingForm = null)
        {
            parentForm = callingForm;
            InitializeComponent();

            ////build the puzzle

            //adjust size of numberBoxHolder
            numberBoxHolder.Width = (NUMBERBOX_WIDTH + 9) * (Globals.selectedPuzzle.Columns+1);
            numberBoxHolder.Height = (NUMBERBOX_HEIGHT + 9) * (Globals.selectedPuzzle.Rows+1);

            //populate numberBoxes list with textboxes
            for (int i = 1; i <= Globals.selectedPuzzle.Columns * Globals.selectedPuzzle.Rows; i++)
            {
                numberBoxes.Add(new TextBox());
                numberBoxes[numberBoxes.Count - 1].Font = new Font(numberBoxes[numberBoxes.Count - 1].Font.FontFamily, 15);
                numberBoxes[numberBoxes.Count - 1].Width = NUMBERBOX_WIDTH;
                numberBoxes[numberBoxes.Count - 1].Height = NUMBERBOX_HEIGHT;
                numberBoxes[numberBoxes.Count - 1].MaxLength = 1;


                numberBoxes[numberBoxes.Count - 1].Name = i.ToString();

                if (Globals.selectedPuzzle.ValidInput[(int)((numberBoxes.Count - 1) / Globals.selectedPuzzle.Columns), (numberBoxes.Count - 1) % Globals.selectedPuzzle.Columns])
                {
                    numberBoxes[numberBoxes.Count - 1].Enabled = false;
                    numberBoxes[numberBoxes.Count - 1].Text =
                        Globals.selectedPuzzle.Solution[(int)((numberBoxes.Count - 1) / Globals.selectedPuzzle.Columns), (numberBoxes.Count - 1) % Globals.selectedPuzzle.Columns].ToString();
                }
                    

                numberBoxes[numberBoxes.Count - 1].TextChanged += (sender, e) =>//TextChanged event
                {
                    TextBox sender_ = (TextBox)sender;

                    if (sender_.Text == "") return;
                    //make sure that the entered text is numeric between 1 and 9, erase text if otherwise
                    if (!(Char.IsNumber(sender_.Text[0]) && sender_.Text[0] != '0'))
                        sender_.Clear();
                    //if input was numeric, send focus to next availible textbox if there is one
                    else if (sender_.Name != numberBoxes.Count.ToString())
                    {
                        int nextIndex = Int32.Parse(sender_.Name);
                        while (nextIndex >= numberBoxes.Count || numberBoxes[nextIndex].Enabled == false)
                        {
                            if (nextIndex >= numberBoxes.Count) return;

                            nextIndex++;
                        }

                        numberBoxes[nextIndex].Focus();
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


            ///line up sums pannel and populate it
            sums_pnl.Location = new Point(sums_pnl.Location.X, numberBoxHolder.Height + 30);

            //populate row totals
            for (int r = 0; r < Globals.selectedPuzzle.Rows; r++)
            {
                int total = 0;

                for (int c = 0; c < Globals.selectedPuzzle.Columns; c++)
                    total += Globals.selectedPuzzle.Solution[r, c];

                rowsSums_lbl.Text += "R" + (r + 1).ToString() + " = " + total.ToString() + "\n";
            }
            //populate column totals
            for (int c = 0; c < Globals.selectedPuzzle.Columns; c++)
            {
                int total = 0;

                for (int r = 0; r < Globals.selectedPuzzle.Rows; r++)
                    total += Globals.selectedPuzzle.Solution[r, c];

                columnsSums_lbl.Text += "C" + (c + 1).ToString() + " = " + total.ToString() + "\n";
            }
            //populate diagonal totals
            for (int r = Globals.selectedPuzzle.Rows - 2; r >= 0; r--)
            {
                int total = 0;
                int c = 0;
                int final_r = 0;

                for (int rr = r; rr < Globals.selectedPuzzle.Rows; rr++)
                {
                    total += Globals.selectedPuzzle.Solution[rr, c];
                    c++;
                    final_r = rr + 1;
                }

                diagonalsSums_lbl.Text += "(C1,R" + (r + 1).ToString() + ") -> (C" + c.ToString() + ",R" + final_r.ToString() + ") = " + total.ToString() + "\n";
            }
            for (int c = 1; c < Globals.selectedPuzzle.Columns - 1; c++)
            {
                int total = 0;
                int r = 0;
                int final_c = 0;

                for (int cc = c; cc < Globals.selectedPuzzle.Columns; cc++)
                {
                    total += Globals.selectedPuzzle.Solution[r, cc];
                    r++;
                    final_c = cc + 1;
                }

                diagonalsSums_lbl.Text += "(C" + (c + 1).ToString() + ",R1) -> (C" + final_c.ToString() + ",R" + r.ToString() + ") = " + total.ToString() + "\n";
            }
        }

        private void PuzzleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parentForm != null) parentForm.Close();
        }

        
    }
}
