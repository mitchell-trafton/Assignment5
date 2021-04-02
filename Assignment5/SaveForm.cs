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
    public partial class SaveForm : Form
    {
        public SaveForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Globals.save_puzzle(savename_txt.Text))
                MessageBox.Show("A save already exists with this name. Please enter a different name.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            else Close();
        }
    }
}
