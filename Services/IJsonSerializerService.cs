using System.Threading.Tasks;

namespace ClimaCellCore.Services
{
    public interface IJsonSerializerService
    {
        Task<T> DeserializeJsonAsync<T>(Task<string> json);
    }
}
