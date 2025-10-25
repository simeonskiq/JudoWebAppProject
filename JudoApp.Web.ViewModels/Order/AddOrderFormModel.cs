namespace JudoApp.Web.ViewModels.Order
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;

    using static JudoApp.Common.EntityValidationConstants.Order;

    public class AddOrderFormModel : IMapTo<Order>
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        [MinLength(EmailMinLength)]
        [MaxLength(EmailMaxLength)]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = null!;

        [Required]
        [Phone]
        [MinLength(PhoneMinLength)]
        [MaxLength(PhoneMaxLength)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Display(Name = "Country")]
        [MaxLength(CountryMaxLength)]
        [MinLength(CountryMinLength)]
        public string Country { get; set; } = null!;

        [Required]
        [Display(Name = "City")]
        [MaxLength(CityMaxLength)]
        [MinLength(CityMinLength)]
        public string City { get; set; } = null!;

        [Required]
        [Display(Name = "Postal Code")]
        [MaxLength(PostalCodeMaxLength)]
        [MinLength(PostalCodeMinLength)]
        public string PostalCode { get; set; } = null!;

        [Required]
        [Display(Name = "Shipping Method")]
        public string ShippingMethod { get; set; } = null!;

        [Display(Name = "Address")]
        [MaxLength(AddressMaxLength)]
        [MinLength(AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; } = null!;

        [Display(Name = "Total Amount")]
        [StringLength(50)]
        public string TotalAmount { get; set; } = null!;

        [Display(Name = "Order Notes")]
        [MaxLength(OrderNotesMaxLength)]
        public string? OrderNotes { get; set; }

        public ICollection<CartItem>? OrderItems { get; set; }

        [Required]
        public string DeliveryMethod { get; set; } = null!;

    }
}