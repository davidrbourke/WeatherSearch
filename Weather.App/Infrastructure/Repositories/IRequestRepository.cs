using System.Threading.Tasks;

namespace Weather.App.Infrastructure.Repositories
{
    public interface IRequestRepository<ResponseType>
    {
        Task<ResponseType> GetAsync(string parameters);
    }
}
