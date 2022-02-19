using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Sky_Cloud_Backup
{
    public partial class Copying_files: Form
    {
        public Copying_files ()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Backuping your world";
        }

        private void Cancel_Button_Click ( object sender, EventArgs e )
        {
            this.Text = "Canceling Backup";
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Directory.Delete(@"Temp", true);
            string folderName = @"Temp\";
            System.IO.Directory.CreateDirectory(folderName);
            this.Close();
        }

    }
}
