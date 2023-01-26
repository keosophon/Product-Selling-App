using Android.Content.Res;
using Android.Graphics;


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
    }
}