namespace JudoApp.Web.ViewModels.Product
{
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;

    public class DeleteProductViewModel : IMapFrom<Product>
    {
        public string Id { get; set; } = null!;

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Price { get; set; }

        public string? ImageUrl { get; set; }
    }
}
