using NUnit.Framework;
using System.Net.Http;
using System;
using Newtonsoft.Json;

namespace Web_services
{
    [TestFixture]
    [Parallelizable]
    public class Tests
    {
        [Test]        
        public void HttpStatusCodeTest()
        {
            var url = "https://gist.github.com/KDunchyk/21242eb6b0de3b39c94039c31ddc2bef";
            var token = "Your_token";
            var request = Requests.BuildAuthenticationRequest(url, token);
            var response = Requests.GetResponse(request);
            Assert.AreEqual("OK", response.StatusCode.ToString(), "Status code is NOT 200");
        }

        [Test]
        public void HttpResponseHeaderTest()
        {
            Assert.AreEqual("application/json; charset=utf-8", Requests.GetResponseHeader(), "Response header doesn't orrespond to expected");
        }

        [Test]
        public void HttpResponseBodyTest()
        {
            Root[] users = JsonConvert.DeserializeObject<Root[]>(Requests.GetResponseBody());
            Assert.AreEqual(10, users.Length, "Users quantity is not 10");
        }

        [Test]
        public void HttpPostRequestTest()
        {
            Assert.AreEqual("OK", Requests.MakePostRequest(), "Status code is NOT OK");
        }

        [Test]
        public void HttpDeleteRequestTest()
        {
            Assert.AreEqual("OK", Requests.MakeDeleteRequest(), "Status code is NOT OK");
        }
    }
}
