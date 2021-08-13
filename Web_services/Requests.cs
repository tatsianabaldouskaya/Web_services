using System;
using System.IO;
using System.Net;
using System.Net.Http;

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

        public static HttpRequestMessage BuildAuthenticationRequest(string url, string token) 
        {
            var uriBuilder = new UriBuilder(url);
            uriBuilder.Query = $"access_token={token}";
            var request = new HttpRequestMessage();
            request.RequestUri = uriBuilder.Uri;
            request.Headers.Add("User-Agent", "My C# Client");
            return request;
        }

        public static HttpResponseMessage GetResponse(HttpRequestMessage request)
        {
            var client = new HttpClient();
            HttpResponseMessage response = client.SendAsync(request).Result;       
            return response;
        }              
    }
}
