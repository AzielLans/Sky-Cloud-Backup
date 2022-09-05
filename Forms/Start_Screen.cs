using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sky_Cloud_Backup
{
    public partial class loading_screen: Form
    {
        public loading_screen ()
        {
            InitializeComponent();

            Dev_Mode_fle_chk();
            this.Text = "Starting";
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            Cnl_fle_chk();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
        private static string AssemblyProductVersion
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);
                return attributes.Length == 0 ?
                    "" :
                    ( (AssemblyInformationalVersionAttribute)attributes[0] ).InformationalVersion;

            }
        }

        private void Cnl_fle_chk ()
        {
            string chk_cnl = "Cancel";
            if (File.Exists(chk_cnl))
            {
                File.Delete(chk_cnl);
                Cancel_timer.Start();
            }
            else
            {
                load_timer.Start();
            }
        }

        private void loading_screen_Load ( object sender, EventArgs e )
        {

        }

        private void Dev_Mode_fle_chk ()
        {
            string chk_cnl = "Cancel";
            string chk_dev = @"Developer_Mode";
            if (File.Exists(chk_dev))
            {
                Properties.Settings.Default.Dev_Mode = true;
                Dev_Label.Show();
                Ues_label.Show();
                Reset_label.Show();
                Cancel_backup_info.Show();
                if (Properties.Settings.Default.Resets == true)
                {
                    Reset_label.Text = "Reset: Yes";
                }
                if (Properties.Settings.Default.first_strtup == false)
                {
                    Ues_label.Text = "Use type: first Startup";
                }
                else
                {
                    Ues_label.Text = "Use type: Used";
                }
                if (File.Exists(chk_cnl))
                {
                    Cancel_backup_info.Text = "Backup_Cancel: Yes";
                }
                else
                {
                    Cancel_backup_info.Hide();
                }
            }
            else
            {
                Properties.Settings.Default.Dev_Mode = false;
            }
        }

        private void load_timer_Tick ( object sender, EventArgs e )
        {
            if (Properties.Settings.Default.Resets == true)
            {
                Load_Panel.Width += 4;
            }
            else
            {
                if (Properties.Settings.Default.first_strtup == false)
                {
                    Load_Panel.Width += 2;
                }
                else
                {
                    Load_Panel.Width += 4;
                }
            }
            if (Load_Panel.Width >= 591)
            {
                load_timer.Stop();
                if (Properties.Settings.Default.Resets == true)
                {
                    Main_Screen f2 = new Main_Screen();
                    f2.Show();
                    this.Hide();
                }
                else
                {
                    if (Properties.Settings.Default.first_strtup == false)
                    {
                        first_strtup f2 = new first_strtup();
                        f2.Show();
                        this.Hide();
                    }
                    else
                    {
                        Main_Screen f2 = new Main_Screen();
                        f2.Show();
                        this.Hide();
                    }
                }
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture ();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage ( System.IntPtr hWnd, int wMsg, int wParam, int lParam );
        private void loading_screen_MouseDown ( object sender, MouseEventArgs e )
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Cancel_timer_Tick ( object sender, EventArgs e )
        {
            Load_Panel.Width += 591;
            if (Load_Panel.Width >= 591)
            {
                Cancel_timer.Stop();
                if (Properties.Settings.Default.first_strtup == false)
                {
                    first_strtup first = new first_strtup();
                    first.Show();
                }
                else
                {
                    Main_Screen f2 = new Main_Screen();
                    f2.Show();
                }
                this.Hide();


            }
        }
    }
}
