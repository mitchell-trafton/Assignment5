using System;
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
    public partial class menu_form : Form
    {
        static Point RESUME_PNL_LOC = new Point(68, 58); //the position that resume_pnl should move to when it's needed
        static Point RANDOM_PNL_LOC = new Point(79, 66); //the position that random_pnl should move to when it's needed
        static Point SPECIFIC_PNL_LOC = new Point(32, 58); //the position that specific_pnl should move to when it's needed

        List<string> puzzleSelections = new List<string>();//stores paths to puzzles that are currently availible to select

        public menu_form()
        {
            InitializeComponent();
        }

        private void menu_form_Load(object sender, EventArgs e)
        {
            //set size of window to only fit visible contents
            this.Size = new Size(440, 278);
        }

        private void random_btn_Click(object sender, EventArgs e)
        {
            /************************************************
             * onclick handler for random_btn
             * 
             * Makes random_pnl appear on screen and puzzle_selection_pnl disapear.
             ************************************************/
            puzzle_selection_pnl.Visible = false;
            random_pnl.Location = RANDOM_PNL_LOC;
            random_pnl.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /************************************************
             * onclick handler for button1 (specific puzzle)
             * 
             * Makes specific_pnl appear on screen and puzzle_selection_pnl disapear.
             ************************************************/
            puzzle_selection_pnl.Visible = false;
            specific_pnl.Location = SPECIFIC_PNL_LOC;
            specific_pnl.Visible = true;
        }

        private void resume_btn_Click(object sender, EventArgs e)
        {
            /************************************************
             * onclick handler for resume_btn
             * 
             * Makes resume_pnl appear on screen and puzzle_selection_pnl disapear.
             ************************************************/
            if (Globals.get_saved_puzzles().Count == 0)
            {
                //if there are no saved files, disalay an error message and do nothing
                MessageBox.Show("There are no availible saves.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            puzzle_selection_pnl.Visible = false;
            resume_pnl.Location = RESUME_PNL_LOC;
            resume_pnl.Visible = true;

            //populate resumeSelect_lbx
            foreach (string save in Globals.get_saved_puzzles())
            {
                puzzleSelections.Add("./Saves/" + save);

                resumeSelect_lbx.Items.Add(save.Split(' ')[0].Split('.')[0]);
            }
        }

        private void randomDifficulty_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //enables the play button for random_pnl when a difficulty has been selected for a random game
            playRandom_btn.Enabled = true;
        }

        private void puzzleSelect_lbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            /****************************************************************
             * index change handler for puzzleSelect_lbx.
             * 
             * Enables the play button for specific_pnl.
             * 
             * Saves the path of the selected puzzle to the appropriate global variables.
             ****************************************************************/
            playSpecific_btn.Enabled = true;

            Globals.selectedPuzzleLoc = puzzleSelections[puzzleSelect_lbx.SelectedIndex].Split(' ')[0];
            Globals.savePath = puzzleSelections[puzzleSelect_lbx.SelectedIndex].Split(' ')[1];
        }

        private void resumeSelect_lbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            /****************************************************************
             * index change handler for resumeSelect_lbx.
             * 
             * Enables the play button for specific_pnl.
             * 
             * Saves the path of the selected puzzle to the appropriate global variables.
             ****************************************************************/
            playResume_btn.Enabled = true;

            Globals.selectedPuzzleLoc = puzzleSelections[resumeSelect_lbx.SelectedIndex].Split(' ')[0];
            Globals.savePath = puzzleSelections[resumeSelect_lbx.SelectedIndex].Split(' ')[1]; ;
        }

        private void specificDifficulty_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            /****************************************************************
             * index change handler for specificDifficulty_cbx.
             * 
             * Updates the availible puzzles puzzleSelect_lbx according to the selected difficulty.
             * 
             * Updates puzzleSelections with availible puzzles to choose from.
             ****************************************************************/
            puzzleSelect_lbx.Items.Clear();
            puzzleSelections.Clear();
            
            foreach (string puzzle in Globals.get_availible_puzzles(specificDifficulty_cbx.SelectedItem.ToString()))
            {
                puzzleSelections.Add("./a5/" + puzzle + " ./a5/" + puzzle);

                puzzleSelect_lbx.Items.Add(puzzle.Split(' ')[0].Split('/')[1].Split('.')[0]);
            }
        }

        private void playRandom_btn_Click(object sender, EventArgs e)
        {
            /****************************************************************
             * onClick handler for playRandom_btn.
             * 
             * Selects a random puzzle from the list of availible puzzles in specified
             * difficulty, filtering for unplayed puzzles if desired (see newPuzzle_ckbx). 
             * 
             * Sets desired puzzle file location to appropriate global variables.
             * 
             * Pulls up PuzzleForm using LaunchPuzzle();
             ****************************************************************/

            if (Globals.get_availible_puzzles(randomDifficulty_cbx.SelectedItem.ToString(), newPuzzle_ckbx.Checked).Count == 0)
            {
                //if there are no unplayed puzzles and the user wanted an unplayed puzzle, display an error message and do nothing
                MessageBox.Show("There are no unplayed puzzles matching your selected diffuculty.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            puzzleSelections.Clear();
            foreach (string puzzle in Globals.get_availible_puzzles(randomDifficulty_cbx.SelectedItem.ToString(), newPuzzle_ckbx.Checked))
                puzzleSelections.Add("./a5/" + puzzle + " ./a5/" + puzzle);

            Random rand = new Random(System.DateTime.Now.Millisecond);
            int r = rand.Next();

            Globals.selectedPuzzleLoc = puzzleSelections[r % puzzleSelections.Count].Split(' ')[0];
            Globals.savePath = puzzleSelections[r % puzzleSelections.Count].Split(' ')[1];

            LaunchPuzzle();
        }

        private void playSpecific_btn_Click(object sender, EventArgs e) { LaunchPuzzle(); }//Call LaunchPuzzle() if specific_pnl's play button is pressed
        private void playResume_btn_Click(object sender, EventArgs e) { LaunchPuzzle(); }//Call LaunchPuzzle() if resume_pnl's play button is pressed

        private void LaunchPuzzle()
        {
            /*****************************************************************
             * Sets Globals.selectedPuzzle to a new instance of Sudoku() using 
             * the current Globals.selectedPuzzleLoc value.
             * 
             * Pulls up a new instance of PuzzleForm and hides this form.
             *****************************************************************/

            Globals.selectedPuzzle = new Sudoku(Globals.selectedPuzzleLoc);

            PuzzleForm pz = new PuzzleForm(this);
            pz.Show();
            this.Hide();
        }
    }
}
