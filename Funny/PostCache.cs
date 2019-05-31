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

    public sealed class PostCache : IPostCache
    {
        private List<Post> data;

        private static IWebClientFactory factory = new WebClientFactory();
        private static Lazy<IPostCache> instance = new Lazy<IPostCache>(() => new PostCache());

        private PostCache()
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

        #region For Injection Purpose
        public static void Use(IPostCache cacheInstance)
        {
            instance = new Lazy<IPostCache>(() => cacheInstance);
        }

        public static void UseDefault()
        {
            instance = new Lazy<IPostCache>(() => new PostCache());
        }

        public static void UseFactory(IWebClientFactory factory)
        {
            PostCache.factory = factory;
        }

        public static void UseDefaultFactory()
        {
            factory = new WebClientFactory();
        }
        #endregion

        private void cacheData()
        {
            using (var client = factory.GetClient())
            {
                var jsonString = client.DownloadString("https://jsonplaceholder.typicode.com/posts");
                data = JsonConvert.DeserializeObject<List<Post>>(jsonString);
            }
        }
    }
}
