using System;
using Weather.App.Infrastructure.Models.External;

namespace Weather.App.Infrastructure.Models.ExtUtil
{
    public class Query
    {
        public int Count { get; set; }
        public DateTime Created { get; set; }
        public string Lang { get; set; }
        public Diagnostics Diagnostics { get; set; }
        public Results Results { get; set; }
    }
}
