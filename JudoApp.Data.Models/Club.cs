namespace JudoApp.Data.Models
{
    public class Club
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string City { get; set; } = null!;

        public int PhoneNumber { get; set; }

        public string Email { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}