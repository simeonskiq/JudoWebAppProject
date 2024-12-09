namespace JudoApp.Web.ViewModels.Club
{
    using Services.Mapping;
    using Data.Models;

    public class DeleteClubViewModel : IMapFrom<Club>
    {
        public string Id { get; set; } = null!;

        public string? Name { get; set; }

        public string? Address { get; set; } 

        public string? City { get; set; } 

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; } 

        public string? ImageUrl { get; set; }
    }
}
