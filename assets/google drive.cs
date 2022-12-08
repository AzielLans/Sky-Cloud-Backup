using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;
using File = Google.Apis.Drive.v3.Data.File;

namespace Sky_Cloud_Backup
{
    public partial class google_drive
    {
        public static string ApplicationName = "Sky Cloud Backup";
        private static string[] Scopes = { DriveService.Scope.Drive };
        public UserCredential GetUserCredential ()
        {
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string creadPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                creadPath = Path.Combine(creadPath, "driveApiCredentials");


                return GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "User",
                    CancellationToken.None, new FileDataStore(creadPath, true)).Result;
            }
        }

        public DriveService GetDriveService ( UserCredential credential )
        {
            return new DriveService(
               new BaseClientService.Initializer
               {
                   HttpClientInitializer = credential,
                   ApplicationName = ApplicationName
               }
                );
        }

        public static void Upload_to_Drive ( DriveService service, string filename, string filepath )
        {
            var fileMatadata = new File();
            fileMatadata.Name = filename;
            fileMatadata.MimeType = "application/zip";


            FilesResource.CreateMediaUpload request;
            using (var stream = new System.IO.FileStream(filepath, System.IO.FileMode.Open))
            {
                request = service.Files.Create(fileMatadata, stream, "image/jpeg");
                request.Fields = "id";
                request.Upload();
            }
        }
    }
}
