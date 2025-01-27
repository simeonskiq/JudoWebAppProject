namespace JudoApp.Web.Controllers
{
    using JudoApp.Services.Data.Interfaces;
    using JudoApp.Web.ViewModels.Article;
    using JudoApp.Web.ViewModels.Product;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static JudoApp.Common.ApplicationConstants;

    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService, IManagerService managerService)
            : base(managerService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductIndexViewModel> products =
                await this.productService.IndexGetAllOrderedByNameAsync();
            return this.View(products);
        }

        [HttpGet]
        [Authorize]
#pragma warning disable CS1998
        public async Task<IActionResult> Create()
#pragma warning restore CS1998
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                TempData[ErrorMessage] = "You must be a manager to create Products!";
                return this.RedirectToAction(nameof(Index));
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AddProductFormModel model)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.productService.AddProductAsync(model);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid productGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref productGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            ProductDetailsViewModel? viewModel = await this.productService
                .GetProductDetailsByIdAsync(productGuid);

            // Invalid(non-existing) GUID in the URL
            if (viewModel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            await this.AppendUserCookieAsync();

            return this.View(viewModel);
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

            IEnumerable<ProductIndexViewModel> products =
                await this.productService.IndexGetAllOrderedByNameAsync();

            return this.View(products);
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

            Guid productGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref productGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            EditProductFormModel? formModel = await this.productService
                .GetProductForEditByIdAsync(productGuid);
            if (formModel == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            return this.View(formModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditProductFormModel formModel)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool isUpdated = await this.productService
                .EditProductAsync(formModel);
            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating the product! Please contact administrator");
                return this.View(formModel);
            }

            return this.RedirectToAction(nameof(Details), "Product", new { id = formModel.Id });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(string? id)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Guid productGuid = Guid.Empty;
            if (!this.IsGuidValid(id, ref productGuid))
            {
                return this.RedirectToAction(nameof(Manage));
            }

            DeleteProductViewModel? productToDeleteViewModel =
                await this.productService.GetProductForDeleteByIdAsync(productGuid);
            if (productToDeleteViewModel == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            return this.View(productToDeleteViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SoftDeleteConfirmed(DeleteProductViewModel product)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Guid productGuid = Guid.Empty;
            if (!this.IsGuidValid(product.Id, ref productGuid))
            {
                return this.RedirectToAction(nameof(Manage));
            }

            bool isDeleted = await this.productService
                .SoftDeleteProductAsync(productGuid);
            if (!isDeleted)
            {
                TempData["ErrorMessage"] =
                    "Unexpected error occurred while trying to delete the product! Please contact system administrator!";
                return this.RedirectToAction(nameof(Delete), new { id = product.Id });
            }

            return this.RedirectToAction(nameof(Manage));
        }
    }
}