﻿using System;
using System.IO;

namespace Sky_Cloud_Backup.assets
{
    internal class Additonal
    {
        public static string environment = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public static string file_path = @"driveApiCredentials/Google.Apis.Auth.OAuth2.Responses.TokenResponse-User";
        public static string path = Path.Combine(environment, file_path);
        public void filedelete(string path, Boolean createfile)
        {
            Directory.Delete(path, true);
            if (createfile == true)
            {
                Directory.CreateDirectory(path);
            }
        }

        public void createfile(string path)
        {
            Directory.CreateDirectory(path);
        }



    }
}
