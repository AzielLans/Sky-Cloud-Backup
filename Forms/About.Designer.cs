
namespace Sky_Cloud_Backup
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && ( components != null ))
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
        private void InitializeComponent ()
        {
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.versionlabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GithubButton = new MaterialSkin.Controls.MaterialButton();
            this.BugButton = new MaterialSkin.Controls.MaterialButton();
            this.LicenseButton = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Light", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H2;
            this.materialLabel1.HighEmphasis = true;
            this.materialLabel1.Location = new System.Drawing.Point(158, 44);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(472, 72);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "Sky Cloud Backup";
            // 
            // versionlabel
            // 
            this.versionlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.versionlabel.AutoSize = true;
            this.versionlabel.Depth = 0;
            this.versionlabel.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.versionlabel.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.versionlabel.Location = new System.Drawing.Point(545, 223);
            this.versionlabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.versionlabel.Name = "versionlabel";
            this.versionlabel.Size = new System.Drawing.Size(85, 24);
            this.versionlabel.TabIndex = 3;
            this.versionlabel.Text = "Alpha 0.4";
            // 
            // materialLabel3
            // 
            this.materialLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel3.Location = new System.Drawing.Point(165, 116);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(73, 29);
            this.materialLabel3.TabIndex = 4;
            this.materialLabel3.Text = "Involts";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::Sky_Cloud_Backup.Properties.Resources.SCB_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(6, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // GithubButton
            // 
            this.GithubButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GithubButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GithubButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.GithubButton.Depth = 0;
            this.GithubButton.HighEmphasis = true;
            this.GithubButton.Icon = null;
            this.GithubButton.Location = new System.Drawing.Point(6, 223);
            this.GithubButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.GithubButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.GithubButton.Name = "GithubButton";
            this.GithubButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.GithubButton.Size = new System.Drawing.Size(165, 36);
            this.GithubButton.TabIndex = 10;
            this.GithubButton.Text = "Github Repository";
            this.GithubButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.GithubButton.UseAccentColor = true;
            this.GithubButton.UseVisualStyleBackColor = true;
            this.GithubButton.Click += new System.EventHandler(this.Github_Click);
            // 
            // BugButton
            // 
            this.BugButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BugButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BugButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BugButton.Depth = 0;
            this.BugButton.HighEmphasis = true;
            this.BugButton.Icon = null;
            this.BugButton.Location = new System.Drawing.Point(179, 223);
            this.BugButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BugButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.BugButton.Name = "BugButton";
            this.BugButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BugButton.Size = new System.Drawing.Size(118, 36);
            this.BugButton.TabIndex = 11;
            this.BugButton.Text = "Report Bugs";
            this.BugButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.BugButton.UseAccentColor = true;
            this.BugButton.UseVisualStyleBackColor = true;
            this.BugButton.Click += new System.EventHandler(this.Bugs_Click);
            // 
            // LicenseButton
            // 
            this.LicenseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LicenseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LicenseButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.LicenseButton.Depth = 0;
            this.LicenseButton.HighEmphasis = true;
            this.LicenseButton.Icon = null;
            this.LicenseButton.Location = new System.Drawing.Point(305, 223);
            this.LicenseButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.LicenseButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.LicenseButton.Name = "LicenseButton";
            this.LicenseButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.LicenseButton.Size = new System.Drawing.Size(79, 36);
            this.LicenseButton.TabIndex = 12;
            this.LicenseButton.Text = "License";
            this.LicenseButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.LicenseButton.UseAccentColor = true;
            this.LicenseButton.UseVisualStyleBackColor = true;
            this.LicenseButton.Click += new System.EventHandler(this.License_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(645, 268);
            this.Controls.Add(this.LicenseButton);
            this.Controls.Add(this.BugButton);
            this.Controls.Add(this.GithubButton);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.versionlabel);
            this.Controls.Add(this.pictureBox1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "About";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.ShowIcon = false;
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel versionlabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialButton GithubButton;
        private MaterialSkin.Controls.MaterialButton BugButton;
        private MaterialSkin.Controls.MaterialButton LicenseButton;
    }
}