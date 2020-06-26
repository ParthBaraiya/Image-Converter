namespace ImageConverter
{
    partial class CustomControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.processText = new System.Windows.Forms.Label();
            this.progressIndecator = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // processText
            // 
            this.processText.AutoSize = true;
            this.processText.Location = new System.Drawing.Point(8, 7);
            this.processText.Name = "processText";
            this.processText.Size = new System.Drawing.Size(57, 13);
            this.processText.TabIndex = 0;
            this.processText.Text = "Progress...";
            // 
            // progressIndecator
            // 
            this.progressIndecator.Location = new System.Drawing.Point(12, 36);
            this.progressIndecator.Name = "progressIndecator";
            this.progressIndecator.Size = new System.Drawing.Size(157, 23);
            this.progressIndecator.TabIndex = 1;
            // 
            // CustomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressIndecator);
            this.Controls.Add(this.processText);
            this.Name = "CustomControl";
            this.Size = new System.Drawing.Size(182, 73);
            this.Load += new System.EventHandler(this.CustomControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label processText;
        private System.Windows.Forms.ProgressBar progressIndecator;
    }
}
