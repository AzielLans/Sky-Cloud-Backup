﻿using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Sky_Cloud_Backup
{
    public partial class first_strtup: MaterialForm
    {
        public first_strtup ()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue400, Accent.Cyan700, TextShade.WHITE);
        }

        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;

        private void pictureBox1_Click ( object sender, EventArgs e )
        {

        }

        private void materialLabel3_Click ( object sender, EventArgs e )
        {

        }

        private void Default_Button_CheckedChanged ( object sender, EventArgs e )
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.LightBlue900, Primary.LightBlue400, Accent.Cyan700, TextShade.WHITE);
        }

        private void Green_Button_CheckedChanged ( object sender, EventArgs e )
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.LightGreen400, TextShade.BLACK);
        }

        private void Pink_Button_CheckedChanged ( object sender, EventArgs e )
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Pink800, Primary.Pink900, Primary.Pink500, Accent.Pink200, TextShade.BLACK);
        }

        private void Red_Button_CheckedChanged ( object sender, EventArgs e )
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Red800, Primary.Red900, Primary.Red500, Accent.Red200, TextShade.BLACK);
        }

        private void Dark_mode_switch_CheckedChanged ( object sender, EventArgs e )
        {
            if (Dark_mode_switch.Checked)
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.DARK;
                Dark_mode_switch.Text = "Dark Mode";
            }
            else
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.LIGHT;
                Dark_mode_switch.Text = "Light Mode";
            }
        }

        private void Next_Button_Click ( object sender, EventArgs e )
        {
            Properties.Settings.Default.Mode = Dark_mode_switch.Checked;
            Properties.Settings.Default.Default_Color = Default_Button.Checked;
            Properties.Settings.Default.Green = Green_Button.Checked;
            Properties.Settings.Default.Pink = Pink_Button.Checked;
            Properties.Settings.Default.Red = Red_Button.Checked;
            Properties.Settings.Default.first_strtup = true;
            Properties.Settings.Default.Save();
            Main_Screen f2 = new Main_Screen();
            f2.Show();
            this.Hide();
        }

        private void Help_Button_Click ( object sender, EventArgs e )
        {
            if (Application.OpenForms.OfType<Help>().Any())
            {
                Help frm = new Help();
                frm.Hide();
                frm.Activate();
            }
            else
            {
                Help frm = new Help();
                frm.Show();
                frm.Activate();
            }
        }

        private void first_strtup_Load ( object sender, EventArgs e )
        {
            this.Activate();
        }

        private void first_strtup_FormClosing ( object sender, FormClosingEventArgs e )
        {
            Application.Exit();
        }
    }
}
