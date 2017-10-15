using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Weather.App.Infrastructure.Models.External;

namespace Weather.App.Infrastructure.Repositories
{
    public class YqlRepository : IRequestRepository<Domain.Aggregates.Weather>
    {
        public async Task<Domain.Aggregates.Weather> GetAsync(string parameters)
        {
            IRequester requester = new Requester();

            string select = WebUtility.UrlEncode($"select* from weather.forecast where woeid in (select woeid from geo.places(1) where text=\"{parameters}\")");
            string url = $"https://query.yahooapis.com/v1/public/yql?q={select}&format=json&diagnostics=true&callback=";
            string requestString = $"{url}";

            var result = await requester.ProcessRequestAsync(requestString);

            Task<string> content = result.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<RootObject>(content.Result);

            var weather = new Domain.Aggregates.Weather()
            {
                Astronomy = Mapper.Map<Domain.Astronomy>(root.Query.Results.Channel.Astronomy),
                Atmosphere = Mapper.Map<Domain.Atmosphere>(root.Query.Results.Channel.Atmosphere),
                Condition = Mapper.Map<Domain.Condition>(root.Query.Results.Channel.Item.Condition),
                Image = Mapper.Map<Domain.Image>(root.Query.Results.Channel.Image),
                Units = Mapper.Map<Domain.Units>(root.Query.Results.Channel.Units),
                Wind = Mapper.Map<Domain.Wind>(root.Query.Results.Channel.Wind),
                Title = root.Query.Results.Channel.Title,
                Description = root.Query.Results.Channel.Description,
                Lat = root.Query.Results.Channel.Item.Lat,
                Long = root.Query.Results.Channel.Item.@long,
            };

            return weather;
        }
    }
}
