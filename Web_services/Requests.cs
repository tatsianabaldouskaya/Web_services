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
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://api.github.com/gists/public");
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

        public static async Task<HttpResponseMessage> GetAuthorizeTokenAsync()
        {       
            using (var client = new HttpClient())
            { 
                client.BaseAddress = new Uri("https://github.com/login/oauth/authorize");
                var token = "YOUR_Token";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync("https://api.github.com/gists/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return response;
            }          
        }
    }
}
