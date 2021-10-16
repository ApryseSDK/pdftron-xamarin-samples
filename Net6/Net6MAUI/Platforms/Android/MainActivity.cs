using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Maui;
using pdftron.PDF.Controls;

namespace Net6MAUI
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var config = new pdftron.PDF.Config.ViewerConfig.Builder().OpenUrlCachePath(this.CacheDir.AbsolutePath).Build();
            var intent = DocumentActivity.IntentBuilder.FromActivityClass(this, Java.Lang.Class.FromType(typeof(DocumentActivity))).WithUri(Android.Net.Uri.Parse("https://pdftron.s3.amazonaws.com/downloads/pdfref.pdf")).UsingConfig(config).Build();
            StartActivity(intent);
        }
    }
}
