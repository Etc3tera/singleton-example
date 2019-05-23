using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Funny.Test
{
    [TestClass]
    public class FunnyRepository_Test
    {
        private Mock<IPostCache> mockCache;
        private FunnyRepository testClass;

        [TestInitialize]
        public void Setup()
        {
            mockCache = new Mock<IPostCache>();
            TestablePostCache.Use(mockCache.Object);
            testClass = new FunnyRepository();
        }

        [TestCleanup]
        public void TearDown()
        {
            TestablePostCache.UseDefault();
        }

        [TestMethod]
        public void case_normal_result()
        {
            mockCache.Setup(p => p.GetAll()).Returns(new List<Post>()
            {
                new Post() { Id = 1, Title = "1234", Body = "aa longggggg ja" },
                new Post() { Id = 2, Title = "1234", Body = "aa longgggg ja" },
                new Post() { Id = 3, Title = "", Body = "aa super longgggggggggggggg" },
            });

            var result = testClass.GetSmallestOne();

            Assert.AreEqual(2, result.Id);

            // To Prove that, we've never touched real caching logic. :)
            Assert.IsFalse(TestablePostCache.HasLoaded);
        }

        [TestMethod]
        public void case_empty_result()
        {
            mockCache.Setup(p => p.GetAll()).Returns(new List<Post>());

            var result = testClass.GetSmallestOne();

            Assert.IsNull(result);
            Assert.IsFalse(TestablePostCache.HasLoaded);
        }
    }
}
