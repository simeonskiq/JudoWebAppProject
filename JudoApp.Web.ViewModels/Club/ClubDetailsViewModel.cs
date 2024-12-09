namespace JudoApp.Web.ViewModels.Club
{
    public class ClubDetailsViewModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string City { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? ImageUrl { get; set; }
    }
}
