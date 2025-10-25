namespace JudoApp.Web.ViewModels.Product
{
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    using static JudoApp.Common.EntityValidationConstants.Product;
    public class AddProductFormModel : IMapTo<Product>
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MinLength(PriceMinLength)]
        [MaxLength(PriceMaxLength)]
        public string Price { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;
    }
}
