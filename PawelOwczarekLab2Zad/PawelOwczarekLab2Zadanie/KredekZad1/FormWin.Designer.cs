namespace KredekZad1
{
    partial class FormWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWin));
            this.pictureBoxWin = new System.Windows.Forms.PictureBox();
            this.labelWin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWin)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxWin
            // 
            this.pictureBoxWin.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWin.Image")));
            this.pictureBoxWin.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxWin.Name = "pictureBoxWin";
            this.pictureBoxWin.Size = new System.Drawing.Size(703, 518);
            this.pictureBoxWin.TabIndex = 0;
            this.pictureBoxWin.TabStop = false;
            // 
            // labelWin
            // 
            this.labelWin.AutoSize = true;
            this.labelWin.BackColor = System.Drawing.Color.Maroon;
            this.labelWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWin.ForeColor = System.Drawing.Color.Green;
            this.labelWin.Location = new System.Drawing.Point(177, 143);
            this.labelWin.Name = "labelWin";
            this.labelWin.Size = new System.Drawing.Size(366, 55);
            this.labelWin.TabIndex = 1;
            this.labelWin.Text = "ZWYCIĘSTWO!";
            // 
            // FormWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 523);
            this.Controls.Add(this.labelWin);
            this.Controls.Add(this.pictureBoxWin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormWin";
            this.Text = "YouWon";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxWin;
        private System.Windows.Forms.Label labelWin;
    }
}