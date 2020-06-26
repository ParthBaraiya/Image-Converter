namespace ImageConverter
{
    partial class Progressor
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
            this.progressIndecator = new System.Windows.Forms.ProgressBar();
            this.fileCounter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressIndecator
            // 
            this.progressIndecator.Location = new System.Drawing.Point(12, 61);
            this.progressIndecator.Name = "progressIndecator";
            this.progressIndecator.Size = new System.Drawing.Size(297, 15);
            this.progressIndecator.TabIndex = 0;
            // 
            // fileCounter
            // 
            this.fileCounter.AutoSize = true;
            this.fileCounter.Location = new System.Drawing.Point(12, 32);
            this.fileCounter.Name = "fileCounter";
            this.fileCounter.Size = new System.Drawing.Size(35, 13);
            this.fileCounter.TabIndex = 1;
            this.fileCounter.Text = "label1";
            // 
            // Progressor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 94);
            this.Controls.Add(this.fileCounter);
            this.Controls.Add(this.progressIndecator);
            this.Name = "Progressor";
            this.Text = "Progressor";
            this.Load += new System.EventHandler(this.Progressor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressIndecator;
        private System.Windows.Forms.Label fileCounter;
    }
}