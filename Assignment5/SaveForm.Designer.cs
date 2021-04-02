
namespace Assignment5
{
    partial class SaveForm
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
            this.nameSave_lbl = new System.Windows.Forms.Label();
            this.savename_txt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameSave_lbl
            // 
            this.nameSave_lbl.AutoSize = true;
            this.nameSave_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameSave_lbl.Location = new System.Drawing.Point(20, 45);
            this.nameSave_lbl.Name = "nameSave_lbl";
            this.nameSave_lbl.Size = new System.Drawing.Size(164, 17);
            this.nameSave_lbl.TabIndex = 0;
            this.nameSave_lbl.Text = "Please name your save: ";
            // 
            // savename_txt
            // 
            this.savename_txt.Location = new System.Drawing.Point(191, 45);
            this.savename_txt.Name = "savename_txt";
            this.savename_txt.Size = new System.Drawing.Size(153, 20);
            this.savename_txt.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(137, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 170);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.savename_txt);
            this.Controls.Add(this.nameSave_lbl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveForm";
            this.Text = "Save";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameSave_lbl;
        private System.Windows.Forms.TextBox savename_txt;
        private System.Windows.Forms.Button button1;
    }
}