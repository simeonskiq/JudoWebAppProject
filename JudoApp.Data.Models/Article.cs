namespace JudoApp.Data.Models
{
    public class Article
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Tittle { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public bool IsDeleted { get; set; }
    }
}
