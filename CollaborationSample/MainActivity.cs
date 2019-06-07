using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

using Android.Arch.Lifecycle;

using pdftron.PDF.Controls;
using pdftron.PDF.Config;

using pdftron.Collab.UI.Viewer;
using pdftron.Collab.ViewModel;
using pdftron.Collab.WebViewerServer;


namespace CollaborationSample
{
    [Activity(Label = "@string/app_name", Theme = "@style/CustomAppTheme", MainLauncher = true,
        WindowSoftInputMode = SoftInput.AdjustPan,
        ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize | Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.KeyboardHidden)]
    public class MainActivity : AppCompatActivity
    {

        CollabViewerTabHostFragment mPdfViewCtrlTabHostFragment;

        // To start collaboration, go to
        // https://www.pdftron.com/webviewer/demo/document-collaboration?shareId=8v7y2IgzUELQ&cId=https%3A%2F%2Fpdftron.s3.amazonaws.com%2Fdownloads%2Fpl%2FReport_2011.pdf
        // or open this sample on different devices
        string DEFAULT_SHARE_ID = "8v7y2IgzUELQ";
        string DEFAULT_FILE_URL = "https://pdftron.s3.amazonaws.com/downloads/pl/Report_2011.pdf";
        string WVS_ROOT = "https://demo.pdftron.com/";

        BlackBoxConnection mBlackBoxConnection;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            mBlackBoxConnection = new BlackBoxConnection(this.ApplicationContext);
            
            var fileUri = Android.Net.Uri.Parse(DEFAULT_FILE_URL);
            StartTabHostFragment(fileUri, "");
        }

        public override void OnBackPressed()
        {
            bool handled = false;
            if (mPdfViewCtrlTabHostFragment != null)
            {
                handled = mPdfViewCtrlTabHostFragment.HandleBackPressed();
            }
            if (!handled)
            {
                base.OnBackPressed();
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            mBlackBoxConnection.Stop();
        }

        private void CreateViewerFragment(Android.Net.Uri fileUri)
        {
            var viewerConfig = new ViewerConfig.Builder()
                .MultiTabEnabled(false)
                .OpenUrlCachePath(this.CacheDir.AbsolutePath)
                .Build();

            mPdfViewCtrlTabHostFragment = (CollabViewerTabHostFragment)CollabViewerBuilder
                .WithUri(fileUri)
                .UsingConfig(viewerConfig)
                .Build(this);
        }

        private void StartTabHostFragment(Android.Net.Uri fileUri, String password)
        {
            if (IsFinishing)
            {
                return;
            }

            Android.Support.V4.App.FragmentTransaction ft = this.SupportFragmentManager.BeginTransaction();
            CreateViewerFragment(fileUri);

            mPdfViewCtrlTabHostFragment.NavButtonPressed += (sender, e) =>
            {
                Finish();
            };
            mPdfViewCtrlTabHostFragment.LastTabClosed += (sender, e) =>
            {
                Finish();
            };
            mPdfViewCtrlTabHostFragment.TabDocumentLoaded += (sender, e) =>
            {
                HandleTabDocumentLoaded(e.P0);
            };

            ft.Replace(Resource.Id.container, mPdfViewCtrlTabHostFragment, null);
            ft.Commit();
        }

        private void HandleTabDocumentLoaded(String tag)
        {
            DocumentViewModel documentViewModel = (DocumentViewModel) ViewModelProviders.Of(this).Get(Java.Lang.Class.FromType(typeof(DocumentViewModel)));
            documentViewModel.SetCustomConnection(mBlackBoxConnection);
            mBlackBoxConnection.Start(WVS_ROOT, DEFAULT_FILE_URL, DEFAULT_SHARE_ID);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

