using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Funny
{
    public sealed class PostCache
    {
        private List<Post> data;
        private static Lazy<PostCache> instance = new Lazy<PostCache>(() => new PostCache());

        private PostCache()
        {
            cacheData();
        }

        public static PostCache Instance
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
            using (var client = new WebClient())
            {
                var jsonString = client.DownloadString("https://jsonplaceholder.typicode.com/posts");
                data = JsonConvert.DeserializeObject<List<Post>>(jsonString);
            }
        }
    }
}
