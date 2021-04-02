
namespace Assignment5
{
    partial class PuzzleForm
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
            this.numberBoxHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.sums_pnl = new System.Windows.Forms.Panel();
            this.DiagonalsSumsHdr_lbl = new System.Windows.Forms.Label();
            this.diagonalsSums_lbl = new System.Windows.Forms.Label();
            this.ColumnsSumsHdr_lbl = new System.Windows.Forms.Label();
            this.columnsSums_lbl = new System.Windows.Forms.Label();
            this.rowSumsHdr_lbl = new System.Windows.Forms.Label();
            this.rowsSums_lbl = new System.Windows.Forms.Label();
            this.sums_lbl = new System.Windows.Forms.Label();
            this.actualSums_pnl = new System.Windows.Forms.Panel();
            this.asDiagonals_lbl = new System.Windows.Forms.Label();
            this.asColumns_lbl = new System.Windows.Forms.Label();
            this.asRows_lbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.actualSums_lbl = new System.Windows.Forms.Label();
            this.options_pnl = new System.Windows.Forms.Panel();
            this.reset_btn = new System.Windows.Forms.Button();
            this.playPause_btn = new System.Windows.Forms.Button();
            this.progress_lbl = new System.Windows.Forms.Label();
            this.progress_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.sums_pnl.SuspendLayout();
            this.actualSums_pnl.SuspendLayout();
            this.options_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // numberBoxHolder
            // 
            this.numberBoxHolder.Location = new System.Drawing.Point(12, 12);
            this.numberBoxHolder.Name = "numberBoxHolder";
            this.numberBoxHolder.Size = new System.Drawing.Size(536, 356);
            this.numberBoxHolder.TabIndex = 0;
            // 
            // sums_pnl
            // 
            this.sums_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sums_pnl.Controls.Add(this.DiagonalsSumsHdr_lbl);
            this.sums_pnl.Controls.Add(this.diagonalsSums_lbl);
            this.sums_pnl.Controls.Add(this.ColumnsSumsHdr_lbl);
            this.sums_pnl.Controls.Add(this.columnsSums_lbl);
            this.sums_pnl.Controls.Add(this.rowSumsHdr_lbl);
            this.sums_pnl.Controls.Add(this.rowsSums_lbl);
            this.sums_pnl.Controls.Add(this.sums_lbl);
            this.sums_pnl.Location = new System.Drawing.Point(12, 374);
            this.sums_pnl.Name = "sums_pnl";
            this.sums_pnl.Size = new System.Drawing.Size(305, 200);
            this.sums_pnl.TabIndex = 2;
            // 
            // DiagonalsSumsHdr_lbl
            // 
            this.DiagonalsSumsHdr_lbl.AutoSize = true;
            this.DiagonalsSumsHdr_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiagonalsSumsHdr_lbl.Location = new System.Drawing.Point(171, 30);
            this.DiagonalsSumsHdr_lbl.Name = "DiagonalsSumsHdr_lbl";
            this.DiagonalsSumsHdr_lbl.Size = new System.Drawing.Size(80, 17);
            this.DiagonalsSumsHdr_lbl.TabIndex = 6;
            this.DiagonalsSumsHdr_lbl.Text = "Diagonals";
            // 
            // diagonalsSums_lbl
            // 
            this.diagonalsSums_lbl.AutoSize = true;
            this.diagonalsSums_lbl.Location = new System.Drawing.Point(171, 60);
            this.diagonalsSums_lbl.Name = "diagonalsSums_lbl";
            this.diagonalsSums_lbl.Size = new System.Drawing.Size(0, 13);
            this.diagonalsSums_lbl.TabIndex = 5;
            // 
            // ColumnsSumsHdr_lbl
            // 
            this.ColumnsSumsHdr_lbl.AutoSize = true;
            this.ColumnsSumsHdr_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnsSumsHdr_lbl.Location = new System.Drawing.Point(75, 30);
            this.ColumnsSumsHdr_lbl.Name = "ColumnsSumsHdr_lbl";
            this.ColumnsSumsHdr_lbl.Size = new System.Drawing.Size(69, 17);
            this.ColumnsSumsHdr_lbl.TabIndex = 4;
            this.ColumnsSumsHdr_lbl.Text = "Columns";
            // 
            // columnsSums_lbl
            // 
            this.columnsSums_lbl.AutoSize = true;
            this.columnsSums_lbl.Location = new System.Drawing.Point(75, 60);
            this.columnsSums_lbl.Name = "columnsSums_lbl";
            this.columnsSums_lbl.Size = new System.Drawing.Size(0, 13);
            this.columnsSums_lbl.TabIndex = 3;
            // 
            // rowSumsHdr_lbl
            // 
            this.rowSumsHdr_lbl.AutoSize = true;
            this.rowSumsHdr_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowSumsHdr_lbl.Location = new System.Drawing.Point(3, 30);
            this.rowSumsHdr_lbl.Name = "rowSumsHdr_lbl";
            this.rowSumsHdr_lbl.Size = new System.Drawing.Size(46, 17);
            this.rowSumsHdr_lbl.TabIndex = 2;
            this.rowSumsHdr_lbl.Text = "Rows";
            // 
            // rowsSums_lbl
            // 
            this.rowsSums_lbl.AutoSize = true;
            this.rowsSums_lbl.Location = new System.Drawing.Point(3, 60);
            this.rowsSums_lbl.Name = "rowsSums_lbl";
            this.rowsSums_lbl.Size = new System.Drawing.Size(0, 13);
            this.rowsSums_lbl.TabIndex = 1;
            // 
            // sums_lbl
            // 
            this.sums_lbl.AutoSize = true;
            this.sums_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sums_lbl.Location = new System.Drawing.Point(90, -1);
            this.sums_lbl.Name = "sums_lbl";
            this.sums_lbl.Size = new System.Drawing.Size(118, 17);
            this.sums_lbl.TabIndex = 0;
            this.sums_lbl.Text = "Expected Sums";
            // 
            // actualSums_pnl
            // 
            this.actualSums_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.actualSums_pnl.Controls.Add(this.asDiagonals_lbl);
            this.actualSums_pnl.Controls.Add(this.asColumns_lbl);
            this.actualSums_pnl.Controls.Add(this.asRows_lbl);
            this.actualSums_pnl.Controls.Add(this.label6);
            this.actualSums_pnl.Controls.Add(this.actualSums_lbl);
            this.actualSums_pnl.Location = new System.Drawing.Point(323, 375);
            this.actualSums_pnl.Name = "actualSums_pnl";
            this.actualSums_pnl.Size = new System.Drawing.Size(305, 269);
            this.actualSums_pnl.TabIndex = 3;
            // 
            // asDiagonals_lbl
            // 
            this.asDiagonals_lbl.AutoSize = true;
            this.asDiagonals_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asDiagonals_lbl.Location = new System.Drawing.Point(171, 30);
            this.asDiagonals_lbl.Name = "asDiagonals_lbl";
            this.asDiagonals_lbl.Size = new System.Drawing.Size(80, 17);
            this.asDiagonals_lbl.TabIndex = 6;
            this.asDiagonals_lbl.Text = "Diagonals";
            // 
            // asColumns_lbl
            // 
            this.asColumns_lbl.AutoSize = true;
            this.asColumns_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asColumns_lbl.Location = new System.Drawing.Point(75, 30);
            this.asColumns_lbl.Name = "asColumns_lbl";
            this.asColumns_lbl.Size = new System.Drawing.Size(69, 17);
            this.asColumns_lbl.TabIndex = 4;
            this.asColumns_lbl.Text = "Columns";
            // 
            // asRows_lbl
            // 
            this.asRows_lbl.AutoSize = true;
            this.asRows_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asRows_lbl.Location = new System.Drawing.Point(3, 30);
            this.asRows_lbl.Name = "asRows_lbl";
            this.asRows_lbl.Size = new System.Drawing.Size(46, 17);
            this.asRows_lbl.TabIndex = 2;
            this.asRows_lbl.Text = "Rows";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 1;
            // 
            // actualSums_lbl
            // 
            this.actualSums_lbl.AutoSize = true;
            this.actualSums_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualSums_lbl.Location = new System.Drawing.Point(115, 0);
            this.actualSums_lbl.Name = "actualSums_lbl";
            this.actualSums_lbl.Size = new System.Drawing.Size(97, 17);
            this.actualSums_lbl.TabIndex = 0;
            this.actualSums_lbl.Text = "Actual Sums";
            // 
            // options_pnl
            // 
            this.options_pnl.Controls.Add(this.reset_btn);
            this.options_pnl.Controls.Add(this.playPause_btn);
            this.options_pnl.Controls.Add(this.progress_lbl);
            this.options_pnl.Controls.Add(this.progress_btn);
            this.options_pnl.Controls.Add(this.save_btn);
            this.options_pnl.Location = new System.Drawing.Point(554, 12);
            this.options_pnl.Name = "options_pnl";
            this.options_pnl.Size = new System.Drawing.Size(239, 212);
            this.options_pnl.TabIndex = 4;
            // 
            // reset_btn
            // 
            this.reset_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_btn.ForeColor = System.Drawing.Color.Red;
            this.reset_btn.Location = new System.Drawing.Point(3, 103);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(75, 23);
            this.reset_btn.TabIndex = 4;
            this.reset_btn.Text = "Reset";
            this.reset_btn.UseVisualStyleBackColor = true;
            this.reset_btn.Click += new System.EventHandler(this.reset_btn_Click);
            // 
            // playPause_btn
            // 
            this.playPause_btn.Location = new System.Drawing.Point(3, 57);
            this.playPause_btn.Name = "playPause_btn";
            this.playPause_btn.Size = new System.Drawing.Size(75, 23);
            this.playPause_btn.TabIndex = 3;
            this.playPause_btn.Text = "Pause ⏸️";
            this.playPause_btn.UseVisualStyleBackColor = true;
            this.playPause_btn.Click += new System.EventHandler(this.playPause_btn_Click);
            // 
            // progress_lbl
            // 
            this.progress_lbl.AutoSize = true;
            this.progress_lbl.Location = new System.Drawing.Point(106, 17);
            this.progress_lbl.Name = "progress_lbl";
            this.progress_lbl.Size = new System.Drawing.Size(0, 13);
            this.progress_lbl.TabIndex = 2;
            // 
            // progress_btn
            // 
            this.progress_btn.Location = new System.Drawing.Point(3, 12);
            this.progress_btn.Name = "progress_btn";
            this.progress_btn.Size = new System.Drawing.Size(97, 23);
            this.progress_btn.TabIndex = 1;
            this.progress_btn.Text = "Check Progress";
            this.progress_btn.UseVisualStyleBackColor = true;
            this.progress_btn.Click += new System.EventHandler(this.progress_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.Location = new System.Drawing.Point(3, 153);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(131, 27);
            this.save_btn.TabIndex = 0;
            this.save_btn.Text = "Save and Quit";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // PuzzleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(808, 667);
            this.Controls.Add(this.options_pnl);
            this.Controls.Add(this.actualSums_pnl);
            this.Controls.Add(this.sums_pnl);
            this.Controls.Add(this.numberBoxHolder);
            this.Name = "PuzzleForm";
            this.Text = "Sudoku";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PuzzleForm_FormClosing);
            this.sums_pnl.ResumeLayout(false);
            this.sums_pnl.PerformLayout();
            this.actualSums_pnl.ResumeLayout(false);
            this.actualSums_pnl.PerformLayout();
            this.options_pnl.ResumeLayout(false);
            this.options_pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel numberBoxHolder;
        private System.Windows.Forms.Panel sums_pnl;
        private System.Windows.Forms.Label DiagonalsSumsHdr_lbl;
        private System.Windows.Forms.Label diagonalsSums_lbl;
        private System.Windows.Forms.Label ColumnsSumsHdr_lbl;
        private System.Windows.Forms.Label columnsSums_lbl;
        private System.Windows.Forms.Label rowSumsHdr_lbl;
        private System.Windows.Forms.Label rowsSums_lbl;
        private System.Windows.Forms.Label sums_lbl;
        private System.Windows.Forms.Panel actualSums_pnl;
        private System.Windows.Forms.Label asDiagonals_lbl;
        private System.Windows.Forms.Label asColumns_lbl;
        private System.Windows.Forms.Label asRows_lbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label actualSums_lbl;
        private System.Windows.Forms.Panel options_pnl;
        private System.Windows.Forms.Button reset_btn;
        private System.Windows.Forms.Button playPause_btn;
        private System.Windows.Forms.Label progress_lbl;
        private System.Windows.Forms.Button progress_btn;
        private System.Windows.Forms.Button save_btn;
    }
}