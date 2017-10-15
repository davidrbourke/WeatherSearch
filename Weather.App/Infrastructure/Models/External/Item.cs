using System.Collections.Generic;

namespace Weather.App.Infrastructure.Models.External
{
    public class Item
    {
        public string Title { get; set; }
        public string Lat { get; set; }
        public string @long { get; set; }
        public string Link { get; set; }
        public string PubDate { get; set; }
        public Condition Condition { get; set; }
        public List<Forecast> Forecast { get; set; }
        public string Description { get; set; }
        public Guid Guid { get; set; }
    }
}
