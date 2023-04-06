using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using Sky_Cloud_Backup.assets;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static Google.Apis.Drive.v3.DriveService;

namespace Sky_Cloud_Backup
{
    public partial class Main_Screen : MaterialForm
    {


        public Main_Screen()
        {
            InitializeComponent();
            this.Shown += new System.EventHandler(this.Main_Screen_Shown);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.AddFormToManage(new Help());
            materialSkinManager.AddFormToManage(new About());
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue400, Accent.Cyan700, TextShade.WHITE);
            Sigin_in_Button.Enabled = false;
            Backup_Button.Enabled = false;
            Check_atstartup_Backup();
            Check_Custom_Name();
            Check_signin();
        }


        private static readonly Startup stup = new Startup();
        private static readonly Additonal add = new Additonal();
        google_drive google_drive = new google_drive();

        /// <summary>
        /// Global Strings
        /// </summary>
        public static string environment = Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData);
        public static string file_path = @"Sky Cloud Backup/Google.Apis.Auth.OAuth2.Responses.TokenResponse-User";
        public static string Authlocation = Path.Combine(environment, file_path);
        public string TimeFormat = DateTime.Now.ToString(" dddd, dd MMMM yyyy h-mm-tt ").ToString(CultureInfo.InvariantCulture);

        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;

        //
        // Main Screen Funtion Manager
        //
        private void Main_Screen_Resize(object sender, EventArgs e)
        {
            if (Minimize_Systray.Checked)
            {
                Notification_Informer.BalloonTipTitle = " The app is minimize to Tray.";
                Notification_Informer.BalloonTipText = "To maximize the app, double click the icon.";

                if (FormWindowState.Minimized == this.WindowState)
                {
                    if (Minimize_Systray.Checked)
                    {
                        Notification_Informer.Visible = true;
                        Notification_Informer.ShowBalloonTip(500);
                        this.Hide();
                    }
                }
                else if (FormWindowState.Normal == this.WindowState)
                {
                    Notification_Informer.Visible = false;
                }
            }
        }

        private void Main_Screen_Shown(object sender, EventArgs e)
        {
            Check_Reset();
        }

        private void Main_Screen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.GlobalReset == false)
            {
                Jsonload_comp();
                Application.Exit();
            }
        }

        public void Main_Screen_Load(object sender, EventArgs e)
        {
            if (!File.Exists(@"settings.json"))
            {
                File.Create(@"settings.json");
                return;
            }
            using (StreamReader r = new StreamReader(@"settings.json"))
            {
                string json = r.ReadToEnd();
                setsetting account = JsonConvert.DeserializeObject<setsetting>(json);
                Dark_mode_switch.Checked = account.Mode;
                Default_Button.Checked = account.Default_Color;
                Green_Button.Checked = account.Green;
                Pink_Button.Checked = account.Pink;
                Red_Button.Checked = account.Red;
                Amber_Button.Checked = account.Amber;
                Orange_Button.Checked = account.Orange;
                Deep_Purple_Button.Checked = account.Deep_Purple;
                Upload_to_Drive_CheckBox.Checked = account.Upload_To_Drive;
                Open_Word_Text.Text = account.World_Location;
                Save_World_TextBox.Text = account.Save_Location;
                Always_Top.Checked = account.Always_on_top;
                Minimize_Systray.Checked = account.Minimize_to_Form;
                Edtitions.Checked = account.Editions;
                Strt_Win.Checked = account.strtwin;
                zip_mcworld.Checked = account.Chk_zip_mcowrld;
                Backup_Name.Text = account.Defualt_name_textbox;
                Custom_name.Checked = account.Defualt_name_chkbx;
                Backup_name_for.Checked = account.Backup_name_for;
                automaticsave.Checked = account.AutoSave;
                Properties.Settings.Default.Dev_Mode = account.DeveloperMode;
                Properties.Settings.Default.GlobalReset = account.Reset;
                BackupDailog_Checkbox.Checked = account.backupdialog;
            }
            Minimizeto_start();
            Check_signin();
            Check_atstartup_Backup();

        }

        private void Jsonload_comp()
        {
            setsetting sjs = new setsetting()
            {
                Mode = Dark_mode_switch.Checked,
                Default_Color = Default_Button.Checked,
                Green = Green_Button.Checked,
                Pink = Pink_Button.Checked,
                Red = Red_Button.Checked,
                Amber = Amber_Button.Checked,
                Orange = Orange_Button.Checked,
                Deep_Purple = Deep_Purple_Button.Checked,
                Upload_To_Drive = Upload_to_Drive_CheckBox.Checked,
                World_Location = Open_Word_Text.Text,
                Save_Location = Save_World_TextBox.Text,
                Always_on_top = Always_Top.Checked,
                Minimize_to_Form = Minimize_Systray.Checked,
                Editions = Edtitions.Checked,
                strtwin = Strt_Win.Checked,
                Chk_zip_mcowrld = zip_mcworld.Checked,
                Defualt_name_textbox = Backup_Name.Text,
                Defualt_name_chkbx = Custom_name.Checked,
                Backup_name_for = Backup_name_for.Checked,
                AutoSave = automaticsave.Checked,
                DeveloperMode = Properties.Settings.Default.Dev_Mode,
                Reset = Properties.Settings.Default.GlobalReset,
                FirstRun = Properties.Settings.Default.first_strtup,
                backupdialog = BackupDailog_Checkbox.Checked,

            };
            Properties.Settings.Default.Save();
            string stringjson = JsonConvert.SerializeObject(sjs);
            File.WriteAllText(@"settings.json", stringjson);
        }
        //
        // Check SCB stats
        //
        public void Check_Custom_Name()
        {
            if (!Custom_name.Checked)
            {
                Backup_name_for.Enabled = false;
                Backup_Name.Enabled = false;
            }
            else
            {
                Backup_name_for.Enabled = true;
                Backup_Name.Enabled = true;
            }
        }

        public void Check_Reset()
        {
            if (Properties.Settings.Default.GlobalReset == true)
            {
                MaterialDialog Reset = new MaterialDialog(this, "Reset", "Reset Complete", "OK", true, "Cancel", true);
                Reset.ShowDialog(this);
                Properties.Settings.Default.GlobalReset = false;
                Properties.Settings.Default.Save();
            }
        }

        public void Minimizeto_start()
        {
            if (Strt_Win.Checked)
            {
                Notification_Informer.BalloonTipTitle = " The App is in System tray";
                Notification_Informer.BalloonTipText = "To disable the app from starting, uncheck Start with Windows checkbox";
                Notification_Informer.Visible = true;
                Notification_Informer.ShowBalloonTip(500);
                Hide();
                ShowInTaskbar = false;
            }
        }

        public void Noform_start()
        {
            Show();
            Notification_Informer.Visible = false;
            ShowInTaskbar = true;
            Activate();
        }

        public void Check_textbox_field_Open()
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

        public void Check_atstartup_Backup()
        {
            if (string.IsNullOrEmpty(Open_Word_Text.Text))
            {
                Backup_Button.Enabled = false;
                return;
            }
            if (Upload_to_Drive_CheckBox.Checked)
            {
                Backup_Button.Enabled = true;
                return;
            }
            else if (string.IsNullOrEmpty(Save_World_TextBox.Text))
            {
                Backup_Button.Enabled = false;
                return;
            }
            Backup_Button.Enabled = true;
        }

        public void Check_signin()
        {
            if (Upload_to_Drive_CheckBox.Checked)
            {
                sign_out_button.Enabled = true;
                Sigin_in_Button.Enabled = false;
            }
            else
            {
                sign_out_button.Enabled = false;
                Sigin_in_Button.Enabled = true;
            }
            if (File.Exists(Authlocation))
            {
                sign_out_button.Enabled = true;
                sign_out_button.HighEmphasis = true;
                Sigin_in_Button.HighEmphasis = false;
                Sigin_in_Button.Enabled = false;
            }
            else
            {
                sign_out_button.Enabled = false;
                sign_out_button.HighEmphasis = false;
                Sigin_in_Button.HighEmphasis = true;
                Sigin_in_Button.Enabled = true;
            }
        }

        private void Open_World_Button_Click(object sender, EventArgs e)
        {
            if (Open_World.ShowDialog() == DialogResult.OK)
            {
                Open_Word_Text.Text = Open_World.SelectedPath;
                Check_atstartup_Backup();
                Properties.Settings.Default.World_Location = Open_Word_Text.Text;
                Properties.Settings.Default.Save();
            }

        }

        private void Save_World_Button_Click(object sender, EventArgs e)
        {
            if (Save_World.ShowDialog() == DialogResult.OK)
            {
                Save_World_TextBox.Text = Save_World.SelectedPath;
                Check_atstartup_Backup();
                Properties.Settings.Default.Save_Location = Save_World_TextBox.Text;
                Properties.Settings.Default.Save();
            }

        }

        private void Dark_mode_switch_CheckedChanged(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
            if (Dark_mode_switch.Checked)
            {
                Dark_mode_switch.Text = "Dark Mode";
            }
            else
            {
                Dark_mode_switch.Text = "Light Mode";
            }
        }


        /// <summary>
        ///  Backup
        /// </summary>
        UserCredential credential;
        private void Backup_Button_Click(object sender, EventArgs e)
        {
            if (Open_Word_Text.Text.Length == 0)
            {
                string Error_txt = "The Textbox is empty";
                if (Minimize_Systray.Checked)
                {
                    Notification_Informer.Visible = false;
                    ShowInTaskbar = true;
                    Show();
                    Activate();
                    Dialog_error(Error_txt);
                    Notification_Informer.Visible = true;
                    ShowInTaskbar = false;
                }
                else
                {
                    Dialog_error(Error_txt);
                }
            }
            else
            {
                if (!Upload_to_Drive_CheckBox.Checked)
                {
                    Backup_Button.Enabled = false;
                    if (Edtitions.Checked)
                    {
                        Check_World_Java();
                    }
                    else
                    {
                        Check_World_Bedrock();
                    }
                    Backup_Button.Enabled = true;
                }
                else
                {
                    Uploadtodrve();
                }
            }
        }

        private void Sign_in_Button_Click(object sender, EventArgs e)
        {

            if (!File.Exists(Authlocation))
            {
                MaterialDialog Com = new MaterialDialog(this, "Sign In", "Are you sure that you Continue to sign in to Google Drive, This isn't verified", "OK", true, "Cancel", true);
                DialogResult result = Com.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    google_drive.GetUserCredential();
                    Check_signin();
                }
            }
            // System.Diagnostics.Process.Start("https://involts.github.io/Sky-Cloud-Backup/Development/");

        }
        private void Sign_out_btn_Click(object sender, EventArgs e)
        {
            if (File.Exists(Authlocation))
            {
                MaterialDialog Com = new MaterialDialog(this, "Sign Out", "Are you sure that you want sign out to Google Drive", "OK", true, "Cancel", true);
                DialogResult result = Com.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    File.Delete(Authlocation);
                    Check_signin();
                }
            }
        }

        private void Uploadtodrve()
        {
            Save_World_TextBox.Text = @"upload";
            if (Edtitions.Checked)
            {
                Check_World_Java();
                foreach (var filename in Directory.GetFiles(@"upload"))
                {
                    var newFilename = string.Format("{0}.zip", "Backup Java world");
                    var newFullFilename = Path.Combine(@"upload", newFilename);
                    File.Move(filename, newFullFilename);
                }

                credential = google_drive.GetUserCredential();

                DriveService service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Sky Cloud Backup",
                });

                google_drive.Upload_to_Drive(service, "Backup Java world" + DateTime.Now.ToString("dddd, dd MMMM yyyy"), @"upload");
                Dailog_Manager("true", true);
            }
            else
            {
                Check_World_Bedrock();
                Dailog_Manager("true", false);
                string name = "Backup Bedrock world";
                foreach (var filename in Directory.GetFiles(@"upload"))
                {
                    var newFilename = string.Format("{0}.zip", name);
                    var newFullFilename = Path.Combine(@"upload", newFilename);
                    File.Move(filename, newFullFilename);
                }

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Sky Cloud Backup",
                });

                google_drive.Upload_to_Drive(service, "Backup Bedrock world " + DateTime.Now.ToString("dddd, dd MMMM yyyy"), @"upload/Backup Bedrock world.zip");
                Dailog_Manager("true", true);

            }
            Save_World_TextBox.Text = null;
            add.filedelete(@"upload", true);
            MaterialDialog messageBox = new MaterialDialog(this, "Upload to Google Drive", "Upload complete");
            messageBox.ShowDialog(this);
            Backup_Button.Enabled = true;
        }



        /////////////////////////////////////Color Schemes///////////////////////////////////////////////////////////////////////

        About about = new About();
        Help help = new Help();

        private void Default_Button_CheckedChanged(object sender, EventArgs e)
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue400, Accent.Cyan700, TextShade.WHITE);
            Global_Refresh_Manager();
        }

        private void Green_Button_CheckedChanged(object sender, EventArgs e)
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.LightGreen400, TextShade.BLACK);
            Global_Refresh_Manager();
        }

        private void Pink_Button_CheckedChanged(object sender, EventArgs e)
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Pink800, Primary.Pink900, Primary.Pink500, Accent.Pink200, TextShade.BLACK);
            Global_Refresh_Manager();
        }

        private void Red_Button_CheckedChanged(object sender, EventArgs e)
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Red800, Primary.Red900, Primary.Red500, Accent.Red200, TextShade.BLACK);
            Global_Refresh_Manager();
        }

        private void Amber_Button_CheckedChanged(object sender, EventArgs e)
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Amber800, Primary.Amber900, Primary.Amber500, Accent.Amber200, TextShade.BLACK);
            Global_Refresh_Manager();
        }

        private void Orange_Button_CheckedChanged(object sender, EventArgs e)
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Orange800, Primary.Orange900, Primary.Orange500, Accent.Orange200, TextShade.BLACK);
            Global_Refresh_Manager();
        }

        private void Deep_Purple_Button_CheckedChanged(object sender, EventArgs e)
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.DeepPurple800, Primary.DeepPurple900, Primary.DeepPurple500, Accent.DeepPurple200, TextShade.BLACK);
            Global_Refresh_Manager();
        }

        private void Always_Top_CheckedChanged(object sender, EventArgs e)
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

        private void Global_Refresh_Manager()
        {
            Invalidate();
            Refresh();
            help.Refresh();
            help.Invalidate();
            about.Refresh();
            about.Invalidate();
        }


        /////////////////////////////////////Bedrock_Backup///////////////////////////////////////////////////////////////////////
        private void Check_World_Bedrock()
        {
            string targetDirectory = Properties.Settings.Default.World_Location = Open_Word_Text.Text;
            string pth_name = Path.Combine(targetDirectory, "levelname.txt");
            string pth_db = Path.Combine(targetDirectory, "db");
            string pth_level_data = Path.Combine(targetDirectory, "level.dat");
            string pth_level_data_old = Path.Combine(targetDirectory, "level.dat_old");
            if ((!File.Exists(pth_name)) || (!Directory.Exists(pth_db)) || (!File.Exists(pth_level_data)) && (!File.Exists(pth_level_data_old)))
            {
                string txt = "The Folder Selected isn't a valid Bedrock Minecraft World, Please try again";
                Backup_error(txt);
                return;
            }
            Jsonload_comp();
            Notification_Informer.BalloonTipTitle = "Bedrock Backup";
            Notification_Informer.BalloonTipText = "Bedrock Backup has started";
            Notification_Informer.Visible = true;
            Notification_Informer.ShowBalloonTip(500);
            Dailog_Manager("false", false);
            Bedrock_Compress();
            Notification_Informer.Visible = false;
            Dailog_Manager("false", true);
            MaterialSnackBar finish_Bedrock = new MaterialSnackBar("Bedrock Backup has finish", "OK", true);
            finish_Bedrock.Show(this);
        }
        public void Bedrock_Compress()
        {
            try
            {
                if (zip_mcworld.Checked)
                {
                    if (File.Exists(Path.Combine(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text, "Backup Bedrock world.zip")))
                    {
                        Bedrock_Rename_Manager();
                    }
                    else
                    {
                        string sourceDirectoryName = Properties.Settings.Default.World_Location = Open_Word_Text.Text;
                        string destinationArchiveFileName = Path.Combine(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text, "Backup Bedrock world.zip");
                        Bedrock_Compressor(sourceDirectoryName, destinationArchiveFileName);
                    }
                }
                else
                {
                    if (File.Exists(Path.Combine(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text, "Backup Bedrock world.mcworld")))
                    {
                        Bedrock_Rename_Manager();
                    }
                    else
                    {
                        string sourceDirectoryName = Properties.Settings.Default.World_Location = Open_Word_Text.Text;
                        string destinationArchiveFileName = Path.Combine(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text, "Backup Bedrock world.mcworld");
                        Bedrock_Compressor(sourceDirectoryName, destinationArchiveFileName);
                    }
                }
            }
            catch (IOException exp)
            {
                string Error_txt = exp.Message;
                Dialog_error(Error_txt);
            }
        }
        private void Bedrock_Compressor(string sourceDirectoryName, string destinationArchiveFileName)
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
            Bedrock_Rename_Manager();
        }
        private void Bedrock_Rename_Manager()
        {
            if (!Custom_name.Checked)
            {
                Bedrock_Add_Date(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text);
            }
            else
            {
                Custom_Backup_Name_Manager();
            }
        }
        private void Bedrock_Add_Date(string path)
        {
            if (zip_mcworld.Checked)
            {
                string filename = Path.Combine(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text, "Backup Bedrock world.zip");

                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                var newFilename = string.Format("{0}({1}).zip", fileNameWithoutExtension, TimeFormat);
                var newFullFilename = Path.Combine(path, newFilename);
                File.Move(filename, newFullFilename);
            }
            else
            {
                string filename = Path.Combine(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text, "Backup Bedrock world.mcworld");
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                var newFilename = string.Format("{0}({1}).mcworld", fileNameWithoutExtension, TimeFormat);
                var newFullFilename = Path.Combine(path, newFilename);
                File.Move(filename, newFullFilename);
            }

        }

        /////////////////////////////////////Copy_Input_Backup///////////////////////////////////////////////////////////////////////

        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            try
            {
                Directory.CreateDirectory(target.FullName);
                // Copy each file into the new directory.
                foreach (FileInfo fi in source.GetFiles())
                {

                    fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);

                }

                // Copy each subdirectory using recursion.
                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir =
                        target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll(diSourceSubDir, nextTargetSubDir);
                }
            }
            catch (IOException exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        /////////////////////////////////////Java_Backup///////////////////////////////////////////////////////////////////////
        private void Check_World_Java()
        {
            string targetDirectory = Properties.Settings.Default.World_Location = Open_Word_Text.Text;
            string pth_icon = Path.Combine(targetDirectory, "icon.png");
            string pth_level = Path.Combine(targetDirectory, "level.dat");
            string pth_level_dat = Path.Combine(targetDirectory, "level.dat_old");
            string pth_session_lock = Path.Combine(targetDirectory, "session.lock");
            if ((!File.Exists(pth_icon)) && (!Directory.Exists(pth_level)) && (!File.Exists(pth_level_dat)) && (!File.Exists(pth_session_lock)))
            {
                string txt = "The Folder Selected isn't a valid Java Minecraft World, Please try again";
                Backup_error(txt);
                return;
            }
            Jsonload_comp();
            Notification_Informer.BalloonTipTitle = "Java Backup";
            Notification_Informer.BalloonTipText = "The Java Backup has started";
            Notification_Informer.Visible = true;
            Notification_Informer.ShowBalloonTip(500);
            Dailog_Manager("false", false);
            Notification_Informer.Visible = false;
            Java_Compress();
            Dailog_Manager("false", true);
            MaterialSnackBar finish_Java = new MaterialSnackBar("The Java Backup has finish", "OK", true);
            finish_Java.Show(this);

        }
        private void Java_Compress()
        {
            try
            {
                if (File.Exists(Path.Combine(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text, "Backup Java world.zip")))
                {
                    Java_Rename_Manager();
                }
                else
                {
                    string sourceDirectoryName = Properties.Settings.Default.World_Location = Open_Word_Text.Text;
                    string destinationArchiveFileName = Path.Combine(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text, "Backup Java world.zip");
                    Java_Compressor(sourceDirectoryName, destinationArchiveFileName);
                }

            }
            catch (IOException exp)
            {
                string Error_txt = exp.Message;
                Dialog_error(Error_txt);
            }
        }
        private void Java_Compressor(string sourceDirectoryName, string destinationArchiveFileName)
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
            Java_Rename_Manager();
        }
        private void Java_Rename_Manager()
        {
            if (!Custom_name.Checked)
            {
                Java_Add_Date(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text);
            }
            else
            {
                Custom_Backup_Name_Manager();
            }
        }
        private void Java_Add_Date(string path)
        {
            string filename = Path.Combine(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text, "Backup Java world.zip");
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
            var newFilename = string.Format("{0}({1}).zip", fileNameWithoutExtension, TimeFormat);
            var newFullFilename = Path.Combine(path, newFilename);
            File.Move(filename, newFullFilename);

        }
        /////////////////////////////////////CustomBackupName///////////////////////////////////////////////////////////////////////
        public void Custom_Backup_Name_Manager()
        {
            if ((!string.IsNullOrEmpty(Backup_Name.Text)) && (Custom_name.Checked))
            {
                if (!Backup_name_for.Checked)
                {
                    Bedrock_Custom_Backup_Name(Properties.Settings.Default.Defualt_name_textbox = Backup_Name.Text);
                }
                else
                {
                    Java_Custom_Backup_Name(Properties.Settings.Default.Defualt_name_textbox = Backup_Name.Text);
                }

            }

        }

        public void Bedrock_Custom_Backup_Name(string name)
        {
            if (zip_mcworld.Checked)
            {
                string filename = Path.Combine(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text, "Backup Bedrock world.zip");
                var newFilename = string.Format("{0}({1}).zip", name, TimeFormat);
                var newFullFilename = Path.Combine(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text, newFilename);
                File.Move(filename, newFullFilename);
            }
            else
            {
                string filename = Path.Combine(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text, "Backup Bedrock world.mcworld");
                var newFilename = string.Format("{0}({1}).mcworld", name, TimeFormat);
                var newFullFilename = Path.Combine(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text, newFilename);
                File.Move(filename, newFullFilename);
            }
        }

        public void Java_Custom_Backup_Name(string name)
        {
            string filename = Path.Combine(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text, "Backup Java world.zip");
            var newFilename = string.Format("{0}({1}).zip", name, TimeFormat);
            var newFullFilename = Path.Combine(Properties.Settings.Default.Save_Location = Save_World_TextBox.Text, newFilename);
            File.Move(filename, newFullFilename);
        }


        /////////////////////////////////////Resize to form///////////////////////////////////////////////////////////////////////

        private void Notify_tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            Notification_Informer.Visible = false;
            this.ShowInTaskbar = true;
            if (Strt_Win.Checked)
            {
                Noform_start();
            }
        }

        private void Edtitions_CheckedChanged(object sender, EventArgs e)
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
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
            Notification_Informer.Visible = false;
            if (Strt_Win.Checked)
            {
                Noform_start();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup_Button_Click(sender, e);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
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

        /// <summary>
        ///  Main btns
        /// </summary>


        private void Help_Button_Click(object sender, EventArgs e)
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

        private void About_Button_Click(object sender, EventArgs e)
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

        private void Reset_Btn_Click(object sender, EventArgs e)
        {
            MaterialDialog Reset = new MaterialDialog(this, "Sky Cloud Backup", "Are you sure that you are Reseting this app", "OK", true, "Cancel", true);
            DialogResult result = Reset.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                if (Properties.Settings.Default.Dev_Mode == true)
                {
                    MaterialDialog Dev_reset = new MaterialDialog(this, "Sky Cloud Backup", "hard Reset(OK), Reset(Cancel) ", "OK", true, "Cancel", true);
                    DialogResult Dev_result = Dev_reset.ShowDialog(this);
                    if (Dev_result == DialogResult.Cancel)
                    {
                        Properties.Settings.Default.GlobalReset = true;
                        Properties.Settings.Default.first_strtup = false;
                        setsetting sjs = new setsetting()
                        {
                            Mode = false,
                            Default_Color = true,
                            Green = false,
                            Pink = false,
                            Red = false,
                            Amber = false,
                            Orange = false,
                            Deep_Purple = false,
                            Upload_To_Drive = false,
                            World_Location = null,
                            Save_Location = null,
                            Always_on_top = false,
                            Minimize_to_Form = false,
                            Editions = false,
                            strtwin = false,
                            Chk_zip_mcowrld = false,
                            Defualt_name_textbox = null,
                            Defualt_name_chkbx = false,
                            Backup_name_for = false,
                            Reset = Properties.Settings.Default.GlobalReset,
                            FirstRun = Properties.Settings.Default.first_strtup,
                            DeveloperMode = Properties.Settings.Default.Dev_Mode,
                            backupdialog = true
                        };
                        string stringjson = JsonConvert.SerializeObject(sjs);
                        File.WriteAllText(@"settings.json", stringjson);
                        Application.Restart();
                    }
                    if (Dev_result == DialogResult.OK)
                    {
                        Properties.Settings.Default.first_strtup = true;
                        setsetting sjs = new setsetting()
                        {
                            Mode = false,
                            Default_Color = true,
                            Green = false,
                            Pink = false,
                            Red = false,
                            Amber = false,
                            Orange = false,
                            Deep_Purple = false,
                            Upload_To_Drive = false,
                            World_Location = null,
                            Save_Location = null,
                            Always_on_top = false,
                            Minimize_to_Form = false,
                            Editions = false,
                            strtwin = false,
                            Chk_zip_mcowrld = false,
                            Defualt_name_textbox = null,
                            Defualt_name_chkbx = false,
                            Backup_name_for = false,
                            Reset = false,
                            FirstRun = Properties.Settings.Default.first_strtup,
                            DeveloperMode = Properties.Settings.Default.Dev_Mode,
                            backupdialog = true
                        };
                        Properties.Settings.Default.Save();
                        string stringjson = JsonConvert.SerializeObject(sjs);
                        File.WriteAllText(@"settings.json", stringjson);
                        Application.Restart();
                    }
                }
                else
                {
                    Properties.Settings.Default.GlobalReset = true;
                    setsetting sjs = new setsetting()
                    {
                        Mode = false,
                        Default_Color = true,
                        Green = false,
                        Pink = false,
                        Red = false,
                        Amber = false,
                        Orange = false,
                        Deep_Purple = false,
                        Upload_To_Drive = false,
                        World_Location = null,
                        Save_Location = null,
                        Always_on_top = false,
                        Minimize_to_Form = false,
                        Editions = false,
                        strtwin = false,
                        Chk_zip_mcowrld = false,
                        Defualt_name_textbox = null,
                        Defualt_name_chkbx = false,
                        Backup_name_for = false,
                        Reset = true,
                        FirstRun = false,
                        DeveloperMode = Properties.Settings.Default.Dev_Mode,
                        backupdialog = true
                    };
                    Properties.Settings.Default.Save();
                    string stringjson = JsonConvert.SerializeObject(sjs);
                    File.WriteAllText(@"settings.json", stringjson);
                    Application.Restart();
                }
            }
        }


        /// 
        /// UI Changes
        /// 
        private void Strt_Win_CheckedChanged(object sender, EventArgs e)
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

        private void Open_Word_Text_TabStopChanged(object sender, EventArgs e)
        {
            Check_atstartup_Backup();
        }

        private void Save_World_TextBox_TabStopChanged(object sender, EventArgs e)
        {
            Check_atstartup_Backup();
        }

        private void zip_mcworld_CheckedChanged(object sender, EventArgs e)
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

        private void Deafualt_Backup_name_CheckedChanged(object sender, EventArgs e)
        {
            Check_Custom_Name();
        }

        private void Backup_name_for_CheckedChanged(object sender, EventArgs e)
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

        private void Upload_to_Drive_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Upload_to_Drive_CheckBox.Checked)
            {
                Save_World_TextBox.Enabled = false;
                Save_World_Button.Enabled = false;
                if (!File.Exists(Authlocation))
                {
                    Sigin_in_Button.Enabled = true;
                }

                Check_textbox_field_Open();
            }
            else
            {
                Save_World_TextBox.Enabled = true;
                Save_World_Button.Enabled = true;
                Sigin_in_Button.Enabled = false;
                Check_atstartup_Backup();
            }
            Properties.Settings.Default.Upload_To_Drive = Upload_to_Drive_CheckBox.Checked;
            Properties.Settings.Default.Save();

        }

        /////////////////////////////////////Error///////////////////////////////////////////////////////////////////////
        public void Dialog_error(string Error_txt)
        {

            MaterialDialog Error = new MaterialDialog(this, "Error", Error_txt, "Ok");
            Error.ShowDialog(this);
        }

        public void Backup_error(string txt)
        {
            WindowState = FormWindowState.Normal;
            string Error_txt = txt;
            Dialog_error(Error_txt);
            if (Minimize_Systray.Checked)
            {
                Notification_Informer.Visible = false;
                ShowInTaskbar = true;
                Show();
                Activate();
                Backup_Button.Enabled = false;
                Notification_Informer.Visible = true;
                ShowInTaskbar = false;
            }

        }


        /// 
        /// AutoSave  
        /// 
        private void autosave_Tick(object sender, EventArgs e)
        {
            Jsonload_comp();
        }

        private void automaticsave_CheckedChanged(object sender, EventArgs e)
        {
            if (automaticsave.Checked)
            {
                autosave.Start();
            }
            else
            {
                autosave.Stop();
            }
        }

        private void Dailog_Manager(string SetMode, Boolean EndDailog)
        {
            if (BackupDailog_Checkbox.Checked)
            {
                if (EndDailog)
                {
                    foreach (Process proc in Process.GetProcessesByName("Backup_Loading_Screen"))
                    {
                        proc.Kill();
                    }
                }
                else
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = "Backup_Loading_Screen.exe";
                    Process process = new Process();
                    process.StartInfo = startInfo;
                    process.StartInfo.Arguments = SetMode;
                    process.Start();
                }
            }


        }

        private void Privacy_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://involts.github.io/Sky-Cloud-Backup/Privacy_Policy/");
            }
            catch (Exception ex)
            {
                Dialog_error(ex.Message);
            }
        }
    }




}

