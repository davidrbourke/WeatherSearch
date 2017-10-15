using System.Threading.Tasks;
using Weather.App.Infrastructure.Repositories;

namespace Weather.App.Application
{
    public class WeatherService
    {
        private Domain.Aggregates.Weather _weather;

        public async Task<Domain.Aggregates.Weather> GetWeatherAsync()
        {
            string location = "Coventry";
            IRequestRepository<Domain.Aggregates.Weather> repository = new YqlRepository();
            _weather = await repository.GetAsync(location);

            return _weather;
        }
    }
}
