using Android.Content.Res;
using Android.Graphics;
using System.Net;
using System.Net.Security;

namespace A1
{
    class BitMapImageCreator
    {
        public static Bitmap CreateBitMapFromName(Resources resource, string name)
        {
            // Retrieving the local Resource ID from the name                    
            int id = (int)typeof(Resource.Drawable).GetField(name).GetValue(null);

            // Converting Drawable Resource to Bitmap
            Bitmap bitmapImg = BitmapFactory.DecodeResource(resource, id);
            return bitmapImg;
        }
        public static Bitmap FetchImage(string urlstr)
        {
            /*
            var uri = Android.Net.Uri.Parse(urlstr);
            return BitmapFactory.DecodeStream(Android.App.Application.Context.ContentResolver.OpenInputStream(uri));
            */
            
            Bitmap imageBitmap = null;
            var webClient = new WebClient();

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            var imageBytes = webClient.DownloadData(urlstr);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    
                }
            
            return imageBitmap;
            
            
        }
    }
}