using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Funny
{
    public interface IWebClient : IDisposable
    {
        string DownloadString(string address);
    }

    public interface IWebClientFactory
    {
        IWebClient GetClient();
    }

    public class WebClientFactory : IWebClientFactory
    {
        public IWebClient GetClient()
        {
            return new WebClientWrapper();
        }

        private class WebClientWrapper : IWebClient
        {
            private WebClient _client;

            public WebClientWrapper()
            {
                _client = new WebClient();
            }

            public string DownloadString(string address)
            {
                return _client.DownloadString(address);
            }

            public void Dispose()
            {
                _client.Dispose();
            }
        }
    }
}
