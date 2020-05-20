using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClimaCellCore.Services
{
    public sealed class ZipHttpClient : IHttpClient
    {
        private readonly HttpClientHandler handler = new HttpClientHandler();
        private readonly HttpClient httpClient;

        public ZipHttpClient()
        {
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            }

            httpClient = new HttpClient(handler);
        }

        public async Task<HttpResponseMessage> HttpRequestAsync(string requestString) =>
            await httpClient.GetAsync(new Uri(requestString)).ConfigureAwait(false);

        #region IDisposable Support

        private bool disposedValue;
        private void Dispose(bool disposing)
        {
            if (disposedValue)
            {
                return;
            }

            if (disposing)
            {
                handler.Dispose();
                httpClient.Dispose();
            }

            disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
