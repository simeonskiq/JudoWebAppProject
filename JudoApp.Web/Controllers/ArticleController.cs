namespace JudoApp.Web.Controllers
{

    using JudoApp.Services.Data.Interfaces;
    using JudoApp.Web.ViewModels.Article;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static JudoApp.Common.ApplicationConstants;
    public class ArticleController : BaseController
    {
        private readonly IArticleService articleService;

        public ArticleController(IArticleService articleService, IManagerService managerService)
            : base(managerService)
        {
            this.articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ArticleIndexViewModel> articles =
                await this.articleService.IndexGetAllOrderedByNameAsync();

            return this.View(articles);
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
                TempData[ErrorMessage] = "You must be a manager to create Articles!";
                return this.RedirectToAction(nameof(Index));
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AddArticleFormModel model)
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

            await this.articleService.AddArticleAsync(model);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid articleGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref articleGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            ArticleDetailsViewModel? viewModel = await this.articleService
                .GetArticleDetailsByIdAsync(articleGuid);

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

            IEnumerable<ArticleIndexViewModel> articles =
                await this.articleService.IndexGetAllOrderedByNameAsync();

            return this.View(articles);
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

            Guid articleGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref articleGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            EditArticleFormModel? formModel = await this.articleService
                .GetArticleForEditByIdAsync(articleGuid);
            if (formModel == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            return this.View(formModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditArticleFormModel formModel)
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

            bool isUpdated = await this.articleService
                .EditArticleAsync(formModel);
            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating the club! Please contact administrator");
                return this.View(formModel);
            }

            return this.RedirectToAction(nameof(Details), "Articles", new { id = formModel.Id });
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

            Guid articleGuid = Guid.Empty;
            if (!this.IsGuidValid(id, ref articleGuid))
            {
                return this.RedirectToAction(nameof(Manage));
            }

            DeleteArticleViewModel? articleToDeleteViewModel =
                await this.articleService.GetArticleForDeleteByIdAsync(articleGuid);
            if (articleToDeleteViewModel == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            return this.View(articleToDeleteViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SoftDeleteConfirmed(DeleteArticleViewModel article)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Guid articleGuid = Guid.Empty;
            if (!this.IsGuidValid(article.Id, ref articleGuid))
            {
                return this.RedirectToAction(nameof(Manage));
            }

            bool isDeleted = await this.articleService
                .SoftDeleteArticleAsync(articleGuid);
            if (!isDeleted)
            {
                TempData["ErrorMessage"] =
                    "Unexpected error occurred while trying to delete the article! Please contact system administrator!";
                return this.RedirectToAction(nameof(Delete), new { id = article.Id });
            }

            return this.RedirectToAction(nameof(Manage));
        }
    }
}