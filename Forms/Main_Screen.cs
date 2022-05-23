using MaterialSkin;
using MaterialSkin.Controls;
using Sky_Cloud_Backup.assets;
using Sky_Cloud_Backup.assets.Backup;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Sky_Cloud_Backup
{
    public partial class Main_Screen: MaterialForm
    {


        public Main_Screen ()
        {
            InitializeComponent();
            Chk_atstarp_Backup();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.AddFormToManage(new Help());
            materialSkinManager.AddFormToManage(new About());
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue400, Accent.Cyan700, TextShade.WHITE);
            Sigin_in_Button.Enabled = false;
            string folderName = "Temp";
            string pathString = Path.Combine(folderName, "");
            System.IO.Directory.CreateDirectory(pathString);
            Backup_Button.Enabled = false;
            Chk_Default_name();
        }

        strtup stup = new strtup();
        gle_div gle_div = new gle_div();
        Main_Backup_Bedrock bedrock = new Main_Backup_Bedrock();
        Main_Backup_Java java = new Main_Backup_Java();
        Error GetError = new Error();

        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;
        private void Upload_to_Drive_CheckBox_CheckedChanged ( object sender, EventArgs e )
        {
            if (Upload_to_Drive_CheckBox.Checked)
            {
                Save_World_TextBox.Enabled = false;
                Save_World_Button.Enabled = false;
                Sigin_in_Button.Enabled = true;
                Chk_txtbx_fld_Op();
            }
            else
            {
                Save_World_TextBox.Enabled = true;
                Save_World_Button.Enabled = true;
                Sigin_in_Button.Enabled = false;
                Chk_atstarp_Backup();
            }
            Properties.Settings.Default.Upload_To_Drive = Upload_to_Drive_CheckBox.Checked;
            Properties.Settings.Default.Save();

        }


        public void Chk_Default_name ()
        {
            MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;
            if (Deafualt_Backup_name.Checked)
            {
                Backup_name_for.Hide();
                Backup_Name.Hide();
            }
            else
            {
                Backup_name_for.Show();
                Backup_Name.Show();
            }
        }

        public void Chk_Reset ()
        {
            if (Properties.Settings.Default.Reset == true)
            {
                MaterialDialog Reset = new MaterialDialog(this, "Sky Cloud Backup", "Reset Complete", "OK", true, "Cancel", true);
                Reset.ShowDialog(this);
                Properties.Settings.Default.Reset = false;
                Properties.Settings.Default.Save();
            }
        }

        public void Minto_strt ()
        {
            if (Strt_Win.Checked)
            {
                notify_tray.BalloonTipTitle = " The app is in System tray";
                notify_tray.BalloonTipText = "To disable the app from starting, uncheck Start with Windows checkbox";
                notify_tray.Visible = true;
                notify_tray.ShowBalloonTip(500);
                Hide();
                ShowInTaskbar = false;
            }
        }

        public void Nofrm_strt ()
        {
            Show();
            notify_tray.Visible = false;
            ShowInTaskbar = true;
            Activate();
        }

        public void Chk_txtbx_fld_Op ()
        {
            if (!string.IsNullOrEmpty(Open_Word_Text.Text))
            {
                Backup_Button.Enabled = true;
            }
            else
            {
                Backup_Button.Enabled = false;
            }
        }

        public void Chk_atstarp_Backup ()
        {
            if (!string.IsNullOrEmpty(Open_Word_Text.Text))
            {
                Upload_to_Drive_CheckBox.Enabled = true;
                if (!string.IsNullOrEmpty(Save_World_TextBox.Text))
                {
                    Backup_Button.Enabled = true;
                }
                else
                {
                    Backup_Button.Enabled = false;
                }
            }
            else
            {
                Backup_Button.Enabled = false;
            }
        }

        private void Open_World_Button_Click ( object sender, EventArgs e )
        {
            if (Open_World.ShowDialog() == DialogResult.OK)
            {
                Open_Word_Text.Text = Open_World.SelectedPath;
                Chk_atstarp_Backup();
                Properties.Settings.Default.World_Location = Open_Word_Text.Text;
                Properties.Settings.Default.Save();
            }

        }

        private void Save_World_Button_Click ( object sender, EventArgs e )
        {
            if (Save_World.ShowDialog() == DialogResult.OK)
            {
                Save_World_TextBox.Text = Save_World.SelectedPath;
                Chk_atstarp_Backup();
                Properties.Settings.Default.Save_Location = Save_World_TextBox.Text;
                Properties.Settings.Default.Save();
            }

        }

        private void Dark_mode_switch_CheckedChanged ( object sender, EventArgs e )
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
            Properties.Settings.Default.Mode = Dark_mode_switch.Checked;
            Properties.Settings.Default.Save();
            if (Dark_mode_switch.Checked)
            {
                Dark_mode_switch.Text = "Dark Mode";
            }
            else
            {
                Dark_mode_switch.Text = "Light Mode";
            }
        }



        private void Backup_Button_Click ( object sender, EventArgs e )
        {
            if (Open_Word_Text.Text.Length == 0)
            {
                this.ShowInTaskbar = true;
                notify_tray.Visible = false;
                this.Show();
                string Error_txt = "The Textbox is empty";
                GetError.Dialog_error(Error_txt);
                this.Hide();
                notify_tray.Visible = true;
                this.ShowInTaskbar = false;
            }
            else
            {
                if (Sigin_in_Button.Enabled == false)
                {
                    Backup_Button.Enabled = false;
                    if (Edtitions.Checked)
                    {
                        java.Main_Java_Backup();
                    }
                    else
                    {
                        bedrock.Main_Bedrock_Backup();
                    }
                    Backup_Button.Enabled = true;
                }
            }
        }
        /////////////////////////////////////Color Schemes///////////////////////////////////////////////////////////////////////

        About about = new About();
        Help help = new Help();

        private void Default_Button_CheckedChanged ( object sender, EventArgs e )
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue400, Accent.Cyan700, TextShade.WHITE);
            Invalidate();
            Refresh();
            help.Refresh();
            about.Refresh();
        }

        private void Green_Button_CheckedChanged ( object sender, EventArgs e )
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.LightGreen400, TextShade.BLACK);
            Invalidate();
            Refresh();
            help.Refresh();
            about.Refresh();
        }

        private void Pink_Button_CheckedChanged ( object sender, EventArgs e )
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Pink800, Primary.Pink900, Primary.Pink500, Accent.Pink200, TextShade.BLACK);
            Invalidate();
            Refresh();
            help.Refresh();
            about.Refresh();
        }

        private void Red_Button_CheckedChanged ( object sender, EventArgs e )
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Red800, Primary.Red900, Primary.Red500, Accent.Red200, TextShade.BLACK);
            Invalidate();
            Refresh();
            help.Refresh();
            about.Refresh();
        }

        private void Amber_Button_CheckedChanged ( object sender, EventArgs e )
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Amber800, Primary.Amber900, Primary.Amber500, Accent.Amber200, TextShade.BLACK);
            Invalidate();
            Refresh();
            help.Refresh();
            about.Refresh();
        }

        private void Orange_Button_CheckedChanged ( object sender, EventArgs e )
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Orange800, Primary.Orange900, Primary.Orange500, Accent.Orange200, TextShade.BLACK);
            Invalidate();
            Refresh();
            help.Refresh();
            about.Refresh();
        }

        private void Deep_Purple_Button_CheckedChanged ( object sender, EventArgs e )
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.DeepPurple800, Primary.DeepPurple900, Primary.DeepPurple500, Accent.DeepPurple200, TextShade.BLACK);
            Invalidate();
            Refresh();
            help.Refresh();
            about.Refresh();
        }

        private void Always_Top_CheckedChanged ( object sender, EventArgs e )
        {
            if (Always_Top.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }
        /////////////////////////////////////Saves///////////////////////////////////////////////////////////////////////
        private void Main_Screen_FormClosing ( object sender, FormClosingEventArgs e )
        {
            Properties.Settings.Default.Default_Color = Default_Button.Checked;
            Properties.Settings.Default.Green = Green_Button.Checked;
            Properties.Settings.Default.Pink = Pink_Button.Checked;
            Properties.Settings.Default.Red = Red_Button.Checked;
            Properties.Settings.Default.Amber = Amber_Button.Checked;
            Properties.Settings.Default.Orange = Orange_Button.Checked;
            Properties.Settings.Default.Deep_Purple = Deep_Purple_Button.Checked;
            Properties.Settings.Default.Upload_To_Drive = Upload_to_Drive_CheckBox.Checked;
            Properties.Settings.Default.World_Location = Open_Word_Text.Text;
            Properties.Settings.Default.Save_Location = Save_World_TextBox.Text;
            Properties.Settings.Default.Always_on_top = Always_Top.Checked;
            Properties.Settings.Default.Minimize_to_Form = Minimize_Systray.Checked;
            Properties.Settings.Default.Editions = Edtitions.Checked;
            Properties.Settings.Default.strtwin = Strt_Win.Checked;
            Properties.Settings.Default.Chk_zip_mcowrld = zip_mcworld.Checked;
            Properties.Settings.Default.Defualt_name_textbox = Backup_Name.Text;
            Properties.Settings.Default.Defualt_name_chkbx = Deafualt_Backup_name.Checked;
            Properties.Settings.Default.Backup_name_for = Backup_name_for.Checked;
            Properties.Settings.Default.Save();
            Application.Exit();
        }
        public void Main_Screen_Load ( object sender, EventArgs e )
        {
            Dark_mode_switch.Checked = Properties.Settings.Default.Mode;
            Default_Button.Checked = Properties.Settings.Default.Default_Color;
            Green_Button.Checked = Properties.Settings.Default.Green;
            Pink_Button.Checked = Properties.Settings.Default.Pink;
            Red_Button.Checked = Properties.Settings.Default.Red;
            Amber_Button.Checked = Properties.Settings.Default.Amber;
            Orange_Button.Checked = Properties.Settings.Default.Orange;
            Deep_Purple_Button.Checked = Properties.Settings.Default.Deep_Purple;
            Upload_to_Drive_CheckBox.Checked = Properties.Settings.Default.Upload_To_Drive;
            Open_Word_Text.Text = Properties.Settings.Default.World_Location;
            Save_World_TextBox.Text = Properties.Settings.Default.Save_Location;
            Always_Top.Checked = Properties.Settings.Default.Always_on_top;
            Minimize_Systray.Checked = Properties.Settings.Default.Minimize_to_Form;
            Edtitions.Checked = Properties.Settings.Default.Editions;
            Strt_Win.Checked = Properties.Settings.Default.strtwin;
            zip_mcworld.Checked = Properties.Settings.Default.Chk_zip_mcowrld;
            Backup_Name.Text = Properties.Settings.Default.Defualt_name_textbox;
            Deafualt_Backup_name.Checked = Properties.Settings.Default.Defualt_name_chkbx;
            Backup_name_for.Checked = Properties.Settings.Default.Backup_name_for;
            Minto_strt();
            Chk_atstarp_Backup();
            Chk_Reset();

        }


        /////////////////////////////////////Resize to form///////////////////////////////////////////////////////////////////////

        private void Main_Screen_Resize ( object sender, EventArgs e )
        {
            if (Minimize_Systray.Checked)
            {
                notify_tray.BalloonTipTitle = " The app is minimize to Tray.";
                notify_tray.BalloonTipText = "To maximize the app, double click the icon.";

                if (FormWindowState.Minimized == this.WindowState)
                {
                    if (Minimize_Systray.Checked)
                    {
                        notify_tray.Visible = true;
                        notify_tray.ShowBalloonTip(500);
                        this.Hide();
                    }
                }
                else if (FormWindowState.Normal == this.WindowState)
                {
                    notify_tray.Visible = false;
                }
            }
        }

        private void notify_tray_MouseDoubleClick ( object sender, MouseEventArgs e )
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notify_tray.Visible = false;
            this.ShowInTaskbar = true;
            if (Strt_Win.Checked)
            {
                Nofrm_strt();
            }
        }

        private void Edtitions_CheckedChanged ( object sender, EventArgs e )
        {
            if (Edtitions.Checked)
            {
                Edtitions.Text = "Java";
                Backup_name_for.Checked = true;
            }
            else
            {
                Edtitions.Text = "Bedrock";
                Backup_name_for.Checked = false;
            }
        }

        /////////////////////////////////////ToolStrip///////////////////////////////////////////////////////////////////////
        private void closeToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            this.Show();
            this.ShowInTaskbar = true;
            notify_tray.Visible = false;
            if (Strt_Win.Checked)
            {
                Nofrm_strt();
            }
        }

        private void helpToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            if (Application.OpenForms.OfType<Help>().Any())
            {
                Help frm = new Help();
                frm.Hide();
                frm.Activate();
            }
            else
            {
                Help frm = new Help();
                frm.Show();
                frm.Activate();
            }
        }

        private void backupToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            if (Open_Word_Text.Text.Length == 0)
            {
                string Error_txt = "The Textbox is empty";
                GetError.Dialog_error(Error_txt);
            }
            else
            {
                if (Sigin_in_Button.Enabled == false)
                {
                    Backup_Button.Enabled = false;
                    if (Edtitions.Checked)
                    {
                        java.Main_Java_Backup();
                    }
                    else
                    {
                        bedrock.Main_Bedrock_Backup();
                    }
                    Backup_Button.Enabled = true;
                }
            }
        }

        private void aboutToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            if (Application.OpenForms.OfType<About>().Any())
            {
                About frm = new About();
                frm.Hide();
                frm.Activate();
            }
            else
            {
                About frm = new About();
                frm.Show();
                frm.Activate();
            }
        }

        private void Help_Button_Click ( object sender, EventArgs e )
        {
            if (Application.OpenForms.OfType<Help>().Any())
            {
                Help frm = new Help();
                frm.Hide();
                frm.Activate();
            }
            else
            {
                Help frm = new Help();
                frm.Show();
                frm.Activate();
            }
        }

        private void Strt_Win_CheckedChanged ( object sender, EventArgs e )
        {
            if (Strt_Win.Checked)
            {
                stup.CreateStartupFolderShortcut();
            }
            else
            {
                string targetExeName = "Sky Cloud Backup.exe";
                stup.DeleteStartupFolderShortcuts(targetExeName);
            }
        }

        private void Open_Word_Text_TabStopChanged ( object sender, EventArgs e )
        {
            Chk_atstarp_Backup();
        }

        private void Save_World_TextBox_TabStopChanged ( object sender, EventArgs e )
        {
            Chk_atstarp_Backup();
        }

        private void About_Button_Click ( object sender, EventArgs e )
        {
            if (Application.OpenForms.OfType<About>().Any())
            {
                About frm = new About();
                frm.Hide();
                frm.Activate();
            }
            else
            {
                About frm = new About();
                frm.Show();
                frm.Activate();
            }
        }

        private void materialButton1_Click ( object sender, EventArgs e )
        {
            MaterialDialog Reset = new MaterialDialog(this, "Sky Cloud Backup", "Are you sure that you are Reseting this app", "OK", true, "Never mind", true);
            DialogResult result = Reset.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                if (Properties.Settings.Default.Dev_Mode == true)
                {
                    MaterialDialog Dev_reset = new MaterialDialog(this, "Sky Cloud Backup", "hard Reset(OK), Reset(Cancel) ", "OK", true, "Cancel", true);
                    DialogResult Dev_result = Dev_reset.ShowDialog(this);
                    if (Dev_result == DialogResult.Cancel)
                    {
                        this.Hide();
                        Dark_mode_switch.Checked = false;
                        Default_Button.Checked = true;
                        Green_Button.Checked = false;
                        Pink_Button.Checked = false;
                        Red_Button.Checked = false;
                        Upload_to_Drive_CheckBox.Checked = false;
                        Open_Word_Text.Clear();
                        Save_World_TextBox.Clear();
                        Always_Top.Checked = false;
                        Minimize_Systray.Checked = false;
                        Edtitions.Checked = false;
                        Strt_Win.Checked = false;
                        Properties.Settings.Default.Reset = true;
                        Properties.Settings.Default.first_strtup = false;
                        zip_mcworld.Checked = false;
                        Backup_Name.Clear();
                        Deafualt_Backup_name.Checked = true;
                        Backup_name_for.Checked = false;
                        Properties.Settings.Default.Save();
                        this.Show();
                        Application.Restart();
                    }
                    if (Dev_result == DialogResult.OK)
                    {
                        this.Hide();
                        Dark_mode_switch.Checked = false;
                        Default_Button.Checked = true;
                        Green_Button.Checked = false;
                        Pink_Button.Checked = false;
                        Red_Button.Checked = false;
                        Upload_to_Drive_CheckBox.Checked = false;
                        Open_Word_Text.Clear();
                        Save_World_TextBox.Clear();
                        Always_Top.Checked = false;
                        Minimize_Systray.Checked = false;
                        Edtitions.Checked = false;
                        Strt_Win.Checked = false;
                        Properties.Settings.Default.first_strtup = false;
                        zip_mcworld.Checked = false;
                        Backup_Name.Clear();
                        Deafualt_Backup_name.Checked = true;
                        Backup_name_for.Checked = false;
                        Properties.Settings.Default.Save();
                        this.Show();
                        Application.Restart();
                    }
                }
                else
                {
                    this.Hide();
                    Dark_mode_switch.Checked = false;
                    Default_Button.Checked = true;
                    Green_Button.Checked = false;
                    Pink_Button.Checked = false;
                    Red_Button.Checked = false;
                    Upload_to_Drive_CheckBox.Checked = false;
                    Open_Word_Text.Clear();
                    Save_World_TextBox.Clear();
                    Always_Top.Checked = false;
                    Minimize_Systray.Checked = false;
                    Edtitions.Checked = false;
                    Strt_Win.Checked = false;
                    Properties.Settings.Default.Reset = true;
                    Properties.Settings.Default.first_strtup = false;
                    zip_mcworld.Checked = false;
                    Backup_Name.Clear();
                    Deafualt_Backup_name.Checked = true;
                    Backup_name_for.Checked = false;
                    Properties.Settings.Default.Save();
                    this.Show();
                    Application.Restart();
                }
            }
        }

        private void Sigin_in_Button_Click ( object sender, EventArgs e )
        {
            System.Diagnostics.Process.Start("https://involts.github.io/Sky-Cloud-Backup/Development/");
            //MaterialDialog Com = new MaterialDialog(this, "Sky Cloud Backup", "Are you sure that you Continue to sign in to google drive, Google didn't verifed by Google", "OK", true, "Never mind", true);
            //DialogResult result = Com.ShowDialog(this);
            // if (result == DialogResult.OK)
            // {
            //     gle_div.GetUserCredential();
            // }
        }

        private void zip_mcworld_CheckedChanged ( object sender, EventArgs e )
        {
            if (zip_mcworld.Checked)
            {
                zip_mcworld.Text = "Zip";
            }
            else
            {
                zip_mcworld.Text = "Mcworld";
            }
        }

        private void Deafualt_Backup_name_CheckedChanged ( object sender, EventArgs e )
        {
            if (Deafualt_Backup_name.Checked)
            {
                Backup_name_for.Hide();
                Backup_Name.Hide();
            }
            else
            {
                Backup_name_for.Show();
                Backup_Name.Show();
            }
        }

        private void Backup_name_for_CheckedChanged ( object sender, EventArgs e )
        {
            if (Backup_name_for.Checked)
            {
                Backup_name_for.Text = "for Java";
            }
            else
            {
                Backup_name_for.Text = "for Bedrock";
            }
        }

    }
}

