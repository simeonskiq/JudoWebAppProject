namespace JudoApp.Data.Seeding.DataTransferObjects
{
    using AutoMapper;
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    using static JudoApp.Common.EntityValidationConstants.Club;

    public class ImportClubDto : IMapTo<Club>, IHaveCustomMappings
    {
        [Required]
        [MinLength(IdMinLength)]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = null;

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
        public string PhoneNumber { get; set; }

        [MinLength(EmailMinLength)]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        [MinLength(ImageUrlMinLength)]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ImportClubDto, Club>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => Guid.Parse(s.Id)));
        }
    }
}
