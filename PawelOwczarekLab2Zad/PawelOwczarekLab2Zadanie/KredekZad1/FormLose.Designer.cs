namespace KredekZad1
{
    partial class FormLose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLose));
            this.labelLose = new System.Windows.Forms.Label();
            this.pictureBoxWin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWin)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLose
            // 
            this.labelLose.AutoSize = true;
            this.labelLose.BackColor = System.Drawing.Color.Maroon;
            this.labelLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLose.ForeColor = System.Drawing.Color.Green;
            this.labelLose.Location = new System.Drawing.Point(230, 140);
            this.labelLose.Name = "labelLose";
            this.labelLose.Size = new System.Drawing.Size(266, 55);
            this.labelLose.TabIndex = 3;
            this.labelLose.Text = "PORAŻKA!";
            // 
            // pictureBoxWin
            // 
            this.pictureBoxWin.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWin.Image")));
            this.pictureBoxWin.Location = new System.Drawing.Point(-3, 1);
            this.pictureBoxWin.Name = "pictureBoxWin";
            this.pictureBoxWin.Size = new System.Drawing.Size(703, 518);
            this.pictureBoxWin.TabIndex = 2;
            this.pictureBoxWin.TabStop = false;
            // 
            // FormLose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 514);
            this.Controls.Add(this.labelLose);
            this.Controls.Add(this.pictureBoxWin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLose";
            this.Text = "You lose";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLose;
        private System.Windows.Forms.PictureBox pictureBoxWin;
    }
}