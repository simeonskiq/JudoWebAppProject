namespace JudoApp.Web.Controllers
{
    using JudoApp.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class CartController : BaseController
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService, IManagerService managerService)
            : base(managerService)
        {
            this.cartService = cartService;
        }

        public IActionResult Index()
        {
            var cartItems = cartService.GetCartItems();
            return View(cartItems);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddToCart(Guid productId)
        {
            cartService.AddToCart(productId);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public IActionResult RemoveFromCart(Guid productId)
        {
            cartService.RemoveFromCart(productId);
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateQuantity(Guid productId, int quantity)
        {
            cartService.UpdateQuantity(productId, quantity);

            var cartItem = cartService.GetCartItems().FirstOrDefault(i => i.ProductId == productId);
            decimal itemTotal = cartItem != null ? cartItem.Price * cartItem.Quantity : 0;

            decimal cartTotal = cartService.GetTotal();

            return Json(new { success = true, itemTotal = itemTotal, cartTotal = cartTotal });
        }

        [Authorize]
        [HttpPost]
        public IActionResult ClearCart()
        {
            cartService.ClearCart();
            return RedirectToAction("Index");
        }
    }
}