
namespace Sky_Cloud_Backup
{
    partial class Copying_files
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
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(217, 76);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 4;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(6, 41);
            this.pBar.MarqueeAnimationSpeed = 1;
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(286, 11);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pBar.TabIndex = 3;
            this.pBar.Value = 1;
            // 
            // Copying_files
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 111);
            this.ControlBox = false;
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.pBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Copying_files";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backuping your world";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.ProgressBar pBar;
    }
}