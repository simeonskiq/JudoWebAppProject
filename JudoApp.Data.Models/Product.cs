namespace JudoApp.Data.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Price { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
