using System.Diagnostics;
using Android.Content;
using Theatre.Droid.DependecyServices;
using Theatre.Services;
using Xamarin.Forms;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Java.IO;

[assembly: Dependency(typeof(CostomLoadPDF))]
namespace Theatre.Droid.DependecyServices
{
    public class CostomLoadPDF : IFileWorker
    {
        public void DownloadPDF(string name, byte[] pfdArray)
        {
            //var directory = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            //directory = System.IO.Path.Combine(directory, Android.OS.Environment.DirectoryDownloads);
            var directory =
                Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
            string filePath = System.IO.Path.Combine(directory.ToString(), name);
            System.IO.File.WriteAllBytes(filePath, pfdArray);
            //using (System.IO.StreamWriter writer = System.IO.File.WriteAllBytes(filePath))
            //{
            //    await writer.wr(pfdArray);
            //}
            var localImage = new Java.IO.File(filePath);
            if (localImage.Exists())
            {

                global::Android.Net.Uri uri = global::Android.Net.Uri.FromFile(localImage);

                var intent = new Intent(Intent.ActionView, uri);

                intent.SetDataAndType(global::Android.Net.Uri.FromFile(localImage), "application/pdf");

                Forms.Context.StartActivity(intent);
            }
        }

        public async void ShowPdfFile()
            {
                string value = ("http://www.axmag.com/download/pdfurl-guide.pdf");

                Uri baseUri = new Uri(value);
                HttpClientHandler clientHandler = new HttpClientHandler();
                //  clientHandler.CookieContainer.Add (baseUri, new Cookie ("Cookie", cookie));
                HttpClient httpClient = new HttpClient(clientHandler);
                httpClient.BaseAddress = baseUri;

                byte[] imageBytes = await httpClient.GetByteArrayAsync(baseUri);

                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                string localFilename = "aa.pdf";
                string localPath = System.IO.Path.Combine(documentsPath, localFilename);

            System.IO.File.WriteAllBytes(localPath, imageBytes); // writes to local storage   

                var localImage = new Java.IO.File(localPath);
                if (localImage.Exists())
                {

                    global::Android.Net.Uri uri = global::Android.Net.Uri.FromFile(localImage);

                    var intent = new Intent(Intent.ActionView, uri);
                    //  intent.SetType ("application/pdf");

                    intent.SetDataAndType(global::Android.Net.Uri.FromFile(localImage), "application/pdf");

                Forms.Context.StartActivity(intent);
                }
            //Debug.WriteLine("TYT");
            //var fileLocation = "file.pdf";
            //var file = new File(fileLocation);

            //if (!file.Exists())
            //{
            //    Debug.WriteLine("NET");
            //    return;
            //}

            //var intent = DisplayPdf(file);
            //Forms.Context.StartActivity(intent);
        }

            public Intent DisplayPdf(File file)
            {
                //Debug.WriteLine("AAA");
                //var intent = new Intent(Intent.ActionView);
                //var filepath = Uri.FromFile(file);
                //intent.SetDataAndType(filepath, "application/pdf");
                //intent.SetFlags(ActivityFlags.ClearTop);
                //return intent;
                return null;
            }
        }
    }