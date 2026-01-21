namespace SandboxApp.Models
{
    // A photo model to store photographs
    public class Photo
    {
        // unique id (primary key in Db)
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageFilename { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
