using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using MaterialSkin;
using MaterialSkin.Controls;
using Sky_Cloud_Backup.assets;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace Sky_Cloud_Backup
{
    public partial class Main_Screen: MaterialForm
    {


        public Main_Screen ()
        {
            InitializeComponent();
            Check_atstartup_Backup();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.AddFormToManage(new Help());
            materialSkinManager.AddFormToManage(new About());
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue400, Accent.Cyan700, TextShade.WHITE);
            Sigin_in_Button.Enabled = false;
            add.createfile(@"Temp");
            Backup_Button.Enabled = false;
            Check_Default_name();
            check_signin();
        }

        private static readonly startup stup = new startup();
        private static readonly additonal add = new additonal();
        google_drive google_drive = new google_drive();

        public static string environment = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public static string file_path = @"driveApiCredentials/Google.Apis.Auth.OAuth2.Responses.TokenResponse-User";
        public static string path = Path.Combine(environment, file_path);


        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;
        private void Upload_to_Drive_CheckBox_CheckedChanged ( object sender, EventArgs e )
        {
            if (Upload_to_Drive_CheckBox.Checked)
            {
                Save_World_TextBox.Enabled = false;
                Save_World_Button.Enabled = false;
                if (!File.Exists(path))
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

        //
        // Check SCB stats
        //
        public void Check_Default_name ()
        {
            MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;
            if (Default_Backup_name.Checked)
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

        public void Check_Reset ()
        {
            if (Properties.Settings.Default.Resets == true)
            {
                MaterialDialog Reset = new MaterialDialog(this, "Sky Cloud Backup", "Reset Complete", "OK", true, "Cancel", true);
                Reset.ShowDialog(this);
                Properties.Settings.Default.Resets = false;
                Properties.Settings.Default.Save();
            }
        }

        public void Minimizeto_start ()
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

        public void Noform_start ()
        {
            Show();
            notify_tray.Visible = false;
            ShowInTaskbar = true;
            Activate();
        }

        public void Check_textbox_field_Open ()
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

        public void Check_atstartup_Backup ()
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

        public void check_signin ()
        {
            if (File.Exists(path))
            {
                sign_out_button.Enabled = true;
                Sigin_in_Button.Enabled = false;
            }
            else
            {
                sign_out_button.Enabled = false;
                Sigin_in_Button.Enabled = true;
            }
        }

        private void Open_World_Button_Click ( object sender, EventArgs e )
        {
            if (Open_World.ShowDialog() == DialogResult.OK)
            {
                Open_Word_Text.Text = Open_World.SelectedPath;
                Check_atstartup_Backup();
                Properties.Settings.Default.World_Location = Open_Word_Text.Text;
                Properties.Settings.Default.Save();
            }

        }

        private void Save_World_Button_Click ( object sender, EventArgs e )
        {
            if (Save_World.ShowDialog() == DialogResult.OK)
            {
                Save_World_TextBox.Text = Save_World.SelectedPath;
                Check_atstartup_Backup();
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


        UserCredential credential;
        private void Backup_Button_Click ( object sender, EventArgs e )
        {
            if (Open_Word_Text.Text.Length == 0)
            {
                this.ShowInTaskbar = true;
                notify_tray.Visible = false;
                this.Show();
                string Error_txt = "The Textbox is empty";
                Dialog_error(Error_txt);
                this.Hide();
                notify_tray.Visible = true;
                this.ShowInTaskbar = false;
            }
            else
            {
                if (!Upload_to_Drive_CheckBox.Checked)
                {
                    Backup_Button.Enabled = false;
                    if (Edtitions.Checked)
                    {
                        Java_Backup();
                    }
                    else
                    {
                        Bedrock_Backup();
                    }
                    Backup_Button.Enabled = true;
                }
                else
                {
                    uploadtodrve();
                }
            }
        }

        private void uploadtodrve ()
        {
            Save_World_TextBox.Text = @"upload";
            Backup_Button.Enabled = false;
            if (Edtitions.Checked)
            {
                Java_Backup();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "Backup_Loading_Screen.exe";
                Process process = new Process();
                process.StartInfo = startInfo;
                process.StartInfo.Arguments = "true";
                process.Start();
                foreach (var filename in Directory.GetFiles(@"upload"))
                {
                    var newFilename = string.Format("{0}.zip", "Backup Java world");
                    var newFullFilename = Path.Combine(@"upload", newFilename);
                    File.Move(filename, newFullFilename);
                }

                credential = google_drive.GetUserCredential();

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = google_drive.ApplicationName,
                });

                google_drive.Upload_to_Drive(service, "Backup Java world" + DateTime.Now.ToString("dddd, dd MMMM yyyy"), @"upload");
                process.Kill();
            }
            else
            {
                Bedrock_Backup();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "Backup_Loading_Screen.exe";
                Process process = new Process();
                process.StartInfo = startInfo;
                process.StartInfo.Arguments = "true";
                process.Start();
                string name = "Backup Bedrock world";
                foreach (var filename in Directory.GetFiles(@"upload"))
                {
                    var newFilename = string.Format("{0}.zip", name);
                    var newFullFilename = Path.Combine(@"upload", newFilename);
                    File.Move(filename, newFullFilename);
                }
                credential = google_drive.GetUserCredential();

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = google_drive.ApplicationName,
                });
                google_drive.Upload_to_Drive(service, "Backup Bedrock world " + DateTime.Now.ToString("dddd, dd MMMM yyyy"), @"upload/Backup Bedrock world.zip");
                process.Kill();

            }
            add.filedelete(@"upload", true);
            MaterialDialog messageBox = new MaterialDialog(this, "Sky Cloud Backup", "upload complete");
            messageBox.ShowDialog(this);
            Backup_Button.Enabled = true;
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
            Properties.Settings.Default.Defualt_name_chkbx = Default_Backup_name.Checked;
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
            Default_Backup_name.Checked = Properties.Settings.Default.Defualt_name_chkbx;
            Backup_name_for.Checked = Properties.Settings.Default.Backup_name_for;
            Minimizeto_start();
            Check_atstartup_Backup();
            Check_Reset();

        }
        /////////////////////////////////////Bedrock_Backup///////////////////////////////////////////////////////////////////////
        private void Bedrock_Backup ()
        {
            string sourceDirectory = Properties.Settings.Default.World_Location = Open_Word_Text.Text;
            string targetDirectory = @"Temp";
            Copy(sourceDirectory, targetDirectory);
            if (!Directory.Exists(targetDirectory))
            {

                Copy(sourceDirectory, targetDirectory);
                Check_World_Bedrock();
            }
            else
            {
                add.createfile(@"Temp");
                Copy(sourceDirectory, targetDirectory);
                Check_World_Bedrock();
            }
            Backup_Button.Enabled = true;
        }
        public void Bedrock_Compress ()
        {
            try
            {
                if (zip_mcworld.Checked)
                {
                    if (File.Exists(@"Temp\Backup Bedrock world.zip"))
                    {
                        Bedrock_Genrate_Random_Name();
                    }
                    else
                    {
                        string sourceDirectoryName = Properties.Settings.Default.World_Location = Open_Word_Text.Text;
                        string destinationArchiveFileName = @"Temp\Backup Bedrock world.zip";
                        Bedrock_Compressor(sourceDirectoryName, destinationArchiveFileName);
                    }
                }
                else
                {
                    if (File.Exists(@"Temp\Backup Bedrock world.mcworld"))
                    {
                        Bedrock_Genrate_Random_Name();
                    }
                    else
                    {
                        string sourceDirectoryName = Properties.Settings.Default.World_Location = Open_Word_Text.Text;
                        string destinationArchiveFileName = @"Temp\Backup Bedrock world.mcworld";
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
        private void Bedrock_Compressor ( string sourceDirectoryName, string destinationArchiveFileName )
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
            Bedrock_Genrate_Random_Name();
        }
        private void Bedrock_Genrate_Random_Name ()
        {
            Custom_Backup_Name();
            Bedrock_Add_date(@"Temp");
            Copy_Output();
        }
        private void Bedrock_Add_date ( string path )
        {
            if (zip_mcworld.Checked)
            {
                foreach (var filename in Directory.GetFiles(path))
                {
                    string suffix = DateTime.Now.ToString(" dddd, dd MMMM yyyy ").ToString(CultureInfo.InvariantCulture);
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                    var newFilename = string.Format("{0}({1}).zip", fileNameWithoutExtension, suffix);
                    var newFullFilename = Path.Combine(path, newFilename);
                    File.Move(filename, newFullFilename);
                }
            }
            else
            {
                foreach (var filename in Directory.GetFiles(path))
                {
                    string suffix = ( DateTime.Now.ToString(" dddd, dd MMMM yyyy ") ).ToString(CultureInfo.InvariantCulture);
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                    var newFilename = string.Format("{0}({1}).mcworld", fileNameWithoutExtension, suffix);
                    var newFullFilename = Path.Combine(path, newFilename);
                    File.Move(filename, newFullFilename);
                }
            }

        }
        /////////////////////////////////////Copy_Input_Backup///////////////////////////////////////////////////////////////////////

        public static void Copy ( string sourceDirectory, string targetDirectory )
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll ( DirectoryInfo source, DirectoryInfo target )
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

        /////////////////////////////////////Copy_Output_Backup////////////////////llllll///////////////////////////////////////////////////
        public void Copy_Output ()
        {
            string sourceDirectory = @"Temp\";
            string targetDirectory = Properties.Settings.Default.Save_Location = Save_World_TextBox.Text;
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);
            CopyAll(diSource, diTarget);
        }

        /////////////////////////////////////Java_Backup///////////////////////////////////////////////////////////////////////
        private void Java_Backup ()
        {
            string sourceDirectory = Properties.Settings.Default.World_Location = Open_Word_Text.Text;
            string targetDirectory = @"Temp";
            Copy(sourceDirectory, targetDirectory);
            if (!Directory.Exists(targetDirectory))
            {
                Copy(sourceDirectory, targetDirectory);
                Check_World_Java();
            }
            else
            {
                add.createfile(@"Temp");
                Copy(sourceDirectory, targetDirectory);
                Check_World_Java();
            }
            Backup_Button.Enabled = true;
        }
        private void Java_Compress ()
        {
            try
            {
                if (File.Exists(@"Temp\Backup Java world.zip"))
                {
                    Copy_Output();
                }
                else
                {
                    string sourceDirectoryName = Properties.Settings.Default.World_Location = Open_Word_Text.Text;
                    string destinationArchiveFileName = @"Temp\Backup Java world.zip";
                    Java_Compressor(sourceDirectoryName, destinationArchiveFileName);
                }

            }
            catch (IOException exp)
            {
                string Error_txt = exp.Message;
                Dialog_error(Error_txt);
            }
        }
        private void Java_Compressor ( string sourceDirectoryName, string destinationArchiveFileName )
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
            Java_Genrate_Random_Name();
        }
        private void Java_Genrate_Random_Name ()
        {
            Custom_Backup_Name();
            Java_Add_Date(@"Temp");
            Copy_Output();

        }
        private static void Java_Add_Date ( string path )
        {
            foreach (var filename in Directory.GetFiles(path))
            {
                string suffix = DateTime.Now.ToString(" dddd, dd MMMM yyyy ").ToString(CultureInfo.InvariantCulture);
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                var newFilename = string.Format("{0}({1}).zip", fileNameWithoutExtension, suffix);
                var newFullFilename = Path.Combine(path, newFilename);
                File.Move(filename, newFullFilename);
            }
        }

        /////////////////////////////////////Check_Worlds///////////////////////////////////////////////////////////////////////
        private void Check_World_Bedrock ()
        {
            string pth_name = @"Temp\levelname.txt";
            string pth_db = @"Temp\db";
            string pth_level_data = @"Temp\level.dat";
            string pth_level_data_old = @"Temp\level.dat_old";
            if (File.Exists(pth_name))
            {
                if (Directory.Exists(pth_db))
                {
                    if (File.Exists(pth_level_data))
                    {
                        if (File.Exists(pth_level_data_old))
                        {
                            Bedrock_Backup_Notifier.BalloonTipTitle = "Bedrock Backup";
                            Bedrock_Backup_Notifier.BalloonTipText = "You're Bedrock world is Backuping";
                            Bedrock_Backup_Notifier.Visible = true;
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.FileName = "Backup_Loading_Screen.exe";
                            Process process = new Process();
                            process.StartInfo = startInfo;
                            process.StartInfo.Arguments = "false";
                            process.Start();
                            add.filedelete(@"Temp", true);
                            Bedrock_Compress();
                            Bedrock_Backup_Notifier.Visible = false;
                            process.Kill();
                            add.filedelete(@"Temp", true);
                            MaterialSnackBar finish_Bedrock = new MaterialSnackBar("You're Bedrock world is backup", "OK", true);
                            finish_Bedrock.Show(this);
                        }
                        else
                        {
                            string txt = "The File Selected isn't a valid Bedrock Minecraft World, Please try again";
                            Backup_error(txt);

                        }

                    }
                    else
                    {
                        string txt = "The File Selected isn't a valid Bedrock Minecraft World, Please try again";
                        Backup_error(txt);
                    }
                }
                else
                {
                    string txt = "The File Selected isn't a valid Bedrock Minecraft World, Please try again";
                    Backup_error(txt);
                }
            }
            else
            {
                string txt = "The File Selected isn't a valid Bedrock Minecraft World, Please try again";
                Backup_error(txt);
            }
        }

        private void Check_World_Java ()
        {
            string pth_icon = @"Temp\icon.png";
            string pth_level = @"Temp\level.dat";
            string pth_level_dat = @"Temp\level.dat_old";
            string pth_session_lock = @"Temp\session.lock";
            if (File.Exists(pth_icon))
            {
                if (File.Exists(pth_level))
                {
                    if (File.Exists(pth_level_dat))
                    {
                        if (File.Exists(pth_session_lock))
                        {
                            Java_Bedrock_Notifier.BalloonTipTitle = "Java Backup";
                            Java_Bedrock_Notifier.BalloonTipText = "You're Java world is Backuping";
                            Java_Bedrock_Notifier.Visible = true;
                            Java_Bedrock_Notifier.ShowBalloonTip(500);
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.FileName = "Backup_Loading_Screen.exe";
                            Process process = new Process();
                            process.StartInfo = startInfo;
                            process.StartInfo.Arguments = "false";
                            process.Start();
                            add.filedelete(@"Temp", true);
                            Java_Bedrock_Notifier.Visible = false;
                            Java_Compress();
                            process.Kill();
                            add.filedelete(@"Temp", true);
                            MaterialSnackBar finish_Java = new MaterialSnackBar("You're Java world is backup", "OK", true);
                            finish_Java.Show(this);
                        }
                        else
                        {
                            string txt = "The File Selected isn't a valid Java Minecraft World, Please try again";
                            Backup_error(txt);
                        }
                    }
                    else
                    {
                        string txt = "The File Selected isn't a valid Java Minecraft World, Please try again";
                        Backup_error(txt);
                    }
                }
                else
                {
                    string txt = "The File Selected isn't a valid Java Minecraft World, Please try again";
                    Backup_error(txt);
                }
            }
            else
            {
                string txt = "The File Selected isn't a valid Java Minecraft World, Please try again";
                Backup_error(txt);
            }

        }
        /////////////////////////////////////CustomBackupName///////////////////////////////////////////////////////////////////////
        public void Custom_Backup_Name ()
        {
            if (!string.IsNullOrEmpty(Backup_Name.Text))
            {
                if (Backup_name_for.Checked)
                {
                    if (!string.IsNullOrEmpty(Backup_Name.Text))
                    {
                        if (Edtitions.Checked)
                        {
                            Java_Custom_Backup_Name(Properties.Settings.Default.Defualt_name_textbox = Backup_Name.Text);
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Backup_Name.Text))
                    {
                        Bedrock_Custom_Backup_Name(Properties.Settings.Default.Defualt_name_textbox = Backup_Name.Text);
                    }
                }
            }
        }

        public void Bedrock_Custom_Backup_Name ( string name )
        {
            if (zip_mcworld.Checked)
            {
                foreach (var filename in Directory.GetFiles(@"Temp"))
                {
                    var newFilename = string.Format("{0}.mcworld", name);
                    var newFullFilename = Path.Combine(@"Temp", newFilename);
                    File.Move(filename, newFullFilename);
                }
            }
            else
            {
                foreach (var filename in Directory.GetFiles(@"Temp"))
                {
                    var newFilename = string.Format("{0}.zip", name);
                    var newFullFilename = Path.Combine(@"Temp", newFilename);
                    File.Move(filename, newFullFilename);
                }
            }
        }

        public void Java_Custom_Backup_Name ( string name )
        {
            foreach (var filename in Directory.GetFiles(@"Temp"))
            {
                var newFilename = string.Format("{0}.zip", name);
                var newFullFilename = Path.Combine(@"Temp", newFilename);
                File.Move(filename, newFullFilename);
            }
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
                Noform_start();
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
                Noform_start();
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
            Backup_Button_Click(sender, e);
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
            Check_atstartup_Backup();
        }

        private void Save_World_TextBox_TabStopChanged ( object sender, EventArgs e )
        {
            Check_atstartup_Backup();
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

        private void Reset_Btn_Click ( object sender, EventArgs e )
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
                        Properties.Settings.Default.Resets = true;
                        Properties.Settings.Default.first_strtup = false;
                        zip_mcworld.Checked = false;
                        Backup_Name.Clear();
                        Default_Backup_name.Checked = true;
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
                        Default_Backup_name.Checked = true;
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
                    Properties.Settings.Default.Resets = true;
                    Properties.Settings.Default.first_strtup = false;
                    zip_mcworld.Checked = false;
                    Backup_Name.Clear();
                    Default_Backup_name.Checked = true;
                    Backup_name_for.Checked = false;
                    Properties.Settings.Default.Save();
                    this.Show();
                    Application.Restart();
                }
            }
        }

        private void Sigin_in_Button_Click ( object sender, EventArgs e )
        {

            if (!File.Exists(path))
            {
                MaterialDialog Com = new MaterialDialog(this, "Sky Cloud Backup", "Are you sure that you Continue to sign in to google drive, Google didn't verifed it", "OK", true, "Never mind", true);
                DialogResult result = Com.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    google_drive.GetUserCredential();
                    check_signin();
                }
            }
            // System.Diagnostics.Process.Start("https://involts.github.io/Sky-Cloud-Backup/Development/");

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
            if (Default_Backup_name.Checked)
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

        /////////////////////////////////////Error///////////////////////////////////////////////////////////////////////
        public void Dialog_error ( string Error_txt )
        {

            MaterialDialog Error = new MaterialDialog(this, "Sky Cloud Backup", Error_txt, "Ok");
            Error.ShowDialog(this);
        }

        public void Backup_error ( string txt )
        {
            WindowState = FormWindowState.Normal;
            notify_tray.Visible = false;
            ShowInTaskbar = true;
            Show();
            Activate();
            string Error_txt = txt;
            Dialog_error(Error_txt);
            Backup_Button.Enabled = false;
            add.filedelete(@"Temp", true);
            Hide();
            notify_tray.Visible = true;
            ShowInTaskbar = false;
        }

        private void sign_out_btn_Click ( object sender, EventArgs e )
        {
            if (File.Exists(path))
            {
                MaterialDialog Com = new MaterialDialog(this, "Sky Cloud Backup", "Are you sure that you want sign out to google drive", "OK", true, "Never mind", true);
                DialogResult result = Com.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    File.Delete(path);
                    check_signin();
                }
            }
        }
    }
}

