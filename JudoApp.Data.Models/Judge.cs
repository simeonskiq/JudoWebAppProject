namespace JudoApp.Data.Models
{
    public class Judge
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsDeleted { get; set; }
    }
}
