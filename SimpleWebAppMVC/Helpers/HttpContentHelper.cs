using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebAppMVC.Helpers
{
    public static class HttpContentHelper
    {
        public static HttpContent GetJsonContent(object model) =>
            new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

        public static async Task<T> DeserializeToType<T>(this HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}