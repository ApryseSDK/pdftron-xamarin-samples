using pdftron;
using pdftron.PDF.Controls;

namespace Net6iOS;

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    public override UIWindow? Window
    {
        get;
        set;
    }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        // adding the document controller to a navigation controller
        // this is needed so the document controller's navigation toolbar renders
        var documentController = new PTDocumentController();
        var navigationController = new UINavigationController(documentController);

        // attach navigation controller to window
        Window.RootViewController = navigationController;

        // make the window visible
        Window.MakeKeyAndVisible();

        // open the document
        documentController.OpenDocumentWithURL(new Uri("https://pdftron.s3.amazonaws.com/downloads/pdfref.pdf"));

        return true;
    }
}

