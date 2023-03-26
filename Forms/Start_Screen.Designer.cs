
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loading_screen));
            this.Loading_bar_load = new MaterialSkin.Controls.MaterialProgressBar();
            this.load_timer = new System.Windows.Forms.Timer(this.components);
            this.panel_bar = new System.Windows.Forms.Panel();
            this.Load_Panel = new System.Windows.Forms.Panel();
            this.Dev_Label = new MaterialSkin.Controls.MaterialLabel();
            this.Ues_label = new MaterialSkin.Controls.MaterialLabel();
            this.Reset_label = new MaterialSkin.Controls.MaterialLabel();
            this.Cancel_backup_info = new MaterialSkin.Controls.MaterialLabel();
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
            this.panel_bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(156)))), ((int)(((byte)(203)))));
            this.panel_bar.Controls.Add(this.Load_Panel);
            this.panel_bar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bar.Location = new System.Drawing.Point(0, 320);
            this.panel_bar.Name = "panel_bar";
            this.panel_bar.Size = new System.Drawing.Size(591, 27);
            this.panel_bar.TabIndex = 0;
            // 
            // Load_Panel
            // 
            this.Load_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(167)))), ((int)(((byte)(203)))));
            this.Load_Panel.Location = new System.Drawing.Point(0, 0);
            this.Load_Panel.Name = "Load_Panel";
            this.Load_Panel.Size = new System.Drawing.Size(1, 27);
            this.Load_Panel.TabIndex = 0;
            // 
            // Dev_Label
            // 
            this.Dev_Label.AutoSize = true;
            this.Dev_Label.Depth = 0;
            this.Dev_Label.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Dev_Label.Location = new System.Drawing.Point(6, 9);
            this.Dev_Label.MouseState = MaterialSkin.MouseState.HOVER;
            this.Dev_Label.Name = "Dev_Label";
            this.Dev_Label.Size = new System.Drawing.Size(72, 19);
            this.Dev_Label.TabIndex = 1;
            this.Dev_Label.Text = "Dev Mode";
            this.Dev_Label.Visible = false;
            // 
            // Ues_label
            // 
            this.Ues_label.AutoSize = true;
            this.Ues_label.Depth = 0;
            this.Ues_label.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Ues_label.Location = new System.Drawing.Point(6, 37);
            this.Ues_label.MouseState = MaterialSkin.MouseState.HOVER;
            this.Ues_label.Name = "Ues_label";
            this.Ues_label.Size = new System.Drawing.Size(66, 19);
            this.Ues_label.TabIndex = 2;
            this.Ues_label.Text = "Use Type";
            this.Ues_label.Visible = false;
            // 
            // Reset_label
            // 
            this.Reset_label.AutoSize = true;
            this.Reset_label.Depth = 0;
            this.Reset_label.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Reset_label.Location = new System.Drawing.Point(6, 56);
            this.Reset_label.MouseState = MaterialSkin.MouseState.HOVER;
            this.Reset_label.Name = "Reset_label";
            this.Reset_label.Size = new System.Drawing.Size(68, 19);
            this.Reset_label.TabIndex = 3;
            this.Reset_label.Text = "Reset: No";
            this.Reset_label.Visible = false;
            // 
            // Cancel_backup_info
            // 
            this.Cancel_backup_info.AutoSize = true;
            this.Cancel_backup_info.Depth = 0;
            this.Cancel_backup_info.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Cancel_backup_info.Location = new System.Drawing.Point(6, 75);
            this.Cancel_backup_info.MouseState = MaterialSkin.MouseState.HOVER;
            this.Cancel_backup_info.Name = "Cancel_backup_info";
            this.Cancel_backup_info.Size = new System.Drawing.Size(113, 19);
            this.Cancel_backup_info.TabIndex = 4;
            this.Cancel_backup_info.Text = "Backup_Cancel:";
            this.Cancel_backup_info.Visible = false;
            // 
            // loading_screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(156)))), ((int)(((byte)(203)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(591, 347);
            this.ControlBox = false;
            this.Controls.Add(this.Cancel_backup_info);
            this.Controls.Add(this.Reset_label);
            this.Controls.Add(this.Ues_label);
            this.Controls.Add(this.Dev_Label);
            this.Controls.Add(this.panel_bar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loading_screen";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sky Cloud Backup";
            this.Load += new System.EventHandler(this.loading_screen_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.loading_screen_MouseDown);
            this.panel_bar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialProgressBar Loading_bar_load;
        private System.Windows.Forms.Timer load_timer;
        private System.Windows.Forms.Panel panel_bar;
        private System.Windows.Forms.Panel Load_Panel;
        private MaterialSkin.Controls.MaterialLabel Dev_Label;
        private MaterialSkin.Controls.MaterialLabel Ues_label;
        private MaterialSkin.Controls.MaterialLabel Reset_label;
        private MaterialSkin.Controls.MaterialLabel Cancel_backup_info;
    }
}