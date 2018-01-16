using Android.Graphics;
using System.Net;

namespace MicrosoftCognitiveImageTest.Helpers
{
        class ImageHelper
        {
            public static Bitmap GetImageBitmapFromUrl(string url)
            {
                Bitmap imageBitmap = null;
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }
                return imageBitmap;
            }

            public static Bitmap GetImageBitmapFromFilePath(string fileName, int width, int height)
            {
                // first we get the the dimensions of the file on disk
                BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
                BitmapFactory.DecodeFile(fileName, options);

                // next we calculate the ratio that we need to resize the image by 
                // in order to fit the requested dimensions
                int outHeight = options.OutHeight;
                int outWidth = options.OutWidth;
                int inSampleSize = 1;

                if (outHeight > height || outWidth > width)
                {
                    inSampleSize = outWidth > outHeight
                                    ? outHeight / height
                                    : outWidth / width;
                }

                // now we will load the image and have BitmapFactory resize it for us
                options.InSampleSize = inSampleSize;
                options.InJustDecodeBounds = false;
                Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

                return resizedBitmap;
            }


        }


    
}