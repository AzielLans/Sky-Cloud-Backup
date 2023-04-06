using Newtonsoft.Json;
using Sky_Cloud_Backup.assets;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sky_Cloud_Backup
{
    public partial class loading_screen : Form
    {

        public loading_screen()
        {
            InitializeComponent();
            JsonLoader();
            this.Text = "Starting";
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            load_timer.Start();
            Dev_Mode_fle_chk();
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
                    ((AssemblyInformationalVersionAttribute)attributes[0]).InformationalVersion;

            }
        }

        public bool Reset { get; private set; }
        private void loading_screen_Load(object sender, EventArgs e)
        {

        }

        private void Dev_Mode_fle_chk()
        {
            string chk_cnl = "Cancel";
            if (Properties.Settings.Default.Dev_Mode == true)
            {
                Properties.Settings.Default.Dev_Mode = true;
                Dev_Label.Show();
                Ues_label.Show();
                Reset_label.Show();
                Cancel_backup_info.Show();
                if (Properties.Settings.Default.GlobalReset == true)
                {
                    Reset_label.Text = "Reset: Yes";
                }
                if (Properties.Settings.Default.first_strtup == true)
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

        private void load_timer_Tick(object sender, EventArgs e)
        {
            Load_Panel.Width += 10;
            if (Load_Panel.Width >= 591)
            {
                load_timer.Stop();
                if (Properties.Settings.Default.first_strtup == true)
                {
                    FirstRun f2 = new FirstRun();
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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void loading_screen_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void JsonLoader()
        {
            if (!File.Exists(@"settings.json"))
            {
                setsetting sjs = new setsetting()
                {
                    Mode = false,
                    Default_Color = true,
                    Green = false,
                    Pink = false,
                    Red = false,
                    Amber = false,
                    Orange = false,
                    Deep_Purple = false,
                    Upload_To_Drive = false,
                    World_Location = null,
                    Save_Location = null,
                    Always_on_top = false,
                    Minimize_to_Form = false,
                    Editions = false,
                    strtwin = false,
                    Chk_zip_mcowrld = false,
                    Defualt_name_textbox = null,
                    Defualt_name_chkbx = false,
                    Backup_name_for = false,
                    Reset = false,
                    FirstRun = true,
                    DeveloperMode = false,
                    backupdialog = true
                };
                string stringjson = JsonConvert.SerializeObject(sjs);
                File.WriteAllText(@"settings.json", stringjson);
            }
            using (StreamReader r = new StreamReader(@"settings.json"))
            {
                string json = r.ReadToEnd();
                setsetting account = JsonConvert.DeserializeObject<setsetting>(json);
                Properties.Settings.Default.GlobalReset = account.Reset;
                Properties.Settings.Default.Dev_Mode = account.DeveloperMode;
                Properties.Settings.Default.first_strtup = account.FirstRun;
            }
            Properties.Settings.Default.Save();

        }
    }
}
