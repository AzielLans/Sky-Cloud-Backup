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
        public static string[] Scopes = { DriveService.Scope.Drive };
        public string clientId = "658559336885-8403eb4go15hb0pk623166f85e5sgstk.apps.googleusercontent.com";
        public string clientSecret = "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";
        public UserCredential GetUserCredential()
        {
            string creadPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            creadPath = Path.Combine(creadPath, "Sky Cloud Backup");

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            }, Scopes, "User", CancellationToken.None, new FileDataStore(creadPath, true)).Result;

            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Sky Cloud Backup",
            });
            credential.GetAccessTokenForRequestAsync();
            return credential;
        }

        //public DriveService GetDriveService ( UserCredential credential )
        //{
        //    return new DriveService(

        //       new BaseClientService.Initializer
        //       {
        //           HttpClientInitializer = credential,
        //           ApplicationName = "Sky Cloud Backup"
        //       });
        //    service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
        //}

        public static File Upload_to_Drive(DriveService service, string filename, string filepath)
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
                return request.ResponseBody;

            }

        }
    }
}
