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
    public partial class SaveForm : Form
    {
        public SaveForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*********************************************************
             * onClick handler for button1 (save button).
             * 
             * Saves the current puzzle being worked to to a file with 
             * the name in savename_txt.
             * 
             * Exits the program if there is no problems with saving.
             *********************************************************/

            if (!Globals.save_puzzle(savename_txt.Text))
                MessageBox.Show("A save already exists with this name. Please enter a different name.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);//display an error message if there is already a save with the requested name
            
            else Environment.Exit(0);
        }
    }
}
