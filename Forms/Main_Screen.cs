﻿using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
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
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue400, Accent.Cyan700, TextShade.WHITE);
            Sigin_in_Button.Enabled = false;
            string folderName = "Temp";
            string pathString = Path.Combine(folderName, "");
            System.IO.Directory.CreateDirectory(pathString);
        }

        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;

        private void Chk_atstarp_Backup ()
        {
            if (Open_Word_Text.Text.Length == 10)
            {
                if (Save_World_TextBox.Text.Length == 10)
                {
                    Backup_Button.Enabled = true;
                }
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
            Copy_Bedrock(sourceDirectory, targetDirectory);
            if (!Directory.Exists(targetDirectory))
            {
                Copy_Bedrock(sourceDirectory, targetDirectory);
                Chk_World_Bedrock();
            }
            else
            {
                string folderName = @"Temp";
                string pathString = Path.Combine(folderName, "");
                System.IO.Directory.CreateDirectory(pathString);
                Copy_Bedrock(sourceDirectory, targetDirectory);
                Chk_World_Bedrock();
            }
            Backup_Button.Enabled = true;
        }

        public static void Copy_Bedrock ( string sourceDirectory, string targetDirectory )
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll ( DirectoryInfo source, DirectoryInfo target )
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
        private void Arcfilecreat ()
        {
            if (File.Exists(@"Temp\Backup Bedrock world.mcworld"))
            {
                Copy_Output();
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
                MessageBox.Show(exp.Message);
            }
        }
        private void CreatFrDir ( string sourceDirectoryName, string destinationArchiveFileName )
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
            Copy_Output();
        }
        private void Random_Name_Bedrock ()
        {
            RenameMcworldFiles(Save_World_TextBox.Text = Properties.Settings.Default.Save_Location);
        }
        private static void RenameMcworldFiles ( string path )
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
        /////////////////////////////////////Copy_Output_Backup///////////////////////////////////////////////////////////////////////
        public void Copy_Output ()
        {
            string sourceDirectory = @"Temp\";
            string targetDirectory = Properties.Settings.Default.Save_Location = Save_World_TextBox.Text;
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);
            CopyAll_Output(diSource, diTarget);
            if (Edtitions.Checked)
            {
                Random_Name_Java();
            }
            else
            {
                Random_Name_Bedrock();
            }
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
                    CopyAll(diSourceSubDir, nextTargetSubDir);
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
            Copy_Java(sourceDirectory, targetDirectory);
            if (!Directory.Exists(targetDirectory))
            {
                Copy_Java(sourceDirectory, targetDirectory);
                Chk_World_Java();
            }
            else
            {
                string folderName = @"Temp";
                string pathString = Path.Combine(folderName, "");
                System.IO.Directory.CreateDirectory(pathString);
                Copy_Java(sourceDirectory, targetDirectory);
                Chk_World_Bedrock();
            }
            Backup_Button.Enabled = true;
        }

        public static void Copy_Java ( string sourceDirectory, string targetDirectory )
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll_Java(diSource, diTarget);
        }

        public static void CopyAll_Java ( DirectoryInfo source, DirectoryInfo target )
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
        private void Arcfilecreat_Java ()
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
            try
            {
            }
            catch (IOException exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        private void CreatFrDir_Java ( string sourceDirectoryName, string destinationArchiveFileName )
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
            Copy_Output();
        }
        private void Random_Name_Java ()
        {
            RenameJavaFiles(Save_World_TextBox.Text = Properties.Settings.Default.Save_Location);
        }
        private static void RenameJavaFiles ( string path )
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
                                Directory.Delete(@"Temp", true);
                                string folderName = @"Temp\";
                                System.IO.Directory.CreateDirectory(folderName);
                                Arcfilecreat();
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
            string pth_level_dat = @"Tmep\level.dat_old";
            string pth_session_lock = @"Temp\session.lock";
            if (File.Exists(pth_icon))
            {
                if (File.Exists(pth_level))
                {
                    if (File.Exists(pth_level_dat))
                    {
                        if (File.Exists(pth_session_lock))
                        {
                            Directory.Delete(@"Temp", true);
                            string folderName = @"Temp\";
                            System.IO.Directory.CreateDirectory(folderName);
                            Arcfilecreat_Java();
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
        /////////////////////////////////////Resize to form///////////////////////////////////////////////////////////////////////

        private void Main_Screen_Resize ( object sender, EventArgs e )
        {
            if (Minimize_Systray.Checked)
            {
                notify_tray.BalloonTipTitle = " The app is minimize to Tray.";
                notify_tray.BalloonTipText = "To maximize the app, double click the icon.";

                if (FormWindowState.Minimized == this.WindowState)
                {
                    notify_tray.Visible = true;
                    notify_tray.ShowBalloonTip(500);
                    this.Hide();
                }
                else if (FormWindowState.Normal == this.WindowState)
                {
                    notify_tray.Visible = false;
                }
            }
        }

        private void notify_tray_MouseDoubleClick ( object sender, MouseEventArgs e )
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
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
        }
        /////////////////////////////////////Errors///////////////////////////////////////////////////////////////////////
        private void Open_World_Error ()
        {
            MessageBox.Show("The File Selected isn't a valid Minecraft World " + "Please try again", "Sky Cloud Bakup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Open_Word_Text.Clear();
            Directory.Delete(@"Temp", true);
            string folderName = @"Temp\";
            System.IO.Directory.CreateDirectory(folderName);
        }

        private void Help_Button_Click ( object sender, EventArgs e )
        {
            Help help = new Help();
            help.Show();
        }
    }
}
