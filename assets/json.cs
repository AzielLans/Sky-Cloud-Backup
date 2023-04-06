namespace Sky_Cloud_Backup.assets
{
    class setsetting
    {
        public bool Mode = false;

        // Colors
        public bool Default_Color { get; set; }
        public bool Green { get; set; }
        public bool Pink { get; set; }
        public bool Red { get; set; }
        public bool Amber { get; set; }
        public bool Orange { get; set; }
        public bool Deep_Purple { get; set; }


        //Backup
        public string World_Location { get; set; }
        public string Save_Location { get; set; }
        public string Defualt_name_textbox { get; set; }

        public bool Editions { get; set; }
        public bool Chk_zip_mcowrld { get; set; }
        public bool Upload_To_Drive { get; set; }
        public bool Defualt_name_chkbx { get; set; }
        public bool Backup_name_for { get; set; }

        //Additional
        public bool strtwin { get; set; }
        public bool Always_on_top { get; set; }
        public bool Minimize_to_Form { get; set; }
        public bool backupdialog { get; set; }
        public bool AutoSave { get; set; }

        public bool DeveloperMode { get; set; }
        public bool Reset { get; set; }
        public bool FirstRun { get; set; }

    }
}
