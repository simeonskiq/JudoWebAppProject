namespace JudoApp.Web.ViewModels.Club
{
    using JudoApp.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

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
    }
}
