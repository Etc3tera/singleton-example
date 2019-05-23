using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Funny
{
    public interface IPostCache
    {
        List<Post> GetAll();
    }

    public sealed class TestablePostCache : IPostCache
    {
        private List<Post> data;

        private static IWebClientFactory factory = new WebClientFactory();
        private static Lazy<IPostCache> instance = new Lazy<IPostCache>(() => new TestablePostCache());

        // For the sake of this example, should not be in production code
        public static bool HasLoaded = false;

        private TestablePostCache()
        {
            cacheData();
        }

        public static IPostCache Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public List<Post> GetAll()
        {
            return data;
        }

        private void cacheData()
        {
            using (var client = factory.GetClient())
            {
                var jsonString = client.DownloadString("https://jsonplaceholder.typicode.com/posts");
                data = JsonConvert.DeserializeObject<List<Post>>(jsonString);
                HasLoaded = true;
            }
        }

        #region For Injection Purpose
        public static void Use(IPostCache cacheInstance)
        {
            instance = new Lazy<IPostCache>(() => cacheInstance);
        }

        public static void UseDefault()
        {
            instance = new Lazy<IPostCache>(() => new TestablePostCache());
        }

        public static void UseFactory(IWebClientFactory factory)
        {
            TestablePostCache.factory = factory;
        }

        public static void UseDefaultFactory()
        {
            factory = new WebClientFactory();
        }
        #endregion
    }
}
