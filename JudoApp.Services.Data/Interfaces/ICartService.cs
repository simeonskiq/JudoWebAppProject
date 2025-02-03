namespace JudoApp.Services.Data.Interfaces
{
    using JudoApp.Data.Models;

    public interface ICartService
    {
        List<CartItem> GetCartItems();
        void AddToCart(Guid productId);
        void RemoveFromCart(Guid productId);
        void UpdateQuantity(Guid productId, int quantity);
        decimal GetTotal();
        void ClearCart();
    }
}
