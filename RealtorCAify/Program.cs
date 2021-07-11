using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using RestSharp;

namespace RealtorCAify
{
    class Program
    {
        private const string BaseUrl = "https://api2.realtor.ca";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var client = new RestClient(BaseUrl);

            RestRequest restRequest = new RestRequest("/Listing.svc/PropertySearch_Post", Method.POST);

            SetupRequestHeaders(restRequest);

            SetupRequestBody(restRequest);

            var result = await client.ExecutePostAsync(restRequest);


            //
            // var root = @"https://www.realtor.ca";
            // var html = @"https://www.realtor.ca/map#ZoomLevel=11&Center=48.402436%2C-89.236990&LatitudeMax=48.55060&LongitudeMax=-88.77488&LatitudeMin=48.25384&LongitudeMin=-89.69910&view=list&CurrentPage=2&Sort=1-D&PGeoIds=g30_f08e2tde&GeoName=Thunder%20Bay%2C%20ON&PropertyTypeGroupID=1&PropertySearchTypeId=1&TransactionTypeId=2&PriceMin=200000&PriceMax=450000&Currency=CAD";
            //
            // var web = new HtmlWeb();
            // var doc = web.Load(html);
            // var iframes = doc.DocumentNode.SelectNodes("//iframe[@src]");
            // foreach (var iframe in iframes)
            // {
            //     var iframeUrl = iframe.Attributes["src"].Value;
            //
            //     if (iframeUrl.StartsWith("/"))
            //     {
            //         iframeUrl = root + iframeUrl;
            //     }
            //
            //     //string noSrcOuterHTML = iframe.OuterHtml.Replace("src=" + "\"" + iframeUrl + "\"", string.Empty);
            //
            //     var iframeContent = web.Load(iframeUrl);
            //     var clonedIframe = HtmlNode.CreateNode(iframeContent.DocumentNode.InnerHtml);
            //         
            //     var parent = iframe.ParentNode;
            //     iframe.ParentNode.ReplaceChild(clonedIframe, iframe);
            //
            //     //iframe.InnerHtml = iframeDocument.DocumentNode.InnerHtml;
            // }
            // var outerHtml = doc.DocumentNode.OuterHtml;            
            //
            // // HtmlWeb web = new HtmlWeb();
            // //
            // // var doc = await web.LoadFromWebAsync(html);
            // //
            // //
            // // HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//iframe[@src]");
            // //
            // //
            // // foreach(var node in nodes){
            // //     HtmlAttribute attr = node.Attributes["src"];
            // //     Console.WriteLine(attr.Value);
            // // }  
        }

        private static void SetupRequestBody(RestRequest restRequest)
        {
            var requestParameters = new Dictionary<string, Object>();

            requestParameters.Add("CultureId", 1);
            requestParameters.Add("ApplicationId", 37);
            var existingUrlParameters = HttpUtility.ParseQueryString("");

            foreach (string parameterKey in existingUrlParameters.Keys)
            {
                requestParameters.Add(parameterKey, existingUrlParameters[parameterKey] ?? "");
            }

            foreach (var parameter in requestParameters)
            {
                restRequest.AddParameter(parameter.Key, parameter.Value, ParameterType.GetOrPost);
            }
        }

        // private static void SetupRequestBody(RestRequest restRequest)
        // {
        //     var requestBody = new ExpandoObject() as IDictionary<string, Object>;;
        //
        //     requestBody.Add("CultureId", 1);
        //     requestBody.Add("ApplicationId", 37);
        //     var parameters = HttpUtility.ParseQueryString(
        //
        //     foreach (string parameterKey in parameters.Keys)
        //     {
        //         requestBody.Add(parameterKey, parameters[parameterKey] ?? "");
        //     }
        //
        //     string requestBodyJson = JsonConvert.SerializeObject(requestBody);
        //
        //     restRequest.AddJsonBody(requestBodyJson);
        // }

        private static void SetupRequestHeaders(RestRequest restRequest)
        {
            restRequest.AddHeader("Host", "api2.realtor.ca");
            restRequest.AddHeader("User-Agent",
                "");
            restRequest.AddHeader("Accept", "*/*");
            restRequest.AddHeader("Accept-Language", "en-CA,en-US;q=0.7,en;q=0.3");
            restRequest.AddHeader("Accept-Encoding", "gzip, deflate, br");
            restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            restRequest.AddHeader("Content-Length", "291");
            restRequest.AddHeader("Origin", "https://www.realtor.ca");
            restRequest.AddHeader("DNT", "1");
            restRequest.AddHeader("Connection", "keep-alive");
            restRequest.AddHeader("Referer", "https://www.realtor.ca/");
            restRequest.AddHeader("Cookie",
                "");
            restRequest.AddHeader("Pragma", "no-cache");
            restRequest.AddHeader("Cache-Control", "no-cache");
            restRequest.AddHeader("TE", "Trailers");
        }
    }
}