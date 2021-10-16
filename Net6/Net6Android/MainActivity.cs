using pdftron.PDF.Controls;

namespace Net6Android
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var config = new pdftron.PDF.Config.ViewerConfig.Builder().OpenUrlCachePath(this.CacheDir.AbsolutePath).Build();
            var intent = DocumentActivity.IntentBuilder.FromActivityClass(this, Java.Lang.Class.FromType(typeof(DocumentActivity))).WithUri(Android.Net.Uri.Parse("https://pdftron.s3.amazonaws.com/downloads/pdfref.pdf")).UsingConfig(config).Build();
            StartActivity(intent);
        }
    }
}
