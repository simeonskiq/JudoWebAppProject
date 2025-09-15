namespace JudoApp.Web.ViewModels.Order
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;

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

        // --- Delivery / Address fields (moved to base so StartOrder.cshtml can bind to them) ---

        [Required]
        [Display(Name = "Country")]
        [StringLength(100)]
        public string Country { get; set; } = null!;

        [Required]
        [Display(Name = "City")]
        [StringLength(100)]
        public string City { get; set; } = null!;

        [Required]
        [Display(Name = "Postal Code")]
        [StringLength(20)]
        public string PostalCode { get; set; } = null!;

        [Required]
        [Display(Name = "Shipping Method")]
        [StringLength(50)]
        public string ShippingMethod { get; set; } = null!;

        // Keep Address since Order has it
        [Display(Name = "Address")]
        [StringLength(250)]
        public string? Address { get; set; }

        // --- Payment / summary fields ---

        [Required]
        [Display(Name = "Payment Method")]
        [StringLength(50)]
        public string PaymentMethod { get; set; } = null!;

        [Display(Name = "Total Amount")]
        [StringLength(50)]
        public string? TotalAmount { get; set; }

        [Display(Name = "Order Notes")]
        [StringLength(500)]
        public string? OrderNotes { get; set; }

        // Optional: if you will map items with the order later
        public ICollection<CartItem>? OrderItems { get; set; }
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
        // Country, City, PostalCode moved to base class to avoid duplicate declarations.
        // Keep DeliveryMethod as it was (preserves existing code that references DeliveryMethod).
        [Required]
        public string DeliveryMethod { get; set; } = null!;
    }

    public class PaymentViewModel : AddOrderFormModel
    {
        // PaymentMethod moved to base class (so StartOrder.cshtml can bind against the base model).
        // No additional members here to avoid duplicate member errors.
    }
}
