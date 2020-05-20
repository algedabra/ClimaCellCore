using ClimaCellCore.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.FormattableString;

namespace ClimaCellCore.Services
{
    public class ClimaCellService : IDisposable
    {
        private readonly string apiKey;
        private readonly Uri baseUri;
        private readonly IHttpClient httpClient;
        private readonly IJsonSerializerService jsonSerializerService;

        public ClimaCellService(string apiKey, Uri baseUri = null, IHttpClient httpClient = null, IJsonSerializerService jsonSerializerService = null)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException($"{nameof(apiKey)} cannot be empty.");
            }

            this.apiKey = apiKey;
            this.baseUri = baseUri ?? new Uri("https://api.climacell.co/v3/weather/");
            this.httpClient = httpClient ?? new ZipHttpClient();
            this.jsonSerializerService = jsonSerializerService
                ?? new JsonNetJsonSerializerService();
        }

        ~ClimaCellService()
        {
            Dispose(false);
        }
        public async Task<ClimaCellResponse> GetForecast(double latitude, double longitude)
        {
            var requestString = BuildRequestUri(latitude, longitude);
            var response = await httpClient.HttpRequestAsync($"{baseUri}{requestString}").ConfigureAwait(false);
            var responseContent = response.Content?.ReadAsStringAsync();

            var climaCellResponse = new ClimaCellResponse
            {
                IsSuccessStatus = response.IsSuccessStatusCode,
                ResponseReasonPhrase = response.ReasonPhrase
            };

            if (!climaCellResponse.IsSuccessStatus)
            {
                return climaCellResponse;
            }

            try
            {
                climaCellResponse.Response =
                    await jsonSerializerService.DeserializeJsonAsync<RealTime>(responseContent).ConfigureAwait(false);
            }
            catch (FormatException e)
            {
                climaCellResponse.Response = null;
                climaCellResponse.IsSuccessStatus = false;
                climaCellResponse.ResponseReasonPhrase = $"Error parsing results: {e?.InnerException?.Message ?? e.Message}";
            }

            response.Headers.TryGetValues("X-RateLimit-Limit-day", out var rateLimitLimitDay);
            response.Headers.TryGetValues("X-RateLimit-Limit-hour", out var rateLimitLimitHour);
            response.Headers.TryGetValues("X-RateLimit-Remaining-day", out var rateLimitRemainingDay);
            response.Headers.TryGetValues("X-RateLimit-Remaining-hour", out var rateLimitRemainingHour);
            response.Headers.TryGetValues("Date", out var responseTimeHeader);

            climaCellResponse.Headers = new ResponseHeaders
            {
                CacheControl = response.Headers.CacheControl,
                RateLimitLimitDay = long.TryParse(rateLimitLimitDay?.FirstOrDefault(), out var rateLimitLimitDayParsed)
                    ? (long?)rateLimitLimitDayParsed
                    : null,
                RateLimitLimitHour = long.TryParse(rateLimitLimitHour?.FirstOrDefault(), out var rateLimitLimitHourParsed)
                    ? (long?)rateLimitLimitHourParsed
                    : null,
                RateLimitRemainingDay = long.TryParse(rateLimitRemainingDay?.FirstOrDefault(), out var rateLimitRemainingDayParsed)
                    ? (long?)rateLimitRemainingDayParsed
                    : null,
                RateLimitRemainingHour = long.TryParse(rateLimitRemainingHour?.FirstOrDefault(), out var rateLimitRemainingHourParsed)
                    ? (long?)rateLimitRemainingHourParsed
                    : null,
                ResponseTime = responseTimeHeader?.FirstOrDefault()
            };

            if (climaCellResponse.Response == null)
            {
                return climaCellResponse;
            }

            return climaCellResponse;
        }

        private string BuildRequestUri(double latitude, double longitude)
        {
            var queryString = new StringBuilder(Invariant($"realtime?lat={latitude:N4}&lon={longitude:N4}&apikey={apiKey}"));

            return queryString.ToString();
        }

        #region IDisposable Support

        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue)
            {
                return;
            }

            if (disposing)
            {
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
