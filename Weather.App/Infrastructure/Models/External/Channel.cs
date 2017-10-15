namespace Weather.App.Infrastructure.Models.External
{
    public class Channel
    {
        public Units Units { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string LastBuildDate { get; set; }
        public string Ttl { get; set; }
        public Location Location { get; set; }
        public Wind Wind { get; set; }
        public Atmosphere Atmosphere { get; set; }
        public Astronomy Astronomy { get; set; }
        public Image Image { get; set; }
        public Item Item { get; set; }
    }
}
