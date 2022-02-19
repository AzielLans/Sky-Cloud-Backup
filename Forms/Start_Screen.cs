using System;
using System.Reflection;
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
            Load_Panel.Width += 3;
            if (Load_Panel.Width >= 591)
            {
                load_timer.Stop();
                Main_Screen f2 = new Main_Screen();
                f2.Show();
                this.Hide();
            }
        }
    }
}
