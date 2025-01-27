namespace JudoApp.Web.ViewModels.Product
{
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;
    public class ProductIndexViewModel : IMapFrom<Product>
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Price { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
