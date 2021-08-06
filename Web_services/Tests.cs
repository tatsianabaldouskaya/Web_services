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
           Assert.AreEqual("OK", Requests.GetStatusCode().ToString(), "Status code is NOT 200");
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
    }
}
