using System.Net.Http;
using System.Threading.Tasks;

namespace Weather.App.Infrastructure.Repositories
{
    public interface IRequester
    {
        Task<HttpResponseMessage> ProcessRequestAsync(string requestSource);
    }
}
