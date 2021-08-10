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
           Assert.AreEqual(HttpStatusCodes.OK.ToString(), Requests.GetStatusCode().ToString(), "Status code is NOT 200");
        }

        [Test]
        public void HttpResponseHeaderTest()
        {
            Assert.AreEqual("application/json; charset=utf-8", Requests.GetResponseHeader(), "Response header doesn't correspond to expected");
        }

        [Test]
        public void HttpResponseBodyTest()
        {
            var expectedLength = 10;
            Root[] users = JsonConvert.DeserializeObject<Root[]>(Requests.GetResponseBody());
            Assert.AreEqual(expectedLength, users.Length, "Users quantity doesnt equal to expected");
        }
    }
}
