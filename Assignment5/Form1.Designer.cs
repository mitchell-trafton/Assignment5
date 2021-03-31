
namespace Assignment5
{
    partial class menu_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.welcome_lbl = new System.Windows.Forms.Label();
            this.random_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.resume_btn = new System.Windows.Forms.Button();
            this.puzzle_selection_pnl = new System.Windows.Forms.Panel();
            this.random_pnl = new System.Windows.Forms.Panel();
            this.playRandom_btn = new System.Windows.Forms.Button();
            this.newPuzzle_ckbx = new System.Windows.Forms.CheckBox();
            this.randomDifficulty_lbl = new System.Windows.Forms.Label();
            this.randomDifficulty_cbx = new System.Windows.Forms.ComboBox();
            this.specific_pnl = new System.Windows.Forms.Panel();
            this.playSpecific_btn = new System.Windows.Forms.Button();
            this.specificDifficulty_lbl = new System.Windows.Forms.Label();
            this.specificDifficulty_cbx = new System.Windows.Forms.ComboBox();
            this.puzzleSelect_lbx = new System.Windows.Forms.ListBox();
            this.resume_pnl = new System.Windows.Forms.Panel();
            this.playResume_btn = new System.Windows.Forms.Button();
            this.resumeSelect_lbx = new System.Windows.Forms.ListBox();
            this.puzzle_selection_pnl.SuspendLayout();
            this.random_pnl.SuspendLayout();
            this.specific_pnl.SuspendLayout();
            this.resume_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // welcome_lbl
            // 
            this.welcome_lbl.AutoSize = true;
            this.welcome_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome_lbl.Location = new System.Drawing.Point(7, 9);
            this.welcome_lbl.Name = "welcome_lbl";
            this.welcome_lbl.Size = new System.Drawing.Size(410, 46);
            this.welcome_lbl.TabIndex = 0;
            this.welcome_lbl.Text = "Welcome to Sodoku!";
            // 
            // random_btn
            // 
            this.random_btn.Location = new System.Drawing.Point(24, 11);
            this.random_btn.Name = "random_btn";
            this.random_btn.Size = new System.Drawing.Size(155, 23);
            this.random_btn.TabIndex = 1;
            this.random_btn.Text = "Random Puzzle";
            this.random_btn.UseVisualStyleBackColor = true;
            this.random_btn.Click += new System.EventHandler(this.random_btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Specific Puzzle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // resume_btn
            // 
            this.resume_btn.Location = new System.Drawing.Point(24, 69);
            this.resume_btn.Name = "resume_btn";
            this.resume_btn.Size = new System.Drawing.Size(155, 23);
            this.resume_btn.TabIndex = 3;
            this.resume_btn.Text = "Resume Puzzle";
            this.resume_btn.UseVisualStyleBackColor = true;
            this.resume_btn.Click += new System.EventHandler(this.resume_btn_Click);
            // 
            // puzzle_selection_pnl
            // 
            this.puzzle_selection_pnl.Controls.Add(this.button1);
            this.puzzle_selection_pnl.Controls.Add(this.resume_btn);
            this.puzzle_selection_pnl.Controls.Add(this.random_btn);
            this.puzzle_selection_pnl.Location = new System.Drawing.Point(101, 79);
            this.puzzle_selection_pnl.Name = "puzzle_selection_pnl";
            this.puzzle_selection_pnl.Size = new System.Drawing.Size(200, 100);
            this.puzzle_selection_pnl.TabIndex = 4;
            // 
            // random_pnl
            // 
            this.random_pnl.Controls.Add(this.playRandom_btn);
            this.random_pnl.Controls.Add(this.newPuzzle_ckbx);
            this.random_pnl.Controls.Add(this.randomDifficulty_lbl);
            this.random_pnl.Controls.Add(this.randomDifficulty_cbx);
            this.random_pnl.Location = new System.Drawing.Point(79, 244);
            this.random_pnl.Name = "random_pnl";
            this.random_pnl.Size = new System.Drawing.Size(246, 158);
            this.random_pnl.TabIndex = 5;
            this.random_pnl.Visible = false;
            // 
            // playRandom_btn
            // 
            this.playRandom_btn.Enabled = false;
            this.playRandom_btn.Location = new System.Drawing.Point(80, 116);
            this.playRandom_btn.Name = "playRandom_btn";
            this.playRandom_btn.Size = new System.Drawing.Size(75, 23);
            this.playRandom_btn.TabIndex = 3;
            this.playRandom_btn.Text = "Play!";
            this.playRandom_btn.UseVisualStyleBackColor = true;
            this.playRandom_btn.Click += new System.EventHandler(this.playRandom_btn_Click);
            // 
            // newPuzzle_ckbx
            // 
            this.newPuzzle_ckbx.AutoSize = true;
            this.newPuzzle_ckbx.Location = new System.Drawing.Point(46, 79);
            this.newPuzzle_ckbx.Name = "newPuzzle_ckbx";
            this.newPuzzle_ckbx.Size = new System.Drawing.Size(142, 17);
            this.newPuzzle_ckbx.TabIndex = 2;
            this.newPuzzle_ckbx.Text = "Use an Unplayed Puzzle";
            this.newPuzzle_ckbx.UseVisualStyleBackColor = true;
            // 
            // randomDifficulty_lbl
            // 
            this.randomDifficulty_lbl.AutoSize = true;
            this.randomDifficulty_lbl.Location = new System.Drawing.Point(24, 38);
            this.randomDifficulty_lbl.Name = "randomDifficulty_lbl";
            this.randomDifficulty_lbl.Size = new System.Drawing.Size(50, 13);
            this.randomDifficulty_lbl.TabIndex = 1;
            this.randomDifficulty_lbl.Text = "Difficulty:";
            // 
            // randomDifficulty_cbx
            // 
            this.randomDifficulty_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.randomDifficulty_cbx.FormattingEnabled = true;
            this.randomDifficulty_cbx.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.randomDifficulty_cbx.Location = new System.Drawing.Point(80, 35);
            this.randomDifficulty_cbx.Name = "randomDifficulty_cbx";
            this.randomDifficulty_cbx.Size = new System.Drawing.Size(121, 21);
            this.randomDifficulty_cbx.TabIndex = 0;
            this.randomDifficulty_cbx.SelectedIndexChanged += new System.EventHandler(this.randomDifficulty_cbx_SelectedIndexChanged);
            // 
            // specific_pnl
            // 
            this.specific_pnl.Controls.Add(this.playSpecific_btn);
            this.specific_pnl.Controls.Add(this.specificDifficulty_lbl);
            this.specific_pnl.Controls.Add(this.specificDifficulty_cbx);
            this.specific_pnl.Controls.Add(this.puzzleSelect_lbx);
            this.specific_pnl.Location = new System.Drawing.Point(456, 34);
            this.specific_pnl.Name = "specific_pnl";
            this.specific_pnl.Size = new System.Drawing.Size(371, 190);
            this.specific_pnl.TabIndex = 6;
            this.specific_pnl.Visible = false;
            // 
            // playSpecific_btn
            // 
            this.playSpecific_btn.Enabled = false;
            this.playSpecific_btn.Location = new System.Drawing.Point(150, 140);
            this.playSpecific_btn.Name = "playSpecific_btn";
            this.playSpecific_btn.Size = new System.Drawing.Size(75, 23);
            this.playSpecific_btn.TabIndex = 4;
            this.playSpecific_btn.Text = "Play!";
            this.playSpecific_btn.UseVisualStyleBackColor = true;
            // 
            // specificDifficulty_lbl
            // 
            this.specificDifficulty_lbl.AutoSize = true;
            this.specificDifficulty_lbl.Location = new System.Drawing.Point(11, 54);
            this.specificDifficulty_lbl.Name = "specificDifficulty_lbl";
            this.specificDifficulty_lbl.Size = new System.Drawing.Size(50, 13);
            this.specificDifficulty_lbl.TabIndex = 3;
            this.specificDifficulty_lbl.Text = "Difficulty:";
            // 
            // specificDifficulty_cbx
            // 
            this.specificDifficulty_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specificDifficulty_cbx.FormattingEnabled = true;
            this.specificDifficulty_cbx.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.specificDifficulty_cbx.Location = new System.Drawing.Point(67, 51);
            this.specificDifficulty_cbx.Name = "specificDifficulty_cbx";
            this.specificDifficulty_cbx.Size = new System.Drawing.Size(121, 21);
            this.specificDifficulty_cbx.TabIndex = 2;
            this.specificDifficulty_cbx.SelectedIndexChanged += new System.EventHandler(this.specificDifficulty_cbx_SelectedIndexChanged);
            // 
            // puzzleSelect_lbx
            // 
            this.puzzleSelect_lbx.FormattingEnabled = true;
            this.puzzleSelect_lbx.Location = new System.Drawing.Point(220, 16);
            this.puzzleSelect_lbx.Name = "puzzleSelect_lbx";
            this.puzzleSelect_lbx.Size = new System.Drawing.Size(131, 95);
            this.puzzleSelect_lbx.TabIndex = 0;
            this.puzzleSelect_lbx.SelectedIndexChanged += new System.EventHandler(this.puzzleSelect_lbx_SelectedIndexChanged);
            // 
            // resume_pnl
            // 
            this.resume_pnl.Controls.Add(this.playResume_btn);
            this.resume_pnl.Controls.Add(this.resumeSelect_lbx);
            this.resume_pnl.Location = new System.Drawing.Point(435, 244);
            this.resume_pnl.Name = "resume_pnl";
            this.resume_pnl.Size = new System.Drawing.Size(246, 166);
            this.resume_pnl.TabIndex = 7;
            this.resume_pnl.Visible = false;
            // 
            // playResume_btn
            // 
            this.playResume_btn.Enabled = false;
            this.playResume_btn.Location = new System.Drawing.Point(61, 128);
            this.playResume_btn.Name = "playResume_btn";
            this.playResume_btn.Size = new System.Drawing.Size(75, 23);
            this.playResume_btn.TabIndex = 5;
            this.playResume_btn.Text = "Play!";
            this.playResume_btn.UseVisualStyleBackColor = true;
            // 
            // resumeSelect_lbx
            // 
            this.resumeSelect_lbx.FormattingEnabled = true;
            this.resumeSelect_lbx.Location = new System.Drawing.Point(18, 25);
            this.resumeSelect_lbx.Name = "resumeSelect_lbx";
            this.resumeSelect_lbx.Size = new System.Drawing.Size(170, 95);
            this.resumeSelect_lbx.TabIndex = 0;
            this.resumeSelect_lbx.SelectedIndexChanged += new System.EventHandler(this.resumeSelect_lbx_SelectedIndexChanged);
            // 
            // menu_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 424);
            this.Controls.Add(this.resume_pnl);
            this.Controls.Add(this.puzzle_selection_pnl);
            this.Controls.Add(this.specific_pnl);
            this.Controls.Add(this.random_pnl);
            this.Controls.Add(this.welcome_lbl);
            this.Name = "menu_form";
            this.Text = "Sodoku";
            this.Load += new System.EventHandler(this.menu_form_Load);
            this.puzzle_selection_pnl.ResumeLayout(false);
            this.random_pnl.ResumeLayout(false);
            this.random_pnl.PerformLayout();
            this.specific_pnl.ResumeLayout(false);
            this.specific_pnl.PerformLayout();
            this.resume_pnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcome_lbl;
        private System.Windows.Forms.Button random_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button resume_btn;
        private System.Windows.Forms.Panel puzzle_selection_pnl;
        private System.Windows.Forms.Panel random_pnl;
        private System.Windows.Forms.Button playRandom_btn;
        private System.Windows.Forms.CheckBox newPuzzle_ckbx;
        private System.Windows.Forms.Label randomDifficulty_lbl;
        private System.Windows.Forms.ComboBox randomDifficulty_cbx;
        private System.Windows.Forms.Panel specific_pnl;
        private System.Windows.Forms.Button playSpecific_btn;
        private System.Windows.Forms.Label specificDifficulty_lbl;
        private System.Windows.Forms.ComboBox specificDifficulty_cbx;
        private System.Windows.Forms.ListBox puzzleSelect_lbx;
        private System.Windows.Forms.Panel resume_pnl;
        private System.Windows.Forms.Button playResume_btn;
        private System.Windows.Forms.ListBox resumeSelect_lbx;
    }
}

