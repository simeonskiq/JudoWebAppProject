using JudoApp.Data.Models;
using JudoApp.Services.Mapping;

namespace JudoApp.Web.ViewModels.Cart
{
    public class AddToCartFormModel : IMapTo<CartItem>
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }= null!;

        public decimal Price { get; set; }

        public decimal Total{ get; set; }

        public string ImageUrl { get; set; }= null!;

    }
}
