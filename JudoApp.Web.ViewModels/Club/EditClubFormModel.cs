namespace JudoApp.Web.ViewModels.Club
{
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;

    using Services.Mapping;
    using Data.Models;

    using static Common.EntityValidationConstants.Club;
    public class EditClubFormModel : IHaveCustomMappings
    {
        [Required]
        public string Id { get; set; } = null!;

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

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Club, EditClubFormModel>();

            configuration
                .CreateMap<EditClubFormModel, Club>()
                .ForMember(d => d.Id, x => x.MapFrom(s => Guid.Parse(s.Id)));
        }
    }
}
