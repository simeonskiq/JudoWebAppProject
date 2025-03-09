namespace JudoApp.Web.ViewModels.Order
{
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    using static JudoApp.Common.EntityValidationConstants.Order;
    public class AddOrderFormModel : IMapTo<Order>
    {

        public int CurrentStep { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? ReturnUrl { get; set; }

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
        [Phone]
        [MinLength(PhoneMinLenght)]
        [MaxLength(PhoneMaxLenght)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;
    }

    public class GuestRegistrationViewModel : AddOrderFormModel
    {
        [Required]
        [EmailAddress]
        [MinLength(EmailMinLenght)]
        [MaxLength(EmailMaxLenght)]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(PasswordMinLenght)]
        [MaxLength(PasswordMaxLenght)]
        public string Password { get; set; } = null!;

        [Required]
        public DateTime DateOfBirth { get; set; }
    }

    public class DeliveryAddressViewModel : AddOrderFormModel
    {
        [Required]
        public string Country { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string PostalCode { get; set; } = null!;

        [Required]
        public string DeliveryMethod { get; set; } = null!;
    }

    public class PaymentViewModel : AddOrderFormModel
    {
        [Required]
        public string PaymentMethod { get; set; } = null!;
    }
}
