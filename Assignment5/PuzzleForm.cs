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
            numberBoxHolder.Width = (NUMBERBOX_WIDTH + 8) * Globals.selectedPuzzle.Columns;
            numberBoxHolder.Height = (NUMBERBOX_HEIGHT + 8) * Globals.selectedPuzzle.Rows;

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
                    numberBoxes[numberBoxes.Count - 1].Enabled = false;

                numberBoxes[numberBoxes.Count - 1].TextChanged += (sender, e) =>//TextChanged event
                {
                    TextBox sender_ = (TextBox)sender;

                    if (sender_.Text == "") return;
                    //make sure that the entered text is numeric between 1 and 9, erase text if otherwise
                    if (!(Char.IsNumber(sender_.Text[0]) && sender_.Text[0] != '0'))
                        sender_.Clear();
                    //if input was numeric, send focus to next textbox if there is one
                    else if (sender_.Name != numberBoxes.Count.ToString())
                    {
                        numberBoxes[Int32.Parse(sender_.Name)].Focus();
                    }
                };
            }

            //add numberbox textboxes to numberBoxHolder
            foreach (TextBox t in numberBoxes)
            {
                numberBoxHolder.Controls.Add(t);
            }

        }

        private void PuzzleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parentForm != null) parentForm.Close();
        }

        
    }
}
