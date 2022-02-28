
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
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.CancelButton = new MaterialSkin.Controls.MaterialButton();
            this.wht_txr = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(6, 58);
            this.pBar.MarqueeAnimationSpeed = 1;
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(316, 17);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pBar.TabIndex = 3;
            this.pBar.Value = 1;
            // 
            // wht_txr
            // 
            this.wht_txr.AutoSize = true;
            this.wht_txr.Depth = 0;
            this.wht_txr.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.wht_txr.Location = new System.Drawing.Point(6, 22);
            this.wht_txr.MouseState = MaterialSkin.MouseState.HOVER;
            this.wht_txr.Name = "wht_txr";
            this.wht_txr.Size = new System.Drawing.Size(154, 19);
            this.wht_txr.TabIndex = 6;
            this.wht_txr.Text = "Backuping your world";
            // 
            // Copying_files
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 138);
            this.ControlBox = false;
            this.Controls.Add(this.wht_txr);
            this.Controls.Add(this.pBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Copying_files";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backuping your world";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar pBar;
        private MaterialSkin.Controls.MaterialLabel wht_txr;
    }
}