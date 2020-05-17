using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClimaCellCore.Services
{
    public interface IHttpClient : IDisposable
    {
        Task<HttpResponseMessage> HttpRequestAsync(string requestString);
    }
}

