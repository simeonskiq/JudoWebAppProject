namespace JudoApp.Web.ViewModels.Club
{
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Services.Mapping;

    using static Common.EntityValidationConstants.Club;

    public class AddClubFormModel : IMapTo<Club>
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(AddressMinLength)]
        [MaxLength(AddressMaxLength)]

        public string Address { get; set; } = null!;

        [Required]
        [MinLength(CityMinLength)]
        [MaxLength(CityMaxLength)]

        public string City { get; set; } = null!;

        [MinLength(PhoneMinLength)]
        [MaxLength(PhoneMaxLength)]

        public string? PhoneNumber { get; set; }

        [MinLength(EmailMinLength)]
        [MaxLength(EmailMaxLength)]
        public string? Email { get; set; }

        [MaxLength(ImageUrlMaxLength)]

        public string? ImageUrl { get; set; }
    }
}
