using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using gironkeyapi.Models;

namespace gironkeyapi.Services
{
    public class GironkeyService
    {
        public string CallWeb()
        {
            string resultContent;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.lythixdesigns.com");
                var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("", "login")
                    });

                //var result = client.PostAsync("/api/Membership/exists", content).Result;
                var result = client.PostAsync("", null).Result;
                resultContent = result.Content.ReadAsStringAsync().Result;
                Debug.Print(resultContent);
            }

            return resultContent;
        }

        public string CallLandgateOrig()
        {
            string resultContent;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www2.landgate.wa.gov.au/");
                var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("", "login")
                    });

                //var result = client.PostAsync("/api/Membership/exists", content).Result;
                var result =
                    client.PostAsync(
                        "ows/wfsCsTenure_4283/wfs?typename=LGATE-068&request=GetFeature&BBOX=115.903071,-31.918348,115.903071,-31.918348",
                        null).Result;
                resultContent = result.Content.ReadAsStringAsync().Result;
                Debug.Print(resultContent);
            }

            return resultContent;
        }

        public async void CallLandgateJson()
        {
            using (var client = new HttpClient())
            {
                var getString =
                    "https://www2.landgate.wa.gov.au/ows/wfspublic_4326/wfs?service=WFS&version=1.0.0&typename=LGATE-069&request=GetFeature&BBOX=115.903071,-31.918348,115.90641,-31.916859&outputformat=json";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(getString);
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    //Now you have your response.
                    //or false depending on information in the response
                    //return true;

                    Debug.Print(responseText);
                }

            }

        }

        public Rootobject CallLandgate(string latitude, string longitude)
        {

            if (string.IsNullOrEmpty(latitude) && string.IsNullOrEmpty(longitude))
            {
                throw new ArgumentNullException("latitude & longitude");
            }
            
            if (string.IsNullOrEmpty(latitude))
            {
                throw new ArgumentNullException("latitude");
            }
            
            if (string.IsNullOrEmpty(longitude))
            {
                throw new ArgumentNullException("longitude");
            }

            using (var client = new HttpClient())
            {
                var getString =
                    "https://www2.landgate.wa.gov.au/ows/wfsCsTenure_4283/wfs?service=wfs&version=1.0.0&request=getfeature&typename=LGATE-068&maxfeatures=1&outputformat=json&FILTER=<Filter xmlns:gml=\"http://www.opengis.net/gml\"><Intersects><PropertyName>the_geom</PropertyName><gml:Point srsName=\'EPSG:4326\'><gml:coordinates>" +
                    longitude + "," + latitude + "</gml:coordinates></gml:Point></Intersects></Filter>";

                var httpResponse = GetHttpWebResponse(getString);

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();

                    var jsonRoot = (Rootobject)JsonConvert.DeserializeObject(responseText, typeof(Rootobject), new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                    return jsonRoot;
                }
            }
        }

        private static HttpWebResponse GetHttpWebResponse(string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.Credentials = new NetworkCredential("govhack", "Wz0#Z33O");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return httpResponse;
        }

        public string CallLandgateGetJson()
        {

            //newFilePath = Server.MapPath("\\" + DateTime.Now.Ticks + Request.Files["txtImportFile"].FileName);
            //string[] temp_string = Request.Files["txtImportFile"].FileName.Split(new char[] { '\\' });
            //string temp_filename = temp_string[temp_string.Count() - 1];
            ////newFilePath = Server.MapPath("\\temp\\" + DateTime.Now.Ticks + Request.Files["txtImportFile"].FileName);
            //newFilePath = Server.MapPath("\\temp\\" + DateTime.Now.Ticks + temp_filename);
            //Request.Files["txtImportFile"].SaveAs(newFilePath);

            //StreamReader reader = new StreamReader(newFilePath);
            //string contents = reader.ReadToEnd();
            //reader.Close();

            var dataPath = @"bin\Services\data.txt";
            // System.Web.HttpContext.Current.Request.MapPath(@"~\\bin\Services\data.txt");

            string path = AppDomain.CurrentDomain.BaseDirectory;

            var text = System.IO.File.ReadAllText(Path.Combine(path, dataPath));

            // Display the file contents to the console. Variable text is a string.
            Debug.WriteLine("Contents of WriteText.txt = {0}", text);

            var foo = JsonConvert.DeserializeObject(text, typeof(Rootobject));

            return foo.ToString();



        }

        public string CallNewUrl()
        {

            var point = "115.90114501745099,-31.915819563332345";
            var slip_wfs_call =
                "https://govhack:Wz0%23Z33O@www2.landgate.wa.gov.au/ows/wfsCsTenure_4283/wfs?service=wfs&version=1.0.0&request=getfeature&typename=LGATE-068&maxfeatures=1&outputformat=json&FILTER=<Filter xmlns:gml=\"http://www.opengis.net/gml\"><Intersects><PropertyName>the_geom</PropertyName><gml:Point srsName=\'EPSG:4326\'><gml:coordinates>" +
                point + "</gml:coordinates></gml:Point></Intersects></Filter>";

            //slip_wfs_call = HttpUtility.HtmlEncode(slip_wfs_call);
            //slip_wfs_call = slip_wfs_call.Replace("<", "%3C").Replace(">", "%3E").Replace("\"","%22").Replace(" ", "%20");
            Debug.Print(slip_wfs_call);

            return slip_wfs_call;
        }

    }



}