
namespace Sky_Cloud_Backup
{
    partial class loading_screen
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
            if (disposing&&( components!=null ))
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
            this.components = new System.ComponentModel.Container();
            this.Loading_bar_load = new MaterialSkin.Controls.MaterialProgressBar();
            this.load_timer = new System.Windows.Forms.Timer(this.components);
            this.panel_bar = new System.Windows.Forms.Panel();
            this.Load_Panel = new System.Windows.Forms.Panel();
            this.panel_bar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Loading_bar_load
            // 
            this.Loading_bar_load.Depth = 0;
            this.Loading_bar_load.Location = new System.Drawing.Point(41, 142);
            this.Loading_bar_load.MouseState = MaterialSkin.MouseState.HOVER;
            this.Loading_bar_load.Name = "Loading_bar_load";
            this.Loading_bar_load.Size = new System.Drawing.Size(466, 5);
            this.Loading_bar_load.Step = 100;
            this.Loading_bar_load.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Loading_bar_load.TabIndex = 6;
            // 
            // load_timer
            // 
            this.load_timer.Tick += new System.EventHandler(this.load_timer_Tick);
            // 
            // panel_bar
            // 
            this.panel_bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(109)))), ((int)(((byte)(104)))));
            this.panel_bar.Controls.Add(this.Load_Panel);
            this.panel_bar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bar.Location = new System.Drawing.Point(0, 320);
            this.panel_bar.Name = "panel_bar";
            this.panel_bar.Size = new System.Drawing.Size(591, 27);
            this.panel_bar.TabIndex = 0;
            // 
            // Load_Panel
            // 
            this.Load_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(47)))));
            this.Load_Panel.Location = new System.Drawing.Point(0, 0);
            this.Load_Panel.Name = "Load_Panel";
            this.Load_Panel.Size = new System.Drawing.Size(1, 27);
            this.Load_Panel.TabIndex = 0;
            // 
            // loading_screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(119)))), ((int)(((byte)(189)))));
            this.BackgroundImage = global::Sky_Cloud_Backup.Properties.Resources.Splash_Screen;
            this.ClientSize = new System.Drawing.Size(591, 347);
            this.ControlBox = false;
            this.Controls.Add(this.panel_bar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loading_screen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sky Cloud Backup";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.loading_screen_Load);
            this.panel_bar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialProgressBar Loading_bar_load;
        private System.Windows.Forms.Timer load_timer;
        private System.Windows.Forms.Panel panel_bar;
        private System.Windows.Forms.Panel Load_Panel;
    }
}