namespace JudoApp.Web.Controllers
{

    using JudoApp.Services.Data.Interfaces;
    using JudoApp.Web.ViewModels.Order;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;

        public OrderController(IOrderService orderService, IManagerService managerService, ICartService cartService)
            : base(managerService)
        {
            this.orderService = orderService;
            this.cartService = cartService;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            IEnumerable<OrderIndexViewModel> orders;

            bool isManager = await this.IsUserManagerAsync(); 

            if (isManager)
            {
                // Managers see all orders
                orders = await this.orderService.IndexGetAllOrderedByNumberAsync();
            }
            else
            {
                // Normal users see only their own orders
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                orders = await this.orderService.GetOrdersByUserIdAsync(userId);
            }

            return this.View(orders);
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> Create()
        {
            var cartItems = this.cartService.GetCartItems();
            ViewData["CartItems"] = cartItems;
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AddOrderFormModel model)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var cartItems = this.cartService.GetCartItems();

            await this.orderService.AddOrderAsync(model, userId, cartItems);

            // clear the cart after placing the order
            this.cartService.ClearCart();

            TempData["SuccessMessage"] = "Your order was placed successfully!";
            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Manage()
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            IEnumerable<OrderIndexViewModel> orders =
                await this.orderService.IndexGetAllOrderedByNumberAsync();

            return this.View(orders);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string? id)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {

                ModelState.AddModelError(string.Empty, "You are not registered as a manager! Please contact administrator");

                return this.RedirectToAction(nameof(Index));
            }

            Guid orderGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref orderGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            EditOrderFormModel? formModel = await this.orderService
                .GetOrderForEditByIdAsync(orderGuid);
            if (formModel == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            return this.View(formModel);
        }
    }
}