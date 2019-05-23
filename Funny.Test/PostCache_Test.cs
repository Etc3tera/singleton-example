using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funny.Test
{
    [TestClass]
    public class PostCache_Test
    {
        [TestMethod]
        public void can_cache_properly()
        {
            var mockFactory = new Mock<IWebClientFactory>();
            var mockClient = new Mock<IWebClient>();
            mockFactory.Setup(p => p.GetClient()).Returns(mockClient.Object);

            // inject faked factory to Our Testing Singleton Object
            TestablePostCache.UseFactory(mockFactory.Object);

            // mock return value of WebClient
            // Since, we hard code parameter of DownloadString anyway, so we have no point to validate parameter of DownloadString
            mockClient.Setup(p => p.DownloadString(It.IsAny<string>())).Returns(@"
                [
                  {
                    ""userId"": 1,
                    ""id"": 2,
                    ""title"": ""title"",
                    ""body"": ""body""
                  }
                ]");

            // Let our cache run
            var results = TestablePostCache.Instance.GetAll();

            Assert.IsTrue(TestablePostCache.HasLoaded);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(1, results[0].UserId);
            Assert.AreEqual(2, results[0].Id);
            Assert.AreEqual("title", results[0].Title);
            Assert.AreEqual("body", results[0].Body);
        }
    }
}
