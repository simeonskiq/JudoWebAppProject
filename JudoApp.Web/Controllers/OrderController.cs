namespace JudoApp.Web.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using JudoApp.Web.ViewModels.Order;
    using Microsoft.AspNetCore.Identity;
    using JudoApp.Data.Models;
    using JudoApp.Services.Data.Interfaces;
    using JudoApp.Web.ViewModels.Club;
    using Microsoft.AspNetCore.Authorization;
    using JudoApp.Web.ViewModels.Judge;

    public class OrderController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IOrderService orderService;

        public OrderController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IManagerService managerService,IOrderService orderService)
            : base(managerService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.orderService = orderService;
        }

        public IActionResult StartOrder()
        {
            var model = new AddOrderFormModel
            {
                CurrentStep = 1,
                IsAuthenticated = User.Identity?.IsAuthenticated ?? false
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GuestRegistration([FromBody] GuestRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return Json(new { success = true });
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        public IActionResult DeliveryAddress([FromBody] DeliveryAddressViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Save delivery address to session or database
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Payment([FromBody] PaymentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Process payment and create order
            return Json(new { success = true, message = "Your order has been sent successfully" });
        }

        [HttpPost]
        public IActionResult SavePersonalInfo([FromBody] PersonalInfoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HttpContext.Session.SetString("FirstName", model.FirstName);
            HttpContext.Session.SetString("LastName", model.LastName);
            HttpContext.Session.SetString("PhoneNumber", model.PhoneNumber);

            return Json(new { success = true });
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