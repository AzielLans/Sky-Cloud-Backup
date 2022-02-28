using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Sky_Cloud_Backup
{
    public partial class Copying_files: MaterialForm
    {
        public Copying_files ()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            wht_txr.Text = "Backuping your world";
        }

        private void Cancel_Button_Click ( object sender, EventArgs e )
        {
            wht_txr.Text = "Canceling Backup";
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Directory.Delete(@"Temp", true);
            string folderName = @"Temp\";
            System.IO.Directory.CreateDirectory(folderName);
            this.Close();
        }

    }
}
