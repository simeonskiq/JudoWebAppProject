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
        [MinLength(AddressMinLenght)]
        [MaxLength(AddressMaxLenght)]

        public string Address { get; set; } = null!;

        [Required]
        [MinLength(CityMinLenght)]
        [MaxLength(CityMaxLenght)]

        public string City { get; set; } = null!;

        [MinLength(PhoneMinLenght)]
        [MaxLength(PhoneMaxLenght)]

        public string? PhoneNumber { get; set; }

        [MinLength(EmailMinLenght)]
        [MaxLength(EmailMaxLenght)]
        public string? Email { get; set; }

        [MinLength(ImageUrlMinLength)]
        [MaxLength(ImageUrlMaxLength)]

        public string? ImageUrl { get; set; }
    }
}
