namespace JudoApp.Web.Controllers
{

    using JudoApp.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult AddToCart(Guid productId)
        {
            cartService.AddToCart(productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(Guid productId)
        {
            cartService.RemoveFromCart(productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(Guid productId, int quantity)
        {
            cartService.UpdateQuantity(productId, quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            cartService.ClearCart();
            return RedirectToAction("Index");
        }
    }
}