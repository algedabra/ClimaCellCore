using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClimaCellCore.Services
{
    public class JsonNetJsonSerializerService : IJsonSerializerService
    {
        JsonSerializerSettings _jsonSettings = new JsonSerializerSettings();

        public async Task<T> DeserializeJsonAsync<T>(Task<string> json)
        {
            try
            {
                return (json != null)
                    ? JsonConvert.DeserializeObject<T>(await json.ConfigureAwait(false), _jsonSettings)
                    : default;
            }
            catch (JsonReaderException e)
            {
                throw new FormatException("Json Parsing Error", e);
            }
        }
    }
}
