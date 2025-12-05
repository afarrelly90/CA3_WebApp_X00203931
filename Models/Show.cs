namespace CA3_WebApp.Models
{
    public enum ShowStatus
    {
        All,
        Running,
        Ended,
        ToBeDetermined
    }

    public class Show
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Summary { get; set; }
        public ShowImage? Image { get; set; }
        public ShowRating? Rating { get; set; }
        public string? Status { get; set; }
        public string? Premiered { get; set; }
        public string? Ended { get; set; }
        public List<string>? Genres { get; set; }
        public int? Runtime { get; set; }
    }

    public class ShowImage
    {
        public string? Medium { get; set; }
        public string? Original { get; set; }
    }

    public class ShowRating
    {
        public double? Average { get; set; }
    }
}
