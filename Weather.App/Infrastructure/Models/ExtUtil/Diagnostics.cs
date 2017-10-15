using System.Collections.Generic;

namespace Weather.App.Infrastructure.Models.ExtUtil
{
    public class Diagnostics
    {
        public string publiclyCallable { get; set; }
        public List<Url> url { get; set; }
        public Javascript javascript { get; set; }
        public string __invalid_name__user_time { get; set; }
        public string __invalid_name__service_time { get; set; }
        public string __invalid_name__build_version { get; set; }
    }
}
