namespace JudoApp.Web.ViewModels.Order
{
    using AutoMapper;
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    using static JudoApp.Common.EntityValidationConstants.Order;

    public class EditOrderFormModel : IHaveCustomMappings
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [Phone]
        [MinLength(PhoneMinLenght)]
        [MaxLength(PhoneMaxLenght)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MinLength(EmailMinLenght)]
        [MaxLength(EmailMaxLenght)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(CountryMaxLength)]
        public string Country { get; set; } = null!;

        [Required]
        [MaxLength(CityMaxLength)]
        public string City { get; set; } = null!;

        [Required]
        [MaxLength(PostalCodeMaxLength)]
        public string PostalCode { get; set; } = null!;

        [Required]

        public string DeliveryMethod { get; set; } = null!;

        [Required]
        public string PaymentMethod { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Order, EditOrderFormModel>();

            configuration
                .CreateMap<EditOrderFormModel, Order>()
                .ForMember(d => d.Id, x => x.MapFrom(s => Guid.Parse(s.Id)));
        }
    }
}
