﻿
namespace Sky_Cloud_Backup
{
    partial class FirstRun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstRun));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.Next_Button = new MaterialSkin.Controls.MaterialButton();
            this.versionlabel = new MaterialSkin.Controls.MaterialLabel();
            this.Pink_Button = new MaterialSkin.Controls.MaterialRadioButton();
            this.Red_Button = new MaterialSkin.Controls.MaterialRadioButton();
            this.Default_Button = new MaterialSkin.Controls.MaterialRadioButton();
            this.Green_Button = new MaterialSkin.Controls.MaterialRadioButton();
            this.Dark_mode_switch = new MaterialSkin.Controls.MaterialSwitch();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Help_Button = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Sky_Cloud_Backup.Properties.Resources.SCB;
            this.pictureBox1.Location = new System.Drawing.Point(302, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(265, 222);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.materialLabel1.Location = new System.Drawing.Point(214, 279);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(457, 41);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Welcome to Sky Cloud Backup";
            this.materialLabel1.UseAccent = true;
            // 
            // Next_Button
            // 
            this.Next_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Next_Button.AutoSize = false;
            this.Next_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Next_Button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.Next_Button.Depth = 0;
            this.Next_Button.HighEmphasis = true;
            this.Next_Button.Icon = null;
            this.Next_Button.Location = new System.Drawing.Point(357, 342);
            this.Next_Button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Next_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Next_Button.Name = "Next_Button";
            this.Next_Button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Next_Button.Size = new System.Drawing.Size(141, 44);
            this.Next_Button.TabIndex = 4;
            this.Next_Button.Text = "Continue";
            this.Next_Button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Next_Button.UseAccentColor = true;
            this.Next_Button.UseVisualStyleBackColor = true;
            this.Next_Button.Click += new System.EventHandler(this.Next_Button_Click);
            // 
            // versionlabel
            // 
            this.versionlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.versionlabel.AutoSize = true;
            this.versionlabel.Depth = 0;
            this.versionlabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.versionlabel.Location = new System.Drawing.Point(783, 475);
            this.versionlabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.versionlabel.Name = "versionlabel";
            this.versionlabel.Size = new System.Drawing.Size(68, 19);
            this.versionlabel.TabIndex = 5;
            this.versionlabel.Text = "Alpha 0.4";
            this.versionlabel.Click += new System.EventHandler(this.materialLabel3_Click);
            // 
            // Pink_Button
            // 
            this.Pink_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Pink_Button.AutoSize = true;
            this.Pink_Button.Depth = 0;
            this.Pink_Button.Location = new System.Drawing.Point(349, 457);
            this.Pink_Button.Margin = new System.Windows.Forms.Padding(0);
            this.Pink_Button.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Pink_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Pink_Button.Name = "Pink_Button";
            this.Pink_Button.Ripple = true;
            this.Pink_Button.Size = new System.Drawing.Size(66, 37);
            this.Pink_Button.TabIndex = 3;
            this.Pink_Button.TabStop = true;
            this.Pink_Button.Text = "Pink";
            this.Pink_Button.UseVisualStyleBackColor = true;
            this.Pink_Button.Click += new System.EventHandler(this.Pink_Button_CheckedChanged);
            // 
            // Red_Button
            // 
            this.Red_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Red_Button.AutoSize = true;
            this.Red_Button.Depth = 0;
            this.Red_Button.Location = new System.Drawing.Point(287, 457);
            this.Red_Button.Margin = new System.Windows.Forms.Padding(0);
            this.Red_Button.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Red_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Red_Button.Name = "Red_Button";
            this.Red_Button.Ripple = true;
            this.Red_Button.Size = new System.Drawing.Size(62, 37);
            this.Red_Button.TabIndex = 5;
            this.Red_Button.TabStop = true;
            this.Red_Button.Text = "Red";
            this.Red_Button.UseVisualStyleBackColor = true;
            this.Red_Button.Click += new System.EventHandler(this.Red_Button_CheckedChanged);
            // 
            // Default_Button
            // 
            this.Default_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Default_Button.AutoSize = true;
            this.Default_Button.Checked = true;
            this.Default_Button.Cursor = System.Windows.Forms.Cursors.Default;
            this.Default_Button.Depth = 0;
            this.Default_Button.Location = new System.Drawing.Point(145, 456);
            this.Default_Button.Margin = new System.Windows.Forms.Padding(0);
            this.Default_Button.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Default_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Default_Button.Name = "Default_Button";
            this.Default_Button.Ripple = true;
            this.Default_Button.Size = new System.Drawing.Size(66, 37);
            this.Default_Button.TabIndex = 1;
            this.Default_Button.TabStop = true;
            this.Default_Button.Text = "Blue";
            this.Default_Button.UseVisualStyleBackColor = true;
            this.Default_Button.Click += new System.EventHandler(this.Default_Button_CheckedChanged);
            // 
            // Green_Button
            // 
            this.Green_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Green_Button.AutoSize = true;
            this.Green_Button.Depth = 0;
            this.Green_Button.Location = new System.Drawing.Point(211, 457);
            this.Green_Button.Margin = new System.Windows.Forms.Padding(0);
            this.Green_Button.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Green_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Green_Button.Name = "Green_Button";
            this.Green_Button.Ripple = true;
            this.Green_Button.Size = new System.Drawing.Size(76, 37);
            this.Green_Button.TabIndex = 2;
            this.Green_Button.TabStop = true;
            this.Green_Button.Text = "Green";
            this.Green_Button.UseVisualStyleBackColor = true;
            this.Green_Button.Click += new System.EventHandler(this.Green_Button_CheckedChanged);
            // 
            // Dark_mode_switch
            // 
            this.Dark_mode_switch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Dark_mode_switch.AutoSize = true;
            this.Dark_mode_switch.Depth = 0;
            this.Dark_mode_switch.Location = new System.Drawing.Point(0, 457);
            this.Dark_mode_switch.Margin = new System.Windows.Forms.Padding(0);
            this.Dark_mode_switch.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Dark_mode_switch.MouseState = MaterialSkin.MouseState.HOVER;
            this.Dark_mode_switch.Name = "Dark_mode_switch";
            this.Dark_mode_switch.Ripple = true;
            this.Dark_mode_switch.Size = new System.Drawing.Size(135, 37);
            this.Dark_mode_switch.TabIndex = 0;
            this.Dark_mode_switch.Text = "Dark Mode";
            this.Dark_mode_switch.UseVisualStyleBackColor = true;
            this.Dark_mode_switch.Click += new System.EventHandler(this.Dark_mode_switch_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.Help_Button);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Default_Button);
            this.panel1.Controls.Add(this.Green_Button);
            this.panel1.Controls.Add(this.Red_Button);
            this.panel1.Controls.Add(this.Pink_Button);
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Controls.Add(this.versionlabel);
            this.panel1.Controls.Add(this.Next_Button);
            this.panel1.Controls.Add(this.Dark_mode_switch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 500);
            this.panel1.TabIndex = 6;
            // 
            // Help_Button
            // 
            this.Help_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Help_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Help_Button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.Help_Button.Depth = 0;
            this.Help_Button.DrawShadows = false;
            this.Help_Button.HighEmphasis = true;
            this.Help_Button.Icon = global::Sky_Cloud_Backup.Properties.Resources.sharp_question_mark_white_24dp;
            this.Help_Button.Location = new System.Drawing.Point(764, 6);
            this.Help_Button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Help_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Help_Button.Name = "Help_Button";
            this.Help_Button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Help_Button.Size = new System.Drawing.Size(86, 36);
            this.Help_Button.TabIndex = 6;
            this.Help_Button.Text = "Help";
            this.Help_Button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Help_Button.UseAccentColor = true;
            this.Help_Button.UseVisualStyleBackColor = true;
            this.Help_Button.Click += new System.EventHandler(this.Help_Button_Click);
            // 
            // FirstRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(860, 567);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FirstRun";
            this.ShowIcon = false;
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "First Use";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.first_strtup_FormClosing);
            this.Load += new System.EventHandler(this.first_strtup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton Next_Button;
        private MaterialSkin.Controls.MaterialLabel versionlabel;
        private MaterialSkin.Controls.MaterialRadioButton Pink_Button;
        private MaterialSkin.Controls.MaterialRadioButton Red_Button;
        private MaterialSkin.Controls.MaterialRadioButton Default_Button;
        private MaterialSkin.Controls.MaterialRadioButton Green_Button;
        private MaterialSkin.Controls.MaterialSwitch Dark_mode_switch;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialButton Help_Button;
    }
}