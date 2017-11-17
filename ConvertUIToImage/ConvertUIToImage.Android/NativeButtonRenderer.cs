using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using droid = Android;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using ConvertUIToImage;
using ConvertUIToImage.Droid;

[assembly: ExportRenderer(typeof(NativeButton), typeof(NativeButtonRenderer))]
namespace ConvertUIToImage.Droid
{
    public class NativeButtonRenderer : ButtonRenderer
    {
        public droid.Views.ViewGroup AndroidView { get; set; }

        public NativeButtonRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.Click += Control_Click;
            }
        }

        void Control_Click(object sender, System.EventArgs e)
        {
            // The Forms Page that you want to create image
            var formsView = new FormsPage();

            //Converting forms page to native view
            AndroidView = FormsToNativeDroid.ConvertFormsToNative(formsView.Content, new Rectangle(0, 0, 400, 800));

            // Converting View to BitMap
            var bitmap = ConvertViewToBitMap(AndroidView);

            // Saving image in mobile local storage
            SaveImage(bitmap);
        }

        private Bitmap ConvertViewToBitMap(droid.Views.ViewGroup view)
        {

            Bitmap bitmap = Bitmap.CreateBitmap(1000, 1600, Bitmap.Config.Argb8888);
            Canvas canvas = new Canvas(bitmap);
            canvas.DrawColor(droid.Graphics.Color.White);
            view.Draw(canvas);
            return bitmap;
        }

        private void SaveImage(Bitmap bitmap)
        {
            var sdCardPath = droid.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var fileName = System.IO.Path.Combine(sdCardPath, DateTime.Now.ToFileTime() + ".png");
            using (var os = new FileStream(fileName, FileMode.CreateNew))
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 95, os);
            }

            Toast.MakeText(AndroidView.Context, "Image saved Successfully..!  at " + fileName, ToastLength.Long).Show();
        }

    }
}