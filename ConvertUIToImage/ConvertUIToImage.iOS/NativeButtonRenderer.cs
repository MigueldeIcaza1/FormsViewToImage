using ConvertUIToImage;
using ConvertUIToImage.iOS;
using CoreGraphics;
using Foundation;
using System;
using System.Diagnostics;
using UIKit;

[assembly: Xamarin.Forms.ExportRenderer(typeof(NativeButton), typeof(NativeButtonRenderer))]
namespace ConvertUIToImage.iOS
{
    public class NativeButtonRenderer : Xamarin.Forms.Platform.iOS.ButtonRenderer
    {
        public UIImage UiImage { get; set; }

        public NativeButtonRenderer()
        {
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.TouchUpInside += delegate (object sender, EventArgs e2)
                {

                    var formsView = new FormsPage();

                    var rect = new CGRect(0, 0, 400, 400);
                    var iOSView = FormsViewToNativeiOS.ConvertFormsToNative(formsView.Content, rect);

                    UiImage = ConvertViewToImage(iOSView);
                    SaveImage(UiImage);
                    UIGraphics.EndImageContext();

                };
            }
        }

        private UIImage ConvertViewToImage(UIView iOSView)
        {
            UIGraphics.BeginImageContext(iOSView.Frame.Size);
            iOSView.Layer.RenderInContext(UIGraphics.GetCurrentContext());
            UiImage = UIGraphics.GetImageFromCurrentImageContext();
            return UiImage;
        }

        private void SaveImage(UIImage image)
        {
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string pngFilename = System.IO.Path.Combine(documentsDirectory, DateTime.Now.ToFileTime() + ".png");
            NSData imgData = image.AsPNG();
            NSError err = null;
            if (imgData.Save(pngFilename, false, out err))
            {
                Debug.WriteLine("saved as " + pngFilename);
            }
            else
            {
                Debug.WriteLine("NOT saved as " + pngFilename + " because" + err.LocalizedDescription);
            }
        }

    }
}