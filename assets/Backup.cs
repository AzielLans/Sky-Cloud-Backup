using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace Sky_Cloud_Backup.assets.Backup
{
    public partial class Main_Backup_Bedrock
    {
        Chk_Backup chkup = new Chk_Backup();
        Rename_Backup rename = new Rename_Backup();
        Copy_Backup Coup = new Copy_Backup();
        Error GetError = new Error();

        public void Main_Bedrock_Backup ()
        {
            var Main = new Main_Screen();
            string sourceDirectory = Properties.Settings.Default.World_Location = Main.Open_Word_Text.Text;
            string targetDirectory = @"Temp";
            Copy_Backup.Copy(sourceDirectory, targetDirectory);
            if (!Directory.Exists(targetDirectory))
            {
                Copy_Backup.Copy(sourceDirectory, targetDirectory);
                chkup.Chk_World_Bedrock();
            }
            else
            {
                string folderName = @"Temp";
                string pathString = Path.Combine(folderName, "");
                System.IO.Directory.CreateDirectory(pathString);
                Copy_Backup.Copy(sourceDirectory, targetDirectory);
                chkup.Chk_World_Bedrock();
            }
            Main.Backup_Button.Enabled = true;
        }
        public void Arcfilecreat ()
        {
            var Main = new Main_Screen();
            try
            {
                if (Main.zip_mcworld.Checked)
                {
                    if (File.Exists(@"Temp\Backup Bedrock world.zip"))
                    {

                        Random_Name_Bedrock();
                    }
                    else
                    {
                        string sourceDirectoryName = Properties.Settings.Default.World_Location = Main.Open_Word_Text.Text;
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
                        string sourceDirectoryName = Properties.Settings.Default.World_Location = Main.Open_Word_Text.Text;
                        string destinationArchiveFileName = @"Temp\Backup Bedrock world.mcworld";
                        CreatFrDir(sourceDirectoryName, destinationArchiveFileName);
                    }
                }
            }
            catch (IOException exp)
            {
                string Error_txt = exp.Message;
                GetError.Dialog_error(Error_txt);
            }
        }
        public void CreatFrDir ( string sourceDirectoryName, string destinationArchiveFileName )
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
            Random_Name_Bedrock();
        }
        public void Random_Name_Bedrock ()
        {
            RenameMcworldFiles(@"Temp");
            rename.Rename_Backup_Customs_Main();
            Coup.Copy_Output();
        }
        public void RenameMcworldFiles ( string path )
        {
            var Main = new Main_Screen();
            if (Main.zip_mcworld.Checked)
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
    }
    public partial class Main_Backup_Java
    {
        Chk_Backup chkup = new Chk_Backup();
        Rename_Backup rename = new Rename_Backup();
        Copy_Backup Coup = new Copy_Backup();
        Error GetError = new Error();

        public void Main_Java_Backup ()
        {
            var Main = new Main_Screen();
            string sourceDirectory = Properties.Settings.Default.World_Location = Main.Open_Word_Text.Text;
            string targetDirectory = @"Temp";
            Copy_Backup.Copy(sourceDirectory, targetDirectory);
            if (!Directory.Exists(targetDirectory))
            {
                Copy_Backup.Copy(sourceDirectory, targetDirectory);
                chkup.Chk_World_Java();
            }
            else
            {
                string folderName = @"Temp";
                string pathString = Path.Combine(folderName, "");
                System.IO.Directory.CreateDirectory(pathString);
                Copy_Backup.Copy(sourceDirectory, targetDirectory);
                chkup.Chk_World_Java();
            }
            Main.Backup_Button.Enabled = true;
        }
        public void Arcfilecreat_Java ()
        {
            var Main = new Main_Screen();
            try
            {
                if (File.Exists(@"Temp\Backup Java world.zip"))
                {
                    Random_Name_Java();
                }
                else
                {
                    string sourceDirectoryName = Properties.Settings.Default.World_Location = Main.Open_Word_Text.Text;
                    string destinationArchiveFileName = @"Temp\Backup Java world.zip";
                    CreatFrDir_Java(sourceDirectoryName, destinationArchiveFileName);
                }

            }
            catch (IOException exp)
            {
                string Error_txt = exp.Message;
                GetError.Dialog_error(Error_txt);
            }
        }
        public void CreatFrDir_Java ( string sourceDirectoryName, string destinationArchiveFileName )
        {
            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
            rename.Rename_Backup_Customs_Main();
            Random_Name_Java();
        }
        public void Random_Name_Java ()
        {
            RenameJavaFiles(@"Temp");
            rename.Rename_Backup_Customs_Main();
            Coup.Copy_Output();
        }
        public static void RenameJavaFiles ( string path )
        {
            foreach (var filename in Directory.GetFiles(path))
            {
                string suffix = ( DateTime.Now.ToString("MM_dd_yyyy_hh_mm_ss") ).ToString(CultureInfo.InvariantCulture);
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                var newFilename = string.Format("{0}({1}).zip", fileNameWithoutExtension, suffix);
                var newFullFilename = Path.Combine(path, newFilename);
                File.Move(filename, newFullFilename);
            }
        }
    }

    public partial class Copy_Backup
    {
        /////////////////////////////////////Copy_Input_Backup///////////////////////////////////////////////////////////////////////

        public static void Copy ( string sourceDirectory, string targetDirectory )
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll ( DirectoryInfo source, DirectoryInfo target )
        {
            Error GetError = new Error();
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
                string Error_txt = exp.Message;
                GetError.Dialog_error(Error_txt);
            }
        }

        /////////////////////////////////////Copy_Output_Backup////////////////////llllll///////////////////////////////////////////////////
        public void Copy_Output ()
        {
            var Main = new Main_Screen();
            string sourceDirectory = @"Temp\";
            string targetDirectory = Properties.Settings.Default.Save_Location = Main.Save_World_TextBox.Text;
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);
            CopyAll(diSource, diTarget);
        }
    }

    public partial class Chk_Backup
    {
        Main_Backup_Bedrock Maup = new Main_Backup_Bedrock();
        Main_Backup_Java Maupja = new Main_Backup_Java();
        Error GetError = new Error();
        public void Chk_World_Bedrock ()
        {
            var Main = new Main_Screen();
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
                            Main.notify_Backup_Bedrock.BalloonTipTitle = "Bedrock Backup";
                            Main.notify_Backup_Bedrock.BalloonTipText = "You're Bedrock world is Backuping";
                            Main.notify_Backup_Bedrock.Visible = true;
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.FileName = "Backup_Loading_Screen.exe";
                            Process process = new Process();
                            process.StartInfo = startInfo;
                            process.Start();
                            Directory.Delete(@"Temp", true);
                            string folderName = @"Temp\";
                            System.IO.Directory.CreateDirectory(folderName);
                            Maup.Arcfilecreat();
                            Main.notify_Backup_Bedrock.Visible = false;
                            process.Kill();
                            Directory.Delete(@"Temp", true);
                            System.IO.Directory.CreateDirectory(folderName);
                        }
                        else
                        {
                            string txt = "The File Selected isn't a valid Bedrock Minecraft World, Please try again";
                            GetError.Dialog_error(txt);
                        }

                    }
                    else
                    {
                        string txt = "The File Selected isn't a valid Bedrock Minecraft World, Please try again";
                        GetError.Dialog_error(txt);
                    }
                }
                else
                {
                    string txt = "The File Selected isn't a valid Bedrock Minecraft World, Please try again";
                    GetError.Dialog_error(txt);
                }
            }
            else
            {
                string txt = "The File Selected isn't a valid Bedrock Minecraft World, Please try again";
                GetError.Dialog_error(txt);
            }
        }

        public void Chk_World_Java ()
        {
            var Main = new Main_Screen();
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
                            Main.notify_Backup_Java.BalloonTipTitle = "Java Backup";
                            Main.notify_Backup_Java.BalloonTipText = "You're Java world is Backuping";
                            Main.notify_Backup_Java.Visible = true;
                            Main.notify_Backup_Java.ShowBalloonTip(500);
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.FileName = "Backup_Loading_Screen.exe";
                            Process process = new Process();
                            process.StartInfo = startInfo;
                            process.Start();
                            Directory.Delete(@"Temp", true);
                            string folderName = @"Temp\";
                            System.IO.Directory.CreateDirectory(folderName);
                            Main.notify_Backup_Java.Visible = false;
                            Maupja.Arcfilecreat_Java();
                            process.Kill();
                            Directory.Delete(@"Temp", true);
                            System.IO.Directory.CreateDirectory(folderName);
                        }
                        else
                        {
                            string txt = "The File Selected isn't a valid Java Minecraft World, Please try again";
                            GetError.Dialog_error(txt);
                        }
                    }
                    else
                    {
                        string txt = "The File Selected isn't a valid Java Minecraft World, Please try again";
                        GetError.Dialog_error(txt);
                    }
                }
                else
                {
                    string txt = "The File Selected isn't a valid Java Minecraft World, Please try again";
                    GetError.Dialog_error(txt);
                }
            }
            else
            {
                string txt = "The File Selected isn't a valid Java Minecraft World, Please try again";
                GetError.Dialog_error(txt);
            }

        }
    }

    public partial class Rename_Backup
    {
        Chk_Backup chkup = new Chk_Backup();
        Rename_Backup rename = new Rename_Backup();
        Copy_Backup Coup = new Copy_Backup();

        // Custom Rename
        public void Rename_Backup_Customs_Main ()
        {
            var Main = new Main_Screen();
            if (Main.Backup_name_for.Checked)
            {
                if (!string.IsNullOrEmpty(Main.Backup_Name.Text))
                {
                    if (Main.Deafualt_Backup_name.Checked)
                    {
                        if (Main.Edtitions.Checked)
                            Rename_Backup_Custom_Java(Properties.Settings.Default.Defualt_name_textbox = Main.Backup_Name.Text);
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Main.Backup_Name.Text))
                {
                    if (Main.Deafualt_Backup_name.Checked)
                    {
                        Rename_Backup_Custom_Bedrock(Properties.Settings.Default.Defualt_name_textbox = Main.Backup_Name.Text);
                    }
                }
            }
        }

        public void Rename_Backup_Custom_Bedrock ( string name )
        {
            var Main = new Main_Screen();
            if (Main.zip_mcworld.Checked)
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
    }
}
