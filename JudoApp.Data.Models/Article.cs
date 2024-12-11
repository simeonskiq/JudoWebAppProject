namespace JudoApp.Data.Models
{
    public class Article
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Tittle { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public DateTime DateUploaded { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; }
    }
}
