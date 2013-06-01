using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using Gironkey.Controllers;
using Gironkey.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gironkey.Services
{

    public class GironkeyService
    {

        public DataResult GetDataForAddress(string address)
        {
            var result = new DataResult
                {
                    Id = new Guid(),
                    HouseNumber = "50",
                    AddressOne = "Address 1",
                    AddressTwo = "Address 2",
                    Suburb = "Midland",
                    State = "WA",
                    PostCode = "6000",
                    Country = "Australia",
                    Lat = "115",
                    Long = "-35",
                    SquareMeterSize = "600",
                    ZoneCode = "R20"
                };
            return result;
        }

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
                var result = client.PostAsync("ows/wfsCsTenure_4283/wfs?typename=LGATE-068&request=GetFeature&BBOX=115.903071,-31.918348,115.903071,-31.918348", null).Result;
                resultContent = result.Content.ReadAsStringAsync().Result;
                Debug.Print(resultContent);
            }

            return resultContent;
        }

        public async void CallLandgateJson()
        {
            using (var client = new HttpClient())
            {
                var getString = "https://www2.landgate.wa.gov.au/ows/wfspublic_4326/wfs?service=WFS&version=1.0.0&typename=LGATE-069&request=GetFeature&BBOX=115.903071,-31.918348,115.90641,-31.916859&outputformat=json";
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

        public string CallLandgate(string point)
        {
            using (var client = new HttpClient())
            {
                var getString = "https://www2.landgate.wa.gov.au/ows/wfsCsTenure_4283/wfs?service=wfs&version=1.0.0&request=getfeature&typename=LGATE-068&maxfeatures=1&outputformat=json&FILTER=<Filter xmlns:gml=\"http://www.opengis.net/gml\"><Intersects><PropertyName>the_geom</PropertyName><gml:Point srsName=\'EPSG:4326\'><gml:coordinates>" + point + "</gml:coordinates></gml:Point></Intersects></Filter>";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(getString);

                httpWebRequest.Credentials = new NetworkCredential("govhack", "Wz0#Z33O");
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                   
                    Debug.Print(responseText);

                    return responseText;
                }

            }

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

            //// Example #2 
            //// Read each line of the file into a string array. Each element 
            //// of the array is one line of the file. 
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");

            //// Display the file contents by using a foreach loop.
            //System.Console.WriteLine("Contents of WriteLines2.txt = ");
            //foreach (string line in lines)
            //{
            //    // Use a tab to indent each line of the file.
            //    Console.WriteLine("\t" + line);
            //}

            //// Keep the console window open in debug mode.
            //Console.WriteLine("Press any key to exit.");
            //System.Console.ReadKey();


            //string resultContent;

            //using (var client = new HttpClient())
            //{
            //    var baseAddress = "https://" + HttpUtility.UrlEncode("govhack:Wz0#Z33O") + "@www2.landgate.wa.gov.au/";
            //    Debug.Print("BaseAddress: {0}", baseAddress);
            //    client.BaseAddress = new Uri(baseAddress);
            //    var url = "ows/wfsCsTenure_4283/wfs?typename=LGATE-068&request=GetFeature&BBOX=115.903071,-31.918348,115.903071,-31.918348";
            //    Debug.Print(baseAddress+url);
            //    var result = client.GetAsync(url).Result;
            //    resultContent = result.Content.ReadAsStringAsync().Result;
            //    Debug.Print(resultContent);
            //}

            //return resultContent;

        }

        public string CallNewUrl()
        {
            
           var point = "115.90114501745099,-31.915819563332345";
           var slip_wfs_call = "https://govhack:Wz0%23Z33O@www2.landgate.wa.gov.au/ows/wfsCsTenure_4283/wfs?service=wfs&version=1.0.0&request=getfeature&typename=LGATE-068&maxfeatures=1&outputformat=json&FILTER=<Filter xmlns:gml=\"http://www.opengis.net/gml\"><Intersects><PropertyName>the_geom</PropertyName><gml:Point srsName=\'EPSG:4326\'><gml:coordinates>" + point + "</gml:coordinates></gml:Point></Intersects></Filter>";

            //slip_wfs_call = HttpUtility.HtmlEncode(slip_wfs_call);
            //slip_wfs_call = slip_wfs_call.Replace("<", "%3C").Replace(">", "%3E").Replace("\"","%22").Replace(" ", "%20");
            Debug.Print(slip_wfs_call);

            return slip_wfs_call;
        }

    }

    public class Rootobject
    {
        public string type { get; set; }
        public Feature[] features { get; set; }
        public Crs crs { get; set; }
        public float[] bbox { get; set; }
    }

    public class Crs
    {
        public string type { get; set; }
        public Properties properties { get; set; }
    }

    public class Properties
    {
        public string code { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public string id { get; set; }
        public Geometry geometry { get; set; }
        public string geometry_name { get; set; }
        public Properties1 properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public float[][][][] coordinates { get; set; }
    }

    public class Properties1
    {
        public int ogc_fid { get; set; }
        public int polygon_number { get; set; }
        public int land_id_number { get; set; }
        public int usage_code { get; set; }
        public string view_scale { get; set; }
        public string lot_name { get; set; }
        public string piparcel { get; set; }
        public string pityp { get; set; }
        public object alt_pityp { get; set; }
        public int? fol_rec_id { get; set; }
        public int? lot_number { get; set; }
        public string lot_type { get; set; }
        public string address_no_type { get; set; }
        public int? address_no_from { get; set; }
        public object address_no_from_suffix { get; set; }
        public object address_no_to { get; set; }
        public string rd_name { get; set; }
        public string rd_type { get; set; }
        public string locality { get; set; }
        public string postcode { get; set; }
        public string state { get; set; }
        public float centlat { get; set; }
        public float centlong { get; set; }
        public int zone { get; set; }
        public float legal_area { get; set; }
        public string register { get; set; }
        public string proprietor { get; set; }
        public int? dlg_id { get; set; }
        public string dealing_prefix { get; set; }
        public int? dealing_number { get; set; }
        public string dealing_suffix { get; set; }
        public int? dealing_year { get; set; }
        public float area { get; set; }
        public string dealing_type { get; set; }
        public string region { get; set; }
        public string organisation_code { get; set; }
        public string family_name { get; set; }
        public string given_name { get; set; }
        public string date_execution { get; set; }
        public string sale_date { get; set; }
        public string date_time_legal { get; set; }
        public string date_time_polygon_created { get; set; }
        public string date_time_polygon_modified { get; set; }
        public string date_time_boundary_modified { get; set; }
        public float[] bbox { get; set; }
    }

}