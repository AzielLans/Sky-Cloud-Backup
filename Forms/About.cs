using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Sky_Cloud_Backup
{
    public partial class About: MaterialForm
    {
        public About ()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            linkLabel1.LinkVisited = false;
        }
        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;

        private void linkLabel1_LinkClicked ( object sender, LinkLabelLinkClickedEventArgs e )
        {
            try
            {
                VisitLink();
            }
            catch (Exception ex)
            {
                Error_10(ex.Message);
            }
        }

        private void VisitLink ()
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/Involts/Sky-Cloud-Backup");
        }

        private void Error_10 ( string text )
        {
            MessageBox.Show(text, "Sky Cloud Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void About_Load ( object sender, EventArgs e )
        {

        }
    }
}
