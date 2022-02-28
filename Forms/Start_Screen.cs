using System;
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
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            load_timer.Start();
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

        private void ver_Click ( object sender, EventArgs e )
        {

        }

        private void loading_screen_Load ( object sender, EventArgs e )
        {

        }

        private void pictureBox1_Click ( object sender, EventArgs e )
        {
            Application.Exit();
        }
        private void pictureBox1_Click_1 ( object sender, EventArgs e )
        {

        }

        private void load_timer_Tick ( object sender, EventArgs e )
        {
            if (Properties.Settings.Default.Reset == true)
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
                if (Properties.Settings.Default.Reset == true)
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
    }
}
