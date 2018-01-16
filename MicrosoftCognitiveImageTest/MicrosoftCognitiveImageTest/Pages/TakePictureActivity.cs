using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Android.Provider;
using Android.Graphics;
using MicrosoftCognitiveImageTest.Helpers;

namespace MicrosoftCognitiveImageTest.Pages
{
    [Activity(Label = "TakePictureActivity", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class TakePictureActivity : Activity
    {
        private ImageView PictureImageView;
        private Button takePictureButton;
        private Button showDescriptionButton;
        private TextView textdESCRIPTION;
        public bool ifIMakeAPicture = false;
        private File imageDirectory;
        private File imageFile;
        private Bitmap imageBitmap;


        private Android.Net.Uri fileNamePath;
        private const int PICK_IMAGE_REQUEST = 71;
        ///  //////
        public static string FileimagePath;
        MicrosoftVisual ImageShowData;
        string MyApiLocation = "westcentralus";
        string MyApiKey = "b945399a0a4b413aadb3bf63634f8635";
        string ChosenVisualFetures = "Description";


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.take_a_picture);
            FindViews();
            HandleEvents();
            imageDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "ImageDescription");
            if (!imageDirectory.Exists())
            {
                imageDirectory.Mkdirs();
            }
        }

        private void FindViews()
        {
            PictureImageView = FindViewById<ImageView>(Resource.Id.rayPictureImageView);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
            showDescriptionButton = FindViewById<Button>(Resource.Id.descriptionButton);
            textdESCRIPTION = FindViewById<TextView>(Resource.Id.textImageDescription);
        }

        private void HandleEvents()
        {
            takePictureButton.Click += TakePictureButton_Click;
            showDescriptionButton.Click += ShowDescriptionButton_Click;
        }

        private void ShowDescriptionButton_Click(object sender, EventArgs e)
        {
            ImageShowData = new MicrosoftVisual(MyApiLocation, MyApiKey, ChosenVisualFetures, imageBitmap);//FileimagePath
            ImageShowData.OnReponse = (resultDescription) =>
            {
                foreach (var caption in resultDescription.description.captions)
                {
                    textdESCRIPTION.Text = caption.text;
                };
            };
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            //Intent intent = new Intent(MediaStore.ActionImageCapture);

            //while (imageFile == null)
            //{
            //    imageFile = new File(imageDirectory, String.Format("PictureDescribe{0}.jpg", Guid.NewGuid()));
            //   // if (imageFile != null) break;
            //}
            //intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));

            //StartActivityForResult(intent, 0);

            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), PICK_IMAGE_REQUEST);


        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            //int height = PictureImageView.Height;
            //int width = PictureImageView.Width;
            //imageBitmap = ImageHelper.GetImageBitmapFromFilePath(imageFile.Path, width, height);

            //if (imageBitmap != null)
            //{
            //    PictureImageView.SetImageBitmap(imageBitmap);
            //    imageBitmap = null;
            //    FileimagePath = imageFile.Path;

            //}

            //// required to avoid memory leaks!
            //GC.Collect();

            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == PICK_IMAGE_REQUEST && resultCode == Result.Ok && data != null && data.Data != null)
            {
                fileNamePath = data.Data;
                try
                {
                    Bitmap bitmap = MediaStore.Images.Media.GetBitmap(ContentResolver, fileNamePath);
                    imageBitmap = bitmap;
                    PictureImageView.SetImageBitmap(bitmap);
                    FileimagePath = fileNamePath.Path;
                }
                catch (IOException ex)
                {
                    ex.PrintStackTrace();
                }

            }



        }
    }
}