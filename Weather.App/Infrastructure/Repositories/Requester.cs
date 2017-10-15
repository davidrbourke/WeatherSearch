using System.Net.Http;
using System.Threading.Tasks;

namespace Weather.App.Infrastructure.Repositories
{
    public class Requester : IRequester
    {
        public async Task<HttpResponseMessage> ProcessRequestAsync(string request)
        {
            var client = new HttpClient();
            var response = client.GetAsync(request);

            return await response;
        }
    }
}
