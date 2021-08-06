using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        public static HttpWebResponse MakePostRequest()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://jsonplaceholder.typicode.com/users");
            request.Method = "POST";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = request.GetRequestStream())
            {
                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    streamWriter.Write("id: 11");
                }
            }
            return response;
        }


    }
}
