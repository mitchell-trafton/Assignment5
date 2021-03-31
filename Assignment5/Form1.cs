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
            this.Size = new Size(440, 278);
        }

        private void random_btn_Click(object sender, EventArgs e)
        {
            puzzle_selection_pnl.Visible = false;
            random_pnl.Location = RANDOM_PNL_LOC;
            random_pnl.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            puzzle_selection_pnl.Visible = false;
            specific_pnl.Location = SPECIFIC_PNL_LOC;
            specific_pnl.Visible = true;
        }

        private void resume_btn_Click(object sender, EventArgs e)
        {
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

                resumeSelect_lbx.Items.Add(save.Split('.')[0]);
            }
        }

        private void randomDifficulty_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            playRandom_btn.Enabled = true;
        }

        private void puzzleSelect_lbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            playSpecific_btn.Enabled = true;

            Globals.selectedPuzzle = puzzleSelections[puzzleSelect_lbx.SelectedIndex];
        }

        private void resumeSelect_lbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            playResume_btn.Enabled = true;

            Globals.selectedPuzzle = puzzleSelections[resumeSelect_lbx.SelectedIndex];
        }

        private void specificDifficulty_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            puzzleSelect_lbx.Items.Clear();
            puzzleSelections.Clear();
            
            foreach (string puzzle in Globals.get_availible_puzzles(specificDifficulty_cbx.SelectedItem.ToString()))
            {
                puzzleSelections.Add("./a5/" + puzzle);

                puzzleSelect_lbx.Items.Add(puzzle.Split('/')[1].Split('.')[0]);
            }
        }

        private void playRandom_btn_Click(object sender, EventArgs e)
        {
            if (Globals.get_availible_puzzles(randomDifficulty_cbx.SelectedItem.ToString(), newPuzzle_ckbx.Checked).Count == 0)
            {
                //if there are no puzzles matching the user's parameters, display an error message and do nothing
                MessageBox.Show("There are no unplayed puzzles matching your selected diffuculty.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            puzzleSelections.Clear();
            foreach (string puzzle in Globals.get_availible_puzzles(randomDifficulty_cbx.SelectedItem.ToString(), newPuzzle_ckbx.Checked))
                puzzleSelections.Add("./a5/" + puzzle);

            Random rand = new Random(System.DateTime.Now.Millisecond);

            Globals.selectedPuzzle = puzzleSelections[rand.Next() % puzzleSelections.Count];
        }
    }
}
