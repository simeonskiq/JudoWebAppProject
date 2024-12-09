namespace JudoApp.Data.Models
{
    public class Club
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string City { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsDeleted { get; set; }
    }
}