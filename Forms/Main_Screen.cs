using MaterialSkin;
using MaterialSkin.Controls;
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
        strtup stup = new strtup();
        public Main_Screen ()
        {
            InitializeComponent();
            Chk_atstarp_Backup();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.AddFormToManage(new Help());
            materialSkinManager.AddFormToManage(new About());
            materialSkinManager.AddFormToManage(new Copying_files());
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue400, Accent.Cyan700, TextShade.WHITE);
            Sigin_in_Button.Enabled = false;
            string folderName = "Temp";
            string pathString = Path.Combine(folderName, "");
            System.IO.Directory.CreateDirectory(pathString);
            Backup_Button.Enabled = false;
        }

        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;

        private void Chk_Reset ()
        {
            if (Properties.Settings.Default.Reset == true)
            {
                MaterialDialog Reset = new MaterialDialog(this, "Sky Cloud Backup", "Reset Complete", "OK", true, "Cancel", true);
                Reset.ShowDialog(this);
                Properties.Settings.Default.Reset = false;
                Properties.Settings.Default.Save();
            }
        }

        private void Minto_strt ()
        {
            if (Strt_Win.Checked)
            {
                notify_tray.BalloonTipTitle = " The app is in System tray";
                notify_tray.BalloonTipText = "To disable the app from starting, uncheck Start with Windows checkbox";
                notify_tray.Visible = true;
                notify_tray.ShowBalloonTip(500);
                Hide();
                this.ShowInTaskbar = false;
            }
        }

        private void Nofrm_strt ()
        {
            Show();
            notify_tray.Visible = false;
            this.ShowInTaskbar = true;
            this.Activate();
        }

        private void Chk_atstarp_Backup ()
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

        private void Backup_Ckecker ()
        {
            if (!string.IsNullOrEmpty(Open_Word_Text.Text))
            {
                Upload_to_Drive_CheckBox.Enabled = true;
                if (!string.IsNullOrEmpty(Save_World_TextBox.Text))
                {
                    Backup_Button.Enabled = true;
                }
            }
        }

        private void Upload_to_Drive_CheckBox_CheckedChanged ( object sender, EventArgs e )
        {
            if (Upload_to_Drive_CheckBox.Checked)
            {
                Save_World_TextBox.Enabled = false;
                Save_World_Button.Enabled = false;
                Sigin_in_Button.Enabled = true;
                Backup_Button.Enabled = true;
            }
            else
            {
                Save_World_TextBox.Enabled = true;
                Save_World_Button.Enabled = true;
                Sigin_in_Button.Enabled = false;
            }
        }

        private void Open_World_Button_Click ( object sender, EventArgs e )
        {
            if (Open_World.ShowDialog() == DialogResult.OK)
            {
                Open_Word_Text.Text = Open_World.SelectedPath;
                chk_and_guess_Main();
            }
            Backup_Ckecker();

        }

        private void Save_World_Button_Click ( object sender, EventArgs e )
        {
            if (Save_World.ShowDialog() == DialogResult.OK)
            {
                Save_World_TextBox.Text = Save_World.SelectedPath;
            }
            Backup_Ckecker();
        }

        private void Dark_mode_switch_CheckedChanged ( object sender, EventArgs e )
        {
            if (Dark_mode_switch.Checked)
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.DARK;
                Dark_mode_switch.Text = "Dark Mode";
            }
            else
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.LIGHT;
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
                MaterialDialog Error_01 = new MaterialDialog(this, "Sky Cloud Backup", "The Open World is empty", "Ok", true, "Cancel");
                Error_01.ShowDialog(this);
                if (Save_World_TextBox.Text.Length == 0)
                {
                    MaterialDialog Error_02 = new MaterialDialog(this, "Sky Cloud Backup", "The Open World and Save World Toolboxes are empty", "Ok", true, "Cancel");
                    Error_02.ShowDialog(this);
                }
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
        /////////////////////////////////////Color Schemes///////////////////////////////////////////////////////////////////////
        private void Default_Button_CheckedChanged ( object sender, EventArgs e )
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue400, Accent.Cyan700, TextShade.WHITE);
        }

        private void Green_Button_CheckedChanged ( object sender, EventArgs e )
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.LightGreen400, TextShade.BLACK);
        }

        private void Pink_Button_CheckedChanged ( object sender, EventArgs e )
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Pink800, Primary.Pink900, Primary.Pink500, Accent.Pink200, TextShade.BLACK);
        }

        private void Red_Button_CheckedChanged ( object sender, EventArgs e )
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Red800, Primary.Red900, Primary.Red500, Accent.Red200, TextShade.BLACK);
        }

        private void Main_Screen_FormClosing ( object sender, FormClosingEventArgs e )
        {
            Properties.Settings.Default.Mode = Dark_mode_switch.Checked;
            Properties.Settings.Default.Default_Color = Default_Button.Checked;
            Properties.Settings.Default.Green = Green_Button.Checked;
            Properties.Settings.Default.Pink = Pink_Button.Checked;
            Properties.Settings.Default.Red = Red_Button.Checked;
            Properties.Settings.Default.Upload_To_Drive = Upload_to_Drive_CheckBox.Checked;
            Properties.Settings.Default.World_Location = Open_Word_Text.Text;
            Properties.Settings.Default.Save_Location = Save_World_TextBox.Text;
            Properties.Settings.Default.Always_on_top = Always_Top.Checked;
            Properties.Settings.Default.Minimize_to_Form = Minimize_Systray.Checked;
            Properties.Settings.Default.Editions = Edtitions.Checked;
            Properties.Settings.Default.strtwin = Strt_Win.Checked;
            Properties.Settings.Default.Save();
            Application.Exit();
        }
        /////////////////////////////////////Saves///////////////////////////////////////////////////////////////////////
        private void Main_Screen_Load ( object sender, EventArgs e )
        {
            Dark_mode_switch.Checked = Properties.Settings.Default.Mode;
            Default_Button.Checked = Properties.Settings.Default.Default_Color;
            Green_Button.Checked = Properties.Settings.Default.Green;
            Pink_Button.Checked = Properties.Settings.Default.Pink;
            Red_Button.Checked = Properties.Settings.Default.Red;
            Upload_to_Drive_CheckBox.Checked = Properties.Settings.Default.Upload_To_Drive;
            Open_Word_Text.Text = Properties.Settings.Default.World_Location;
            Save_World_TextBox.Text = Properties.Settings.Default.Save_Location;
            Always_Top.Checked = Properties.Settings.Default.Always_on_top;
            Minimize_Systray.Checked = Properties.Settings.Default.Minimize_to_Form;
            Edtitions.Checked = Properties.Settings.Default.Editions;
            Strt_Win.Checked = Properties.Settings.Default.strtwin;
            Minto_strt();
            Chk_atstarp_Backup();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            Chk_Reset();

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
        //////////////////////////////////////////////Bedrock_Backup//////////////////////////
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
                string folderName = @"Temp";
                string pathString = Path.Combine(folderName, "");
                System.IO.Directory.CreateDirectory(pathString);
                Copy(sourceDirectory, targetDirectory);
                Chk_World_Bedrock();
            }
            Backup_Button.Enabled = true;
        }
        private void Arcfilecreat ()
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
            try
            {
            }
            catch (IOException exp)
            {
                MaterialDialog Error_03 = new MaterialDialog(this, "Sky Cloud Backup", exp.Message, "Ok", true, "Cancel");
                Error_03.ShowDialog(this);
            }
        }
        private void CreatFrDir ( string sourceDirectoryName, string destinationArchiveFileName )
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
            Random_Name_Bedrock();
        }
        private void Random_Name_Bedrock ()
        {
            RenameMcworldFiles(@"Temp");
            Copy_Output();
        }
        private void RenameMcworldFiles ( string path )
        {
            foreach (var filename in Directory.GetFiles(path))
            {
                string suffix = ( DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond ).ToString(CultureInfo.InvariantCulture);
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                var newFilename = string.Format("{0}{1}.mcworld", fileNameWithoutExtension, suffix);
                var newFullFilename = Path.Combine(path, newFilename);
                File.Move(filename, newFullFilename);
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

        /////////////////////////////////////Copy_Output_Backup///////////////////////////////////////////////////////////////////////
        public void Copy_Output ()
        {
            string sourceDirectory = @"Temp\";
            string targetDirectory = Properties.Settings.Default.Save_Location = Save_World_TextBox.Text;
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);
            CopyAll_Output(diSource, diTarget);
        }

        public static void CopyAll_Output ( DirectoryInfo source, DirectoryInfo target )
        {
            try
            {
                Directory.CreateDirectory(target.FullName);
                foreach (FileInfo fi in source.GetFiles())
                {
                    fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                }

                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir =
                        target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll_Output(diSourceSubDir, nextTargetSubDir);
                }
                Directory.Delete(@"Temp", true);
                string folderName = @"Temp\";
                System.IO.Directory.CreateDirectory(folderName);

            }
            catch (IOException exp)
            {
                MessageBox.Show(exp.Message, "Sky Cloud Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                string folderName = @"Temp";
                string pathString = Path.Combine(folderName, "");
                System.IO.Directory.CreateDirectory(pathString);
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
                MaterialDialog Error_06 = new MaterialDialog(this, "Sky Cloud Backup", exp.Message, "Ok", true, "Cancel");
                Error_06.ShowDialog(this);
            }
        }
        private void CreatFrDir_Java ( string sourceDirectoryName, string destinationArchiveFileName )
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
            Random_Name_Java();
        }
        private void Random_Name_Java ()
        {
            RenameJavaFiles(@"Temp");
            Copy_Output();
        }
        private static void RenameJavaFiles ( string path )
        {
            foreach (var filename in Directory.GetFiles(path))
            {
                string suffix = ( DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond ).ToString(CultureInfo.InvariantCulture);
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                var newFilename = string.Format("{0}{1}.zip", fileNameWithoutExtension, suffix);
                var newFullFilename = Path.Combine(path, newFilename);
                File.Move(filename, newFullFilename);
            }
        }

        /////////////////////////////////////Check_Worlds///////////////////////////////////////////////////////////////////////
        private void Chk_World_Bedrock ()
        {
            string pth_name = @"Temp\levelname.txt";
            string pth_db = @"Temp\db";
            string pth_jpeg = @"Temp\world_icon.jpeg";
            string pth_level_data = @"Temp\level.dat";
            string pth_level_data_old = @"Temp\level.dat_old";
            if (File.Exists(pth_name))
            {
                if (Directory.Exists(pth_db))
                {
                    if (File.Exists(pth_jpeg))
                    {
                        if (File.Exists(pth_level_data))
                        {
                            if (File.Exists(pth_level_data_old))
                            {
                                notify_Backup_Bedrock.BalloonTipTitle = "Bedrock Backup";
                                notify_Backup_Bedrock.BalloonTipText = "You're Bedrock world is Backuping";
                                notify_Backup_Bedrock.Visible = true;
                                notify_Backup_Bedrock.ShowBalloonTip(500);
                                ProcessStartInfo startInfo = new ProcessStartInfo();
                                startInfo.FileName = "Backup_Loading_Screen.exe";
                                Process process = new Process();
                                process.StartInfo = startInfo;
                                process.Start();
                                Directory.Delete(@"Temp", true);
                                string folderName = @"Temp\";
                                System.IO.Directory.CreateDirectory(folderName);
                                Arcfilecreat();
                                notify_Backup_Bedrock.Visible = false;
                                process.Kill();
                                MaterialSnackBar finish_Bedrock = new MaterialSnackBar("You're Bedrock world is backup", "OK", true);
                                finish_Bedrock.Show(this);
                            }
                            else
                            {
                                Open_World_Error();

                            }

                        }
                        else
                        {
                            Open_World_Error();
                        }
                    }
                    else
                    {
                        Open_World_Error();
                    }
                }
                else
                {
                    Open_World_Error();
                }
            }
            else
            {
                Open_World_Error();
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
                            Directory.Delete(@"Temp", true);
                            string folderName = @"Temp\";
                            System.IO.Directory.CreateDirectory(folderName);
                            notify_Backup_Java.Visible = false;
                            Arcfilecreat_Java();
                            process.Kill();
                            MaterialSnackBar finish_Java = new MaterialSnackBar("You're Java world is backup", "OK", true);
                            finish_Java.Show(this);
                        }
                        else
                        {
                            Open_World_Error_Java();
                        }
                    }
                    else
                    {
                        Open_World_Error_Java();
                    }
                }
                else
                {
                    Open_World_Error_Java();
                }
            }
            else
            {
                Open_World_Error_Java();
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
            }
            else
            {
                Edtitions.Text = "Bedrock";
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
                MessageBox.Show("The Open World and Save World Toolboxes are empty               " +
                            "For instructions on using this program, refer to the Help Button", "Sky Cloud Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Save_World_TextBox.Text.Length == 0)
                {
                    MessageBox.Show("The Open World and Save World Toolboxes are empty               " +
                         "For instructions on using this program, refer to the Help Button", "Sky Cloud Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        /////////////////////////////////////Errors///////////////////////////////////////////////////////////////////////
        private void Open_World_Error ()
        {
            this.WindowState = FormWindowState.Normal;
            notify_tray.Visible = false;
            this.ShowInTaskbar = true;
            this.Show();
            this.Activate();
            Open_Word_Text.Clear();
            Backup_Button.Enabled = false;
            MaterialDialog Error_04 = new MaterialDialog(this, "Sky Cloud Backup", "The File Selected isn't a valid Bedrock Minecraft World, Please try again", "Ok", true, "Cancel");
            Error_04.ShowDialog(this);
            Directory.Delete(@"Temp", true);
            string folderName = @"Temp\";
            System.IO.Directory.CreateDirectory(folderName);
            this.Hide();
            notify_tray.Visible = true;
            this.ShowInTaskbar = false;

        }

        private void Open_World_Error_Java ()
        {
            this.WindowState = FormWindowState.Normal;
            notify_tray.Visible = false;
            this.ShowInTaskbar = true;
            this.Show();
            this.Activate();
            Open_Word_Text.Clear();
            Backup_Button.Enabled = false;
            MaterialDialog Error_05 = new MaterialDialog(this, "Sky Cloud Backup", "The File Selected isn't a valid Java Minecraft World, Please try again", "Ok", true, "Cancel");
            Error_05.ShowDialog(this);
            Directory.Delete(@"Temp", true);
            string folderName = @"Temp\";
            System.IO.Directory.CreateDirectory(folderName);
            this.Hide();
            notify_tray.Visible = true;
            this.ShowInTaskbar = false;
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

        private void notify_tray_BalloonTipClicked ( object sender, EventArgs e )
        {

        }

        /////////////////////////////////////Chk_and_guess_edu///////////////////////////////////////////////////////////////////////

        private void chk_and_guess_Main ()
        {
            string sourceDirectory = Properties.Settings.Default.World_Location = Open_Word_Text.Text;
            string targetDirectory = @"Temp";
            Copy(sourceDirectory, targetDirectory);
            if (!Directory.Exists(targetDirectory))
            {
                Copy(sourceDirectory, targetDirectory);
                Chkgubed();
                Chkgujav();
            }
            else
            {
                string folderName = @"Temp";
                string pathString = Path.Combine(folderName, "");
                System.IO.Directory.CreateDirectory(pathString);
                Copy(sourceDirectory, targetDirectory);
                Chkgubed();
                Chkgujav();
            }
        }

        private void Chkgubed ()
        {
            string pth_name = @"Temp\levelname.txt";
            string pth_db = @"Temp\db";
            string pth_jpeg = @"Temp\world_icon.jpeg";
            string pth_level_data = @"Temp\level.dat";
            string pth_level_data_old = @"Temp\level.dat_old";
            if (File.Exists(pth_name))
            {
                if (Directory.Exists(pth_db))
                {
                    if (File.Exists(pth_jpeg))
                    {
                        if (File.Exists(pth_level_data))
                        {
                            if (File.Exists(pth_level_data_old))
                            {
                                Edtitions.Checked = false;
                                Directory.Delete(@"Temp", true);
                                string folderName = @"Temp\";
                                System.IO.Directory.CreateDirectory(folderName);
                            }
                            else
                            {
                                Error_chkgu();
                            }

                        }
                        else
                        {
                            Error_chkgu();
                        }
                    }
                    else
                    {
                        Error_chkgu();
                    }
                }
                else
                {
                    Error_chkgu();
                }
            }
            else
            {
                Error_chkgu();
            }
        }

        private void Chkgujav ()
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
                            MessageBox.Show("Yo");
                            Edtitions.Checked = true;
                            Directory.Delete(@"Temp", true);
                            string folderName = @"Temp\";
                            System.IO.Directory.CreateDirectory(folderName);
                        }
                        else
                        {
                            Error_chkgu();
                        }
                    }
                    else
                    {
                        Error_chkgu();
                    }
                }
                else
                {
                    Error_chkgu();
                }
            }
            else
            {
                Error_chkgu();
            }
        }

        private void Error_chkgu ()
        {
            Directory.Delete(@"Temp", true);
            string folderName = @"Temp\";
            System.IO.Directory.CreateDirectory(folderName);
            bool optionIsSelected = ( ( Edtitions.Checked == false ) || ( Edtitions.Checked == false ) );
            if (!optionIsSelected)
            {
                MaterialDialog Error_05 = new MaterialDialog(this, "Sky Cloud Backup", "The File Selected isn't a valid Minecraft World, Please try again", "Ok", true, "Cancel");
                Error_05.ShowDialog(this);
                Open_Word_Text.Clear();
            }
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
                //Properties.Settings.Default.Reset = true;
                Properties.Settings.Default.first_strtup = false;
                Properties.Settings.Default.Save();
                this.Show();
                Application.Restart();
            }
        }
    }

}
