using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Microsoft.Projectoxford.Vision;
using Com.Microsoft.Projectoxford.Vision.Contract;
using System;
using System.IO;
using GoogleGson;
using Newtonsoft.Json;
using MicrosoftCognitiveImageTest.Model;
using System.Collections.Generic;
using Java.Lang;

namespace MicrosoftCognitiveImageTest
{
    [Activity(Label = "DetectDescriptionActivity" ,MainLauncher =false, Theme ="@style/Theme.AppCompat.Light.NoActionBar")]
    public class DetectDescriptionActivity : AppCompatActivity
    {

        public VisionServiceRestClient visionServices = new VisionServiceRestClient("b945399a0a4b413aadb3bf63634f8635");

        private Bitmap mBitMap;
        private ImageView imageView;




        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.imageCognizerLayout);





            mBitMap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.im1);
            imageView = FindViewById<ImageView>(Resource.Id.imageView);
            imageView.SetImageBitmap(mBitMap);


            Button btnProcess = FindViewById<Button>(Resource.Id.buttonProcess);
            byte[] bitmapData;


            using (var stream = new MemoryStream())
            {
                mBitMap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                bitmapData = stream.ToArray();
            }
            Stream imputStream = new MemoryStream(bitmapData);

            btnProcess.Click += delegate
            {
                new VisionTask(this).Execute(imputStream);
            };
        }


        class VisionTask : AsyncTask<Stream,string,string>
        {
            private DetectDescriptionActivity detectDescriptionActivity;
            private ProgressDialog mDialog = new ProgressDialog(Application.Context);


            public VisionTask(DetectDescriptionActivity detectDescriptionActivity)
            {
                this.detectDescriptionActivity = detectDescriptionActivity;
            }

            protected override void OnPreExecute()
            {
                mDialog.Window.SetType(Android.Views.WindowManagerTypes.SystemAlert);
                mDialog.Show();
            }
            protected override void OnProgressUpdate(params string[] values)
            {
                mDialog.SetMessage(values[0]);
            }

            protected override string RunInBackground(params Stream[] @params)
            {
                try
                {
                    PublishProgress("Recognizing...");
                    string[] features = {"Description"};
                    string[] details = { };

                    AnalysisResult result = detectDescriptionActivity.visionServices.AnalyzeImage(@params[0],features,details);

                    string stresult = new Gson().ToJson(result);
                    return stresult;

                }
                catch (Java.Lang.Exception ex)
                {
                    return null;
                }
            }

            protected override void OnPostExecute(string result)
            {
                mDialog.Dismiss();
                var analisysResult = JsonConvert.DeserializeObject<AnalisisResultModel>(result);

                TextView txtDesc = detectDescriptionActivity.FindViewById<TextView>(Resource.Id.textView);

                StringBuilder strBuilder = new StringBuilder();

                foreach (var caption in analisysResult.description.captions) {

                    strBuilder.Append(caption.text);
                    txtDesc.Text = strBuilder.ToString();
                }


            }

        }
        
    }
}

   