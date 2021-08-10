using System;
using System.IO;
using System.Net;


namespace Web_services
{

    public enum HttpStatusCodes
    {
        OK = 200,
        Unauthorized = 401,
        Forbidden = 403,
        InternalServerError = 500
    }
    public static class Requests
    {
        public static HttpWebResponse MakeGetRequest()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://jsonplaceholder.typicode.com/users");
            request.Method = "GET";
            return (HttpWebResponse)request.GetResponse();
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
            return MakeGetRequest().StatusCode;
        }

        public static string GetResponseHeader()
        {
            return MakeGetRequest().GetResponseHeader("Content-Type");
        }

        public static HttpWebResponse MakePostRequest(string id)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://jsonplaceholder.typicode.com/users");
            request.Method = "POST";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = request.GetRequestStream())
            {
                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    streamWriter.Write(id);
                }
            }
            return response;
        }
    }
}
