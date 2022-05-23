using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Sky_Cloud_Backup.assets
{
    public partial class initialize
    {
        gle_div gle_div = new gle_div();
        strtup stup = new strtup();
        Main_Screen Main = new Main_Screen();
        
        private void Chk_Default_name ()
        {
            MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;
            if ( Main.Deafualt_Backup_name.Checked)
            {
                Main.Backup_name_for.Hide();
                Main.Backup_Name.Hide();
            }
            else
            {
                Main.Backup_name_for.Show();
                Main.Backup_Name.Show();
            }
        }

        private void Chk_Reset ()
        {
            if (Properties.Settings.Default.Reset == true)
            {
                MaterialDialog Reset = new MaterialDialog(Main, "Sky Cloud Backup", "Reset Complete", "OK", true, "Cancel", true);
                Reset.ShowDialog(Main);
                Properties.Settings.Default.Reset = false;
                Properties.Settings.Default.Save();
            }
        }

        private void Minto_strt ()
        {
            if (Main.Strt_Win.Checked)
            {
                Main.notify_tray.BalloonTipTitle = " The app is in System tray";
                Main.notify_tray.BalloonTipText = "To disable the app from starting, uncheck Start with Windows checkbox";
                Main.notify_tray.Visible = true;
                Main.notify_tray.ShowBalloonTip(500);
                Main.Hide();
                Main.ShowInTaskbar = false;
            }
        }

        private void Nofrm_strt ()
        {
            Main.Show();
            Main.notify_tray.Visible = false;
            this.ShowInTaskbar = true;
            this.Activate();
        }

        private void Chk_txtbx_fld_Op ()
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
    }
}
