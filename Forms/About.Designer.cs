
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.Github = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::Sky_Cloud_Backup.Properties.Resources.logo_128;
            this.pictureBox1.Location = new System.Drawing.Point(6, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 115);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Light", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H2;
            this.materialLabel1.Location = new System.Drawing.Point(151, 90);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(472, 72);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "Sky Cloud Backup";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel2.Location = new System.Drawing.Point(556, 259);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(85, 24);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Alpha 0.4";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel3.Location = new System.Drawing.Point(158, 162);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(73, 29);
            this.materialLabel3.TabIndex = 4;
            this.materialLabel3.Text = "Involts";
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.materialLabel5);
            this.materialCard1.Controls.Add(this.materialLabel4);
            this.materialCard1.Controls.Add(this.Github);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(6, 245);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(533, 57);
            this.materialCard1.TabIndex = 6;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel4.Location = new System.Drawing.Point(235, 14);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(110, 24);
            this.materialLabel4.TabIndex = 8;
            this.materialLabel4.Text = "Report Bugs";
            this.materialLabel4.Click += new System.EventHandler(this.Bugs_Click);
            // 
            // Github
            // 
            this.Github.AutoSize = true;
            this.Github.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Github.Depth = 0;
            this.Github.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.Github.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.Github.Location = new System.Drawing.Point(30, 14);
            this.Github.MouseState = MaterialSkin.MouseState.HOVER;
            this.Github.Name = "Github";
            this.Github.Size = new System.Drawing.Size(160, 24);
            this.Github.TabIndex = 7;
            this.Github.Text = "Github Repository";
            this.Github.Click += new System.EventHandler(this.Github_Click);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel5.Location = new System.Drawing.Point(391, 14);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(70, 24);
            this.materialLabel5.TabIndex = 9;
            this.materialLabel5.Text = "License";
            this.materialLabel5.Click += new System.EventHandler(this.License_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(674, 319);
            this.Controls.Add(this.materialCard1);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "About";
            this.ShowIcon = false;
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialLabel Github;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
    }
}