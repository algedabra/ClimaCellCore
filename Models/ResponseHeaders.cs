using System;
using System.Net.Http.Headers;

namespace ClimaCellCore.Models
{
    public class ResponseHeaders
    {
        public long? RateLimitLimitDay { get; set; }
        public long? RateLimitLimitHour { get; set; }
        public long? RateLimitRemainingDay { get; set; }
        public long? RateLimitRemainingHour { get; set; }
        public string ResponseTime { get; set; }
        public CacheControlHeaderValue CacheControl { get; set; }
    }
}
