using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using FFImageLoading;
using Xamarin.Forms.Platform.Android;
using FFImageLoading.Config;
using Xamarin.Forms;

namespace Theatre.Droid
{
    [Activity(Label = "Theatre", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            
            FFImageLoading.Forms.Droid.CachedImageRenderer.Init();
            var config = new Configuration
            {
                HttpClient = new HttpClient(handler: new ModernHttpClient.NativeMessageHandler()),
                FadeAnimationDuration = 250,
            };
            FFImageLoading.ImageService.Instance.Initialize(config);

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }

        async void downloadAsync(object sender, System.EventArgs ea)
        {
            /* later add cookies
                CookieManager cookieManager = CookieManager.Instance;
                String cookie = cookieManager.GetCookie (value);
            */

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

            File.WriteAllBytes(localPath, imageBytes); // writes to local storage   

            var localImage = new Java.IO.File(localPath);
            if (localImage.Exists())
            {

                global::Android.Net.Uri uri = global::Android.Net.Uri.FromFile(localImage);

                var intent = new Intent(Intent.ActionView, uri);
                //  intent.SetType ("application/pdf");

                intent.SetDataAndType(global::Android.Net.Uri.FromFile(localImage), "application/pdf");

                this.StartActivity(intent);
            }
        }
    }
}

