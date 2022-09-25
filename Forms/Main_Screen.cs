using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
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
            add.createfile(@"Temp");
            Backup_Button.Enabled = false;
            Chk_Default_name();
            chk_signin();
        }

        private static readonly strtup stup = new strtup();
        private static readonly additonal add = new additonal();
        gle_div gle_div = new gle_div();

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

        //
        // Check SCB stats
        //
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
            if (Properties.Settings.Default.Resets == true)
            {
                MaterialDialog Reset = new MaterialDialog(this, "Sky Cloud Backup", "Reset Complete", "OK", true, "Cancel", true);
                Reset.ShowDialog(this);
                Properties.Settings.Default.Resets = false;
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

        public void chk_signin ()
        {
            if (File.Exists(path))
            {
                sign_out_btn.Enabled = true;
                Sigin_in_Button.Enabled = false;
            }
            else
            {
                sign_out_btn.Enabled = false;
                Sigin_in_Button.Enabled = true;
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
                        Main_Java_Backup();
                    }
                    else
                    {
                        Main_Bedrock_Backup();
                    }
                    Backup_Button.Enabled = true;
                }
                else
                {
                    upldtodrve();
                }
            }
        }

        private void upldtodrve ()
        {
            Save_World_TextBox.Text = @"upload";
            Backup_Button.Enabled = false;
            if (Edtitions.Checked)
            {
                Main_Java_Backup();
                foreach (var filename in Directory.GetFiles(@"upload"))
                {
                    var newFilename = string.Format("{0}.zip", "Backup Java world");
                    var newFullFilename = Path.Combine(@"upload", newFilename);
                    File.Move(filename, newFullFilename);
                }

                credential = gle_div.GetUserCredential();

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = gle_div.ApplicationName,
                });

                gle_div.Upload_to_Drive(service, "Backup Java world" + DateTime.Now.ToString("dddd, dd MMMM yyyy"), @"upload");
            }
            else
            {
                Main_Bedrock_Backup();

                string name = "Backup Bedrock world";
                foreach (var filename in Directory.GetFiles(@"upload"))
                {
                    var newFilename = string.Format("{0}.zip", name);
                    var newFullFilename = Path.Combine(@"upload", newFilename);
                    File.Move(filename, newFullFilename);
                }
                credential = gle_div.GetUserCredential();

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = gle_div.ApplicationName,
                });
                gle_div.Upload_to_Drive(service, "Backup Bedrock world " + DateTime.Now.ToString("dddd, dd MMMM yyyy"), @"upload/Backup Bedrock world.zip");

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
                Defualt_name_chkbx = Deafualt_Backup_name.Checked,
                Backup_name_for = Backup_name_for.Checked,

            };
            string stringjson = JsonConvert.SerializeObject(sjs);
            File.WriteAllText(@"settings.json", stringjson);
            Application.Exit();
        }
        public void Main_Screen_Load ( object sender, EventArgs e )
        {
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
                Deafualt_Backup_name.Checked = account.Defualt_name_chkbx;
                Backup_name_for.Checked = account.Backup_name_for;
            }
            Minto_strt();
            Chk_atstarp_Backup();
            Chk_Reset();

        }

        private void Main_Bedrock_Backup ()
        {
            string sourceDirectory = Properties.Settings.Default.World_Location = Open_Word_Text.Text;
            string targetDirectory = @"Temp";
            Copy(sourceDirectory, targetDirectory);
            if (!Directory.Exists(targetDirectory))
            {

                Copy(sourceDirectory, targetDirectory);
                Chk_World_Bedrock();
            }
            else
            {
                add.createfile(@"Temp");
                Copy(sourceDirectory, targetDirectory);
                Chk_World_Bedrock();
            }
            Backup_Button.Enabled = true;
        }
        public void Arcfilecreat ()
        {
            try
            {
                if (zip_mcworld.Checked)
                {
                    if (File.Exists(@"Temp\Backup Bedrock world.zip"))
                    {
                        Random_Name_Bedrock();
                    }
                    else
                    {
                        string sourceDirectoryName = Properties.Settings.Default.World_Location = Open_Word_Text.Text;
                        string destinationArchiveFileName = @"Temp\Backup Bedrock world.zip";
                        CreatFrDir(sourceDirectoryName, destinationArchiveFileName);
                    }
                }
                else
                {
                    if (File.Exists(@"Temp\Backup Bedrock world.mcworld"))
                    {
                        Random_Name_Bedrock();
                    }
                    else
                    {
                        string sourceDirectoryName = Properties.Settings.Default.World_Location = Open_Word_Text.Text;
                        string destinationArchiveFileName = @"Temp\Backup Bedrock world.mcworld";
                        CreatFrDir(sourceDirectoryName, destinationArchiveFileName);
                    }
                }
            }
            catch (IOException exp)
            {
                string Error_txt = exp.Message;
                Dialog_error(Error_txt);
            }
        }
        private void CreatFrDir ( string sourceDirectoryName, string destinationArchiveFileName )
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
            Random_Name_Bedrock();
        }
        private void Random_Name_Bedrock ()
        {
            Rename_Backup_Customs_Main();
            RenameMcworldFiles(@"Temp");
            Copy_Output();
        }
        private void RenameMcworldFiles ( string path )
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

        private void Main_Java_Backup ()
        {
            string sourceDirectory = Properties.Settings.Default.World_Location = Open_Word_Text.Text;
            string targetDirectory = @"Temp";
            Copy(sourceDirectory, targetDirectory);
            if (!Directory.Exists(targetDirectory))
            {
                Copy(sourceDirectory, targetDirectory);
                Chk_World_Java();
            }
            else
            {
                add.createfile(@"Temp");
                Copy(sourceDirectory, targetDirectory);
                Chk_World_Java();
            }
            Backup_Button.Enabled = true;
        }
        private void Arcfilecreat_Java ()
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
                    CreatFrDir_Java(sourceDirectoryName, destinationArchiveFileName);
                }

            }
            catch (IOException exp)
            {
                string Error_txt = exp.Message;
                Dialog_error(Error_txt);
            }
        }
        private void CreatFrDir_Java ( string sourceDirectoryName, string destinationArchiveFileName )
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
            Rename_Backup_Customs_Main();
            Random_Name_Java();
        }
        private void Random_Name_Java ()
        {
            Rename_Backup_Customs_Main();
            RenameJavaFiles(@"Temp");
            Copy_Output();

        }
        private static void RenameJavaFiles ( string path )
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
        private void Chk_World_Bedrock ()
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
                            notify_Backup_Bedrock.BalloonTipTitle = "Bedrock Backup";
                            notify_Backup_Bedrock.BalloonTipText = "You're Bedrock world is Backuping";
                            notify_Backup_Bedrock.Visible = true;
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.FileName = "Backup_Loading_Screen.exe";
                            Process process = new Process();
                            process.StartInfo = startInfo;
                            process.Start();
                            add.filedelete(@"Temp", true);
                            Arcfilecreat();
                            notify_Backup_Bedrock.Visible = false;
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

        private void Chk_World_Java ()
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
                            notify_Backup_Java.BalloonTipTitle = "Java Backup";
                            notify_Backup_Java.BalloonTipText = "You're Java world is Backuping";
                            notify_Backup_Java.Visible = true;
                            notify_Backup_Java.ShowBalloonTip(500);
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.FileName = "Backup_Loading_Screen.exe";
                            Process process = new Process();
                            process.StartInfo = startInfo;
                            process.Start();
                            add.filedelete(@"Temp", true);
                            notify_Backup_Java.Visible = false;
                            Arcfilecreat_Java();
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
        /////////////////////////////////////CustomRename///////////////////////////////////////////////////////////////////////
        public void Rename_Backup_Customs_Main ()
        {
            if (!string.IsNullOrEmpty(Backup_Name.Text))
            {
                if (Backup_name_for.Checked)
                {
                    if (!string.IsNullOrEmpty(Backup_Name.Text))
                    {
                        if (Edtitions.Checked)
                        {
                            Rename_Backup_Custom_Java(Properties.Settings.Default.Defualt_name_textbox = Backup_Name.Text);
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(Backup_Name.Text))
                    {
                        Rename_Backup_Custom_Bedrock(Properties.Settings.Default.Defualt_name_textbox = Backup_Name.Text);
                    }
                }
            }
        }

        public void Rename_Backup_Custom_Bedrock ( string name )
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

        public void Rename_Backup_Custom_Java ( string name )
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
                Dialog_error(Error_txt);
            }
            else
            {
                if (Sigin_in_Button.Enabled == false)
                {
                    Backup_Button.Enabled = false;
                    if (Edtitions.Checked)
                    {
                        Main_Java_Backup();
                    }
                    else
                    {
                        Main_Bedrock_Backup();
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
                File.Delete(@"settings.json");
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
                    Defualt_name_chkbx = Deafualt_Backup_name.Checked,
                    Backup_name_for = Backup_name_for.Checked,

                };
                string stringjson = JsonConvert.SerializeObject(sjs);
                File.WriteAllText(@"settings.json", stringjson);
                Application.Restart();
            }
        }

        private void Sigin_in_Button_Click ( object sender, EventArgs e )
        {

            if (!File.Exists(path))
            {
                MaterialDialog Com = new MaterialDialog(this, "Sky Cloud Backup", "Are you sure that you Continue to sign in to google drive, Google didn't verifed by Google", "OK", true, "Never mind", true);
                DialogResult result = Com.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    gle_div.GetUserCredential();
                    chk_signin();
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
                    chk_signin();
                }
            }
        }
    }
}

