using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Web_services
{
    public static class Requests
    {

        public static HttpWebResponse MakeGetRequest()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://jsonplaceholder.typicode.com/users");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return response;
        }
        public static string GetResponseBody()
        {
            string responseBody = String.Empty;
            
            using (Stream s = MakeGetRequest().GetResponseStream())
            {
                using (StreamReader r = new StreamReader(s))
                {
                    responseBody = r.ReadToEnd();
                }
            }
            return responseBody;
        }

        public static HttpStatusCode GetStatusCode()
        {
            HttpStatusCode statusCode = MakeGetRequest().StatusCode;
            return statusCode;
        }

        public static string GetResponseHeader()
        {
            string responceHeader = MakeGetRequest().GetResponseHeader("Content-Type");
            return responceHeader;
        }

        public static HttpStatusCode MakePostRequest()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://api.github.com/gists/fcdb3660-1739-41fc-b7ba-ea40917cbf8f");
            request.Method = "POST";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = request.GetRequestStream())
            {
                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    streamWriter.Write("");
                }
            }
            return response.StatusCode;
        }

        public static HttpStatusCode MakeDeleteRequest()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://api.github.com/gists/a3403efe2cf7b90c0800c1ad1bc0aa17");
            request.Method = "DELETE";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = request.GetRequestStream())
            {
                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    streamWriter.Write("");
                }
            }
            return response.StatusCode;
        }

        public static async Task<string> GetAuthorizeToken()
        {
            string responseObj = string.Empty;
            using (var client = new HttpClient())
            { 
                client.BaseAddress = new Uri("https://github.com/login/oauth/authorize");
 
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
                HttpResponseMessage response = new HttpResponseMessage();
                List<KeyValuePair<string, string>> allIputParams = new List<KeyValuePair<string, string>>();

                HttpContent requestParams = new FormUrlEncodedContent(allIputParams);

                response = await client.PostAsync("ghu_16C7e42F292c6912E7710c838347Ae178B4a", requestParams).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    // Reading Response.   
                }
            }

            return responseObj;
        }




    }
}
