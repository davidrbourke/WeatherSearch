using Weather.App.Infrastructure.Models.ExtUtil;

namespace Weather.App.Infrastructure.Models.External
{
    public class RootObject
    {
        public Query Query { get; set; }

        public string GetFormattedLocation()
        {
            return $"{Query.Results.Channel.Location.City} {Query.Results.Channel.Location.Country} {Query.Results.Channel.Location.Region}";
        }

        public string GetFormattedWeather()
        {
            double fahrenheit;
            if (double.TryParse(Query.Results.Channel.Item.Condition.Temp, out fahrenheit))
            {
                return $"{fahrenheit.FahrenheitToCelcius()} {Query.Results.Channel.Item.Condition.Text}";
            }

            return string.Empty;
        }
    }
}
