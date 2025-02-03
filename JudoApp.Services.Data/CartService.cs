namespace JudoApp.Services.Data
{

    using JudoApp.Data.Models;
    using JudoApp.Services.Data.Interfaces;
    using JudoApp.Web.Data;
    using Microsoft.EntityFrameworkCore;

    public class CartService : ICartService
    {
        private readonly JudoDbContext context;

        public CartService(JudoDbContext context)
        {
            this.context = context;
        }

        public List<CartItem> GetCartItems()
        {
            return context.CartItems
                .Include(c => c.Product)
                .ToList();
        }

        public void AddToCart(Guid productId)
        {
            var product = context.Products.Find(productId);
            if (product == null) return;

            var existingItem = context.CartItems
                .FirstOrDefault(i => i.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                context.CartItems.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = decimal.Parse(product.Price),
                    Quantity = 1
                });
            }

            context.SaveChanges();
        }

        public void RemoveFromCart(Guid productId)
        {
            var item = context.CartItems
                .FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                context.CartItems.Remove(item);
                context.SaveChanges();
            }
        }

        public void UpdateQuantity(Guid productId, int quantity)
        {
            var item = context.CartItems
                .FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                item.Quantity = quantity;
                if (item.Quantity <= 0)
                {
                    context.CartItems.Remove(item);
                }
                context.SaveChanges();
            }
        }

        public decimal GetTotal()
        {
            return context.CartItems.Sum(item => item.Price * item.Quantity);
        }

        public void ClearCart()
        {
            var items = context.CartItems.ToList();
            context.CartItems.RemoveRange(items);
            context.SaveChanges();
        }
    }
}
