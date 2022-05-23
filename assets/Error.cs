using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Windows.Forms;
using System.IO;

namespace Sky_Cloud_Backup.assets
{
    public partial class Error
    {
        public void Dialog_error( string Error_txt)
        {
            Main_Screen Main = new Main_Screen();
            MaterialDialog Error_01 = new MaterialDialog(Main, "Sky Cloud Backup", Error_txt, "Ok", true, "Cancel");
            Error_01.ShowDialog(Main);
        }

        public void Backup_error(string txt)
        {
            var Main = new Main_Screen();
            Main.WindowState = FormWindowState.Normal;
            Main.notify_tray.Visible = false;
            Main.ShowInTaskbar = true;
            Main.Show();
            Main.Activate();
            Main.Open_Word_Text.Clear();
            Main.Backup_Button.Enabled = false;
            Directory.Delete(@"Temp", true);
            string folderName = @"Temp\";
            System.IO.Directory.CreateDirectory(folderName);
            Main.Hide();
            Main.notify_tray.Visible = true;
            Main.ShowInTaskbar = false;
            string Error_txt = txt;
            Dialog_error(Error_txt);
        }
    }
}
