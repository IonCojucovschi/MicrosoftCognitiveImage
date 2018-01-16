using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Java.IO;
using Android.Provider;
using Android.Graphics;
using MicrosoftCognitiveImageTest.Helpers;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using MicrosoftCognitiveImageTest.Model;

namespace MicrosoftCognitiveImageTest
{
    public class MicrosoftVisual
    {
        private string MyApiLocation { get; set; } ///ex-   westcentralus
        private string MyApiKey { get; set; }/// ex-   b945399a0a4b413aadb3bf63634f8635
        private string ChosenVisualFetures { get; set; }///ex- Description   or multi chose Description,Tags,Categories  
        static byte[] byteData;
        public string _imagePath;
        public AnalisisResultModel ResultDescription;
        public Action<AnalisisResultModel> OnReponse;



        public MicrosoftVisual(string ApiLocation,string ApiKey,string chosenVisualFetures,Bitmap imageFilePath)
        {
            MyApiKey = ApiKey;
            MyApiLocation = ApiLocation;
            ChosenVisualFetures = chosenVisualFetures;
           // byteData = System.IO.File.ReadAllBytes(imageFilePath); //// GetImageAsByteArray(imageFilePath);
            using (var bite = new System.IO.MemoryStream()) {
                imageFilePath.Compress(Bitmap.CompressFormat.Jpeg,0,bite);
                byteData = bite.ToArray();
            }
            MakeRequest(MyApiLocation, MyApiKey, ChosenVisualFetures);
        }

        byte[] GetImageAsByteArray(string imageFilePath)
        {
            System.IO.FileStream fileStream = new System.IO.FileStream(imageFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }

        public async void MakeRequest(string myApiLocation,string myApiKey,string chossenVisualFeatures)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers   client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key/*this is api key*/", "{subscription key}");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", myApiKey);
            // Request parameters
            queryString["visualFeatures"] = chossenVisualFeatures;///"Categories";
          //  queryString["details"] = "Celebrities";///"{string}";
            queryString["language"] = "en";
            var uri = "https://"+myApiLocation+".api.cognitive.microsoft.com/vision/v1.0/analyze?" + queryString;//// this is my location api----- westcentralus

            



            HttpResponseMessage response;

            // Request body
            // byte[] byteData = Encoding.UTF8.GetBytes("{body}");
            /// byteData;  is initialized in ctor 

            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                // This example uses content type "application/octet-stream".
                // The other content types you can use are "application/octet-stream" and "multipart/form-data".
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                // Execute the REST API call.
                response = await client.PostAsync(uri, content);

                // Get the JSON response.
                string contentString = await response.Content.ReadAsStringAsync();
                ResultDescription = JsonConvert.DeserializeObject<AnalisisResultModel>(contentString);
                OnReponse?.Invoke(ResultDescription);
            }

            //using (var content = new ByteArrayContent(byteData))
            //{
            //    content.Headers.ContentType = new MediaTypeHeaderValue("< your content type, i.e. application/json >");
            //    response = await client.PostAsync(uri, content);
            //}

        }
    }
}