namespace CA3_WebApp.Models
{
    public class Show
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
    }

    public class ShowImage
    {
        public string? Medium { get; set; }
        public string? Original { get; set; }
    }
}
