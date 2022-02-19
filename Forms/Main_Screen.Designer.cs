
namespace Sky_Cloud_Backup
{
    partial class Main_Screen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Screen));
            this.Open_World_Card = new MaterialSkin.Controls.MaterialCard();
            this.Save_World_Button = new MaterialSkin.Controls.MaterialButton();
            this.Open_World_Button = new MaterialSkin.Controls.MaterialButton();
            this.Save_World_TextBox = new MaterialSkin.Controls.MaterialTextBox();
            this.Open_Word_Text = new MaterialSkin.Controls.MaterialTextBox();
            this.Upload_to_Drive_Card = new MaterialSkin.Controls.MaterialCard();
            this.Sigin_in_Button = new MaterialSkin.Controls.MaterialButton();
            this.Note = new MaterialSkin.Controls.MaterialLabel();
            this.Upload_to_Drive_CheckBox = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.Backup_Button = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.Personalization_Card = new MaterialSkin.Controls.MaterialCard();
            this.materialCheckedListBox2 = new MaterialSkin.Controls.MaterialCheckedListBox();
            this.Pink_Button = new MaterialSkin.Controls.MaterialRadioButton();
            this.Red_Button = new MaterialSkin.Controls.MaterialRadioButton();
            this.Default_Button = new MaterialSkin.Controls.MaterialRadioButton();
            this.Green_Button = new MaterialSkin.Controls.MaterialRadioButton();
            this.Dark_mode_switch = new MaterialSkin.Controls.MaterialSwitch();
            this.materialCheckedListBox1 = new MaterialSkin.Controls.MaterialCheckedListBox();
            this.Strt_Win = new MaterialSkin.Controls.MaterialCheckbox();
            this.Always_Top = new MaterialSkin.Controls.MaterialCheckbox();
            this.Minimize_Systray = new MaterialSkin.Controls.MaterialCheckbox();
            this.Open_World = new System.Windows.Forms.FolderBrowserDialog();
            this.Save_World = new System.Windows.Forms.FolderBrowserDialog();
            this.notify_tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.Tray_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Edtitions = new MaterialSkin.Controls.MaterialSwitch();
            this.Help_Button = new MaterialSkin.Controls.MaterialButton();
            this.Open_World_Card.SuspendLayout();
            this.Upload_to_Drive_Card.SuspendLayout();
            this.Personalization_Card.SuspendLayout();
            this.materialCheckedListBox2.SuspendLayout();
            this.materialCheckedListBox1.SuspendLayout();
            this.Tray_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Open_World_Card
            // 
            this.Open_World_Card.AutoSize = true;
            this.Open_World_Card.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Open_World_Card.Controls.Add(this.Save_World_Button);
            this.Open_World_Card.Controls.Add(this.Open_World_Button);
            this.Open_World_Card.Controls.Add(this.Save_World_TextBox);
            this.Open_World_Card.Controls.Add(this.Open_Word_Text);
            this.Open_World_Card.Depth = 0;
            this.Open_World_Card.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Open_World_Card.Location = new System.Drawing.Point(17, 102);
            this.Open_World_Card.Margin = new System.Windows.Forms.Padding(14);
            this.Open_World_Card.MouseState = MaterialSkin.MouseState.HOVER;
            this.Open_World_Card.Name = "Open_World_Card";
            this.Open_World_Card.Padding = new System.Windows.Forms.Padding(14);
            this.Open_World_Card.Size = new System.Drawing.Size(534, 152);
            this.Open_World_Card.TabIndex = 0;
            // 
            // Save_World_Button
            // 
            this.Save_World_Button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Save_World_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Save_World_Button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Save_World_Button.Depth = 0;
            this.Save_World_Button.DrawShadows = false;
            this.Save_World_Button.HighEmphasis = true;
            this.Save_World_Button.Icon = null;
            this.Save_World_Button.Location = new System.Drawing.Point(405, 80);
            this.Save_World_Button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Save_World_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Save_World_Button.Name = "Save_World_Button";
            this.Save_World_Button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Save_World_Button.Size = new System.Drawing.Size(111, 36);
            this.Save_World_Button.TabIndex = 2;
            this.Save_World_Button.Text = "Save World";
            this.Save_World_Button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Save_World_Button.UseAccentColor = true;
            this.Save_World_Button.UseVisualStyleBackColor = true;
            this.Save_World_Button.Click += new System.EventHandler(this.Save_World_Button_Click);
            // 
            // Open_World_Button
            // 
            this.Open_World_Button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Open_World_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Open_World_Button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Open_World_Button.Depth = 0;
            this.Open_World_Button.DrawShadows = false;
            this.Open_World_Button.HighEmphasis = true;
            this.Open_World_Button.Icon = null;
            this.Open_World_Button.Location = new System.Drawing.Point(402, 17);
            this.Open_World_Button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Open_World_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Open_World_Button.Name = "Open_World_Button";
            this.Open_World_Button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Open_World_Button.Size = new System.Drawing.Size(114, 36);
            this.Open_World_Button.TabIndex = 1;
            this.Open_World_Button.Text = "Open World";
            this.Open_World_Button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Open_World_Button.UseAccentColor = true;
            this.Open_World_Button.UseVisualStyleBackColor = true;
            this.Open_World_Button.Click += new System.EventHandler(this.Open_World_Button_Click);
            // 
            // Save_World_TextBox
            // 
            this.Save_World_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_World_TextBox.AnimateReadOnly = false;
            this.Save_World_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Save_World_TextBox.Depth = 0;
            this.Save_World_TextBox.DetectUrls = false;
            this.Save_World_TextBox.EnableAutoDragDrop = true;
            this.Save_World_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Save_World_TextBox.LeadingIcon = global::Sky_Cloud_Backup.Properties.Resources.round_save_white_24dp;
            this.Save_World_TextBox.LeaveOnEnterKey = true;
            this.Save_World_TextBox.Location = new System.Drawing.Point(5, 80);
            this.Save_World_TextBox.MaxLength = 10000;
            this.Save_World_TextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.Save_World_TextBox.Multiline = false;
            this.Save_World_TextBox.Name = "Save_World_TextBox";
            this.Save_World_TextBox.Size = new System.Drawing.Size(390, 36);
            this.Save_World_TextBox.TabIndex = 1;
            this.Save_World_TextBox.Text = "Save World";
            this.Save_World_TextBox.TrailingIcon = null;
            this.Save_World_TextBox.UseTallSize = false;
            this.Save_World_TextBox.Leave += new System.EventHandler(this.Save_World_TextBox_TabStopChanged);
            // 
            // Open_Word_Text
            // 
            this.Open_Word_Text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Open_Word_Text.AnimateReadOnly = false;
            this.Open_Word_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Open_Word_Text.Depth = 0;
            this.Open_Word_Text.DetectUrls = false;
            this.Open_Word_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Open_Word_Text.LeadingIcon = global::Sky_Cloud_Backup.Properties.Resources.round_folder_open_white_24dp;
            this.Open_Word_Text.LeaveOnEnterKey = true;
            this.Open_Word_Text.Location = new System.Drawing.Point(5, 17);
            this.Open_Word_Text.MaxLength = 10000;
            this.Open_Word_Text.MouseState = MaterialSkin.MouseState.OUT;
            this.Open_Word_Text.Multiline = false;
            this.Open_Word_Text.Name = "Open_Word_Text";
            this.Open_Word_Text.Size = new System.Drawing.Size(390, 36);
            this.Open_Word_Text.TabIndex = 0;
            this.Open_Word_Text.Text = "Open World";
            this.Open_Word_Text.TrailingIcon = null;
            this.Open_Word_Text.UseTallSize = false;
            this.Open_Word_Text.Leave += new System.EventHandler(this.Open_Word_Text_TabStopChanged);
            // 
            // Upload_to_Drive_Card
            // 
            this.Upload_to_Drive_Card.AutoSize = true;
            this.Upload_to_Drive_Card.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Upload_to_Drive_Card.Controls.Add(this.Sigin_in_Button);
            this.Upload_to_Drive_Card.Controls.Add(this.Note);
            this.Upload_to_Drive_Card.Controls.Add(this.Upload_to_Drive_CheckBox);
            this.Upload_to_Drive_Card.Controls.Add(this.materialLabel1);
            this.Upload_to_Drive_Card.Depth = 0;
            this.Upload_to_Drive_Card.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Upload_to_Drive_Card.Location = new System.Drawing.Point(17, 349);
            this.Upload_to_Drive_Card.Margin = new System.Windows.Forms.Padding(14);
            this.Upload_to_Drive_Card.MouseState = MaterialSkin.MouseState.HOVER;
            this.Upload_to_Drive_Card.Name = "Upload_to_Drive_Card";
            this.Upload_to_Drive_Card.Padding = new System.Windows.Forms.Padding(14);
            this.Upload_to_Drive_Card.Size = new System.Drawing.Size(302, 168);
            this.Upload_to_Drive_Card.TabIndex = 2;
            this.Upload_to_Drive_Card.Visible = false;
            // 
            // Sigin_in_Button
            // 
            this.Sigin_in_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Sigin_in_Button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Sigin_in_Button.Depth = 0;
            this.Sigin_in_Button.DrawShadows = false;
            this.Sigin_in_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sigin_in_Button.HighEmphasis = true;
            this.Sigin_in_Button.Icon = null;
            this.Sigin_in_Button.Location = new System.Drawing.Point(5, 112);
            this.Sigin_in_Button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Sigin_in_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Sigin_in_Button.Name = "Sigin_in_Button";
            this.Sigin_in_Button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Sigin_in_Button.Size = new System.Drawing.Size(270, 36);
            this.Sigin_in_Button.TabIndex = 2;
            this.Sigin_in_Button.Text = "Sign in to your Google Account";
            this.Sigin_in_Button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Sigin_in_Button.UseAccentColor = true;
            this.Sigin_in_Button.UseVisualStyleBackColor = true;
            // 
            // Note
            // 
            this.Note.AutoSize = true;
            this.Note.Depth = 0;
            this.Note.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Note.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.Note.Location = new System.Drawing.Point(6, 92);
            this.Note.MouseState = MaterialSkin.MouseState.HOVER;
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(218, 14);
            this.Note.TabIndex = 1;
            this.Note.Text = "Needs to sign in to your Google Account";
            // 
            // Upload_to_Drive_CheckBox
            // 
            this.Upload_to_Drive_CheckBox.AutoSize = true;
            this.Upload_to_Drive_CheckBox.Depth = 0;
            this.Upload_to_Drive_CheckBox.Location = new System.Drawing.Point(14, 46);
            this.Upload_to_Drive_CheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.Upload_to_Drive_CheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Upload_to_Drive_CheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.Upload_to_Drive_CheckBox.Name = "Upload_to_Drive_CheckBox";
            this.Upload_to_Drive_CheckBox.ReadOnly = false;
            this.Upload_to_Drive_CheckBox.Ripple = true;
            this.Upload_to_Drive_CheckBox.Size = new System.Drawing.Size(167, 37);
            this.Upload_to_Drive_CheckBox.TabIndex = 0;
            this.Upload_to_Drive_CheckBox.Text = "Upload the backup";
            this.Upload_to_Drive_CheckBox.UseVisualStyleBackColor = true;
            this.Upload_to_Drive_CheckBox.CheckedChanged += new System.EventHandler(this.Upload_to_Drive_CheckBox_CheckedChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(68, 10);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(113, 19);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "Upload Settings";
            // 
            // Backup_Button
            // 
            this.Backup_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Backup_Button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Backup_Button.Depth = 0;
            this.Backup_Button.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Backup_Button.HighEmphasis = true;
            this.Backup_Button.Icon = null;
            this.Backup_Button.Location = new System.Drawing.Point(17, 274);
            this.Backup_Button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Backup_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Backup_Button.Name = "Backup_Button";
            this.Backup_Button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Backup_Button.Size = new System.Drawing.Size(116, 36);
            this.Backup_Button.TabIndex = 3;
            this.Backup_Button.Text = "Backup now";
            this.Backup_Button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Backup_Button.UseAccentColor = true;
            this.Backup_Button.UseVisualStyleBackColor = true;
            this.Backup_Button.Click += new System.EventHandler(this.Backup_Button_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(129, 9);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(111, 19);
            this.materialLabel2.TabIndex = 5;
            this.materialLabel2.Text = "Personalization";
            // 
            // Personalization_Card
            // 
            this.Personalization_Card.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Personalization_Card.Controls.Add(this.materialCheckedListBox2);
            this.Personalization_Card.Controls.Add(this.materialCheckedListBox1);
            this.Personalization_Card.Controls.Add(this.materialLabel2);
            this.Personalization_Card.Depth = 0;
            this.Personalization_Card.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Personalization_Card.Location = new System.Drawing.Point(360, 282);
            this.Personalization_Card.Margin = new System.Windows.Forms.Padding(14);
            this.Personalization_Card.MouseState = MaterialSkin.MouseState.HOVER;
            this.Personalization_Card.Name = "Personalization_Card";
            this.Personalization_Card.Padding = new System.Windows.Forms.Padding(14);
            this.Personalization_Card.Size = new System.Drawing.Size(380, 245);
            this.Personalization_Card.TabIndex = 6;
            // 
            // materialCheckedListBox2
            // 
            this.materialCheckedListBox2.AutoScroll = true;
            this.materialCheckedListBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCheckedListBox2.Controls.Add(this.Pink_Button);
            this.materialCheckedListBox2.Controls.Add(this.Red_Button);
            this.materialCheckedListBox2.Controls.Add(this.Default_Button);
            this.materialCheckedListBox2.Controls.Add(this.Green_Button);
            this.materialCheckedListBox2.Controls.Add(this.Dark_mode_switch);
            this.materialCheckedListBox2.Depth = 0;
            this.materialCheckedListBox2.Location = new System.Drawing.Point(17, 36);
            this.materialCheckedListBox2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckedListBox2.Name = "materialCheckedListBox2";
            this.materialCheckedListBox2.Size = new System.Drawing.Size(156, 198);
            this.materialCheckedListBox2.Striped = false;
            this.materialCheckedListBox2.StripeDarkColor = System.Drawing.Color.Empty;
            this.materialCheckedListBox2.TabIndex = 11;
            // 
            // Pink_Button
            // 
            this.Pink_Button.AutoSize = true;
            this.Pink_Button.Depth = 0;
            this.Pink_Button.Location = new System.Drawing.Point(13, 153);
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
            this.Pink_Button.CheckedChanged += new System.EventHandler(this.Pink_Button_CheckedChanged);
            // 
            // Red_Button
            // 
            this.Red_Button.AutoSize = true;
            this.Red_Button.Depth = 0;
            this.Red_Button.Location = new System.Drawing.Point(13, 116);
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
            this.Red_Button.CheckedChanged += new System.EventHandler(this.Red_Button_CheckedChanged);
            // 
            // Default_Button
            // 
            this.Default_Button.AutoSize = true;
            this.Default_Button.Checked = true;
            this.Default_Button.Cursor = System.Windows.Forms.Cursors.Default;
            this.Default_Button.Depth = 0;
            this.Default_Button.Location = new System.Drawing.Point(13, 43);
            this.Default_Button.Margin = new System.Windows.Forms.Padding(0);
            this.Default_Button.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Default_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Default_Button.Name = "Default_Button";
            this.Default_Button.Ripple = true;
            this.Default_Button.Size = new System.Drawing.Size(87, 37);
            this.Default_Button.TabIndex = 1;
            this.Default_Button.TabStop = true;
            this.Default_Button.Text = "Default";
            this.Default_Button.UseVisualStyleBackColor = true;
            this.Default_Button.CheckedChanged += new System.EventHandler(this.Default_Button_CheckedChanged);
            // 
            // Green_Button
            // 
            this.Green_Button.AutoSize = true;
            this.Green_Button.Depth = 0;
            this.Green_Button.Location = new System.Drawing.Point(13, 79);
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
            this.Green_Button.CheckedChanged += new System.EventHandler(this.Green_Button_CheckedChanged);
            // 
            // Dark_mode_switch
            // 
            this.Dark_mode_switch.AutoSize = true;
            this.Dark_mode_switch.Depth = 0;
            this.Dark_mode_switch.Location = new System.Drawing.Point(13, 6);
            this.Dark_mode_switch.Margin = new System.Windows.Forms.Padding(0);
            this.Dark_mode_switch.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Dark_mode_switch.MouseState = MaterialSkin.MouseState.HOVER;
            this.Dark_mode_switch.Name = "Dark_mode_switch";
            this.Dark_mode_switch.Ripple = true;
            this.Dark_mode_switch.Size = new System.Drawing.Size(135, 37);
            this.Dark_mode_switch.TabIndex = 0;
            this.Dark_mode_switch.Text = "Dark Mode";
            this.Dark_mode_switch.UseVisualStyleBackColor = true;
            this.Dark_mode_switch.CheckedChanged += new System.EventHandler(this.Dark_mode_switch_CheckedChanged);
            // 
            // materialCheckedListBox1
            // 
            this.materialCheckedListBox1.AutoScroll = true;
            this.materialCheckedListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCheckedListBox1.Controls.Add(this.Strt_Win);
            this.materialCheckedListBox1.Controls.Add(this.Always_Top);
            this.materialCheckedListBox1.Controls.Add(this.Minimize_Systray);
            this.materialCheckedListBox1.Depth = 0;
            this.materialCheckedListBox1.Location = new System.Drawing.Point(180, 36);
            this.materialCheckedListBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckedListBox1.Name = "materialCheckedListBox1";
            this.materialCheckedListBox1.Size = new System.Drawing.Size(183, 123);
            this.materialCheckedListBox1.Striped = false;
            this.materialCheckedListBox1.StripeDarkColor = System.Drawing.Color.Black;
            this.materialCheckedListBox1.TabIndex = 10;
            // 
            // Strt_Win
            // 
            this.Strt_Win.AutoSize = true;
            this.Strt_Win.Depth = 0;
            this.Strt_Win.Location = new System.Drawing.Point(10, 84);
            this.Strt_Win.Margin = new System.Windows.Forms.Padding(0);
            this.Strt_Win.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Strt_Win.MouseState = MaterialSkin.MouseState.HOVER;
            this.Strt_Win.Name = "Strt_Win";
            this.Strt_Win.ReadOnly = false;
            this.Strt_Win.Ripple = true;
            this.Strt_Win.Size = new System.Drawing.Size(172, 37);
            this.Strt_Win.TabIndex = 8;
            this.Strt_Win.Text = "Start with Windows";
            this.Strt_Win.UseVisualStyleBackColor = true;
            this.Strt_Win.CheckedChanged += new System.EventHandler(this.Strt_Win_CheckedChanged);
            // 
            // Always_Top
            // 
            this.Always_Top.AutoSize = true;
            this.Always_Top.Depth = 0;
            this.Always_Top.Location = new System.Drawing.Point(10, 10);
            this.Always_Top.Margin = new System.Windows.Forms.Padding(0);
            this.Always_Top.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Always_Top.MouseState = MaterialSkin.MouseState.HOVER;
            this.Always_Top.Name = "Always_Top";
            this.Always_Top.ReadOnly = false;
            this.Always_Top.Ripple = true;
            this.Always_Top.Size = new System.Drawing.Size(135, 37);
            this.Always_Top.TabIndex = 7;
            this.Always_Top.Text = "Always on top";
            this.Always_Top.UseVisualStyleBackColor = true;
            this.Always_Top.CheckedChanged += new System.EventHandler(this.Always_Top_CheckedChanged);
            // 
            // Minimize_Systray
            // 
            this.Minimize_Systray.AutoSize = true;
            this.Minimize_Systray.Depth = 0;
            this.Minimize_Systray.Location = new System.Drawing.Point(10, 47);
            this.Minimize_Systray.Margin = new System.Windows.Forms.Padding(0);
            this.Minimize_Systray.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Minimize_Systray.MouseState = MaterialSkin.MouseState.HOVER;
            this.Minimize_Systray.Name = "Minimize_Systray";
            this.Minimize_Systray.ReadOnly = false;
            this.Minimize_Systray.Ripple = true;
            this.Minimize_Systray.Size = new System.Drawing.Size(149, 37);
            this.Minimize_Systray.TabIndex = 5;
            this.Minimize_Systray.Text = "minimize to tray";
            this.Minimize_Systray.UseVisualStyleBackColor = true;
            // 
            // notify_tray
            // 
            this.notify_tray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notify_tray.BalloonTipText = "The app is minimize to System tray";
            this.notify_tray.BalloonTipTitle = "Sky Cloud Backup";
            this.notify_tray.ContextMenuStrip = this.Tray_Menu;
            this.notify_tray.Icon = ((System.Drawing.Icon)(resources.GetObject("notify_tray.Icon")));
            this.notify_tray.Text = "Sky Cloud Backup";
            this.notify_tray.BalloonTipClicked += new System.EventHandler(this.notify_tray_BalloonTipClicked);
            this.notify_tray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notify_tray_MouseDoubleClick);
            // 
            // Tray_Menu
            // 
            this.Tray_Menu.DropShadowEnabled = false;
            this.Tray_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.Tray_Menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.Tray_Menu.Name = "Tray_Menu";
            this.Tray_Menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Tray_Menu.Size = new System.Drawing.Size(114, 92);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.closeToolStripMenuItem.Text = "Exit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // Edtitions
            // 
            this.Edtitions.AutoSize = true;
            this.Edtitions.Depth = 0;
            this.Edtitions.Location = new System.Drawing.Point(231, 273);
            this.Edtitions.Margin = new System.Windows.Forms.Padding(0);
            this.Edtitions.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Edtitions.MouseState = MaterialSkin.MouseState.HOVER;
            this.Edtitions.Name = "Edtitions";
            this.Edtitions.Ripple = true;
            this.Edtitions.Size = new System.Drawing.Size(115, 37);
            this.Edtitions.TabIndex = 7;
            this.Edtitions.Text = "Bedrock";
            this.Edtitions.UseVisualStyleBackColor = true;
            this.Edtitions.CheckedChanged += new System.EventHandler(this.Edtitions_CheckedChanged);
            // 
            // Help_Button
            // 
            this.Help_Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Help_Button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Help_Button.Depth = 0;
            this.Help_Button.DrawShadows = false;
            this.Help_Button.HighEmphasis = true;
            this.Help_Button.Icon = global::Sky_Cloud_Backup.Properties.Resources.sharp_question_mark_white_24dp;
            this.Help_Button.Location = new System.Drawing.Point(141, 274);
            this.Help_Button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Help_Button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Help_Button.Name = "Help_Button";
            this.Help_Button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Help_Button.Size = new System.Drawing.Size(86, 36);
            this.Help_Button.TabIndex = 1;
            this.Help_Button.Text = "Help";
            this.Help_Button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Help_Button.UseAccentColor = true;
            this.Help_Button.UseVisualStyleBackColor = true;
            this.Help_Button.Click += new System.EventHandler(this.Help_Button_Click);
            // 
            // Main_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(757, 530);
            this.Controls.Add(this.Edtitions);
            this.Controls.Add(this.Personalization_Card);
            this.Controls.Add(this.Help_Button);
            this.Controls.Add(this.Backup_Button);
            this.Controls.Add(this.Upload_to_Drive_Card);
            this.Controls.Add(this.Open_World_Card);
            this.DrawerBackgroundWithAccent = true;
            this.DrawerIsOpen = true;
            this.DrawerUseColors = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main_Screen";
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Sky Cloud Backup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Screen_FormClosing);
            this.Load += new System.EventHandler(this.Main_Screen_Load);
            this.Resize += new System.EventHandler(this.Main_Screen_Resize);
            this.Open_World_Card.ResumeLayout(false);
            this.Open_World_Card.PerformLayout();
            this.Upload_to_Drive_Card.ResumeLayout(false);
            this.Upload_to_Drive_Card.PerformLayout();
            this.Personalization_Card.ResumeLayout(false);
            this.Personalization_Card.PerformLayout();
            this.materialCheckedListBox2.ResumeLayout(false);
            this.materialCheckedListBox2.PerformLayout();
            this.materialCheckedListBox1.ResumeLayout(false);
            this.materialCheckedListBox1.PerformLayout();
            this.Tray_Menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton Help_Button;
        private MaterialSkin.Controls.MaterialButton Backup_Button;
        private MaterialSkin.Controls.MaterialCard Upload_to_Drive_Card;
        private MaterialSkin.Controls.MaterialButton Sigin_in_Button;
        private MaterialSkin.Controls.MaterialLabel Note;
        private MaterialSkin.Controls.MaterialCheckbox Upload_to_Drive_CheckBox;
        private MaterialSkin.Controls.MaterialButton Save_World_Button;
        private MaterialSkin.Controls.MaterialTextBox Save_World_TextBox;
        private MaterialSkin.Controls.MaterialCard Open_World_Card;
        private MaterialSkin.Controls.MaterialButton Open_World_Button;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialCard Personalization_Card;
        private MaterialSkin.Controls.MaterialSwitch Dark_mode_switch;
        private MaterialSkin.Controls.MaterialRadioButton Red_Button;
        private MaterialSkin.Controls.MaterialRadioButton Pink_Button;
        private MaterialSkin.Controls.MaterialRadioButton Green_Button;
        private MaterialSkin.Controls.MaterialRadioButton Default_Button;
        private System.Windows.Forms.FolderBrowserDialog Open_World;
        private System.Windows.Forms.FolderBrowserDialog Save_World;
        private MaterialSkin.Controls.MaterialTextBox Open_Word_Text;
        private MaterialSkin.Controls.MaterialCheckbox Always_Top;
        private MaterialSkin.Controls.MaterialCheckbox Minimize_Systray;
        private System.Windows.Forms.NotifyIcon notify_tray;
        private MaterialSkin.Controls.MaterialSwitch Edtitions;
        private System.Windows.Forms.ContextMenuStrip Tray_Menu;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private MaterialSkin.Controls.MaterialCheckbox Strt_Win;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private MaterialSkin.Controls.MaterialCheckedListBox materialCheckedListBox1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private MaterialSkin.Controls.MaterialCheckedListBox materialCheckedListBox2;
    }
}