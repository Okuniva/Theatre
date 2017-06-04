using System.Net.Http;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading;
using Xamarin.Forms.Platform.Android;
using FFImageLoading.Config;

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
    }
}

