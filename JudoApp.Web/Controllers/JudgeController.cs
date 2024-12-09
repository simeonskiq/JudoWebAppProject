    namespace JudoApp.Web.Controllers
{
    using JudoApp.Services.Data.Interfaces;
    using JudoApp.Web.ViewModels.Judge;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

    public class JudgeController : BaseController
    {
        private readonly IJudgeService judgeService;

        public JudgeController(IJudgeService judgeService, IManagerService managerService)
            : base(managerService) 
        {
            this.judgeService = judgeService;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            IEnumerable<JudgeIndexViewModel> judges =
                await this.judgeService.IndexGetAllOrderedByNameAsync();

            return this.View(judges);
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> Create()
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AddJudgeFormModel model)
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

            await this.judgeService.AddJudgeAsync(model);

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

            IEnumerable<JudgeIndexViewModel> judges =
                await this.judgeService.IndexGetAllOrderedByNameAsync();

            return this.View(judges);
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

            Guid judgeGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref judgeGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            EditJudgeFormModel? formModel = await this.judgeService
                .GetJudgeForEditByIdAsync(judgeGuid);
            if (formModel == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            return this.View(formModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditJudgeFormModel formModel)
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

            bool isUpdated = await this.judgeService
                .EditJudgeAsync(formModel);
            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating the judge! Please contact administrator");
                return this.View(formModel);
            }

            return this.RedirectToAction(nameof(Index), "Judge", new { id = formModel.Id });
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

            Guid judgeGuid = Guid.Empty;
            if (!this.IsGuidValid(id, ref judgeGuid))
            {
                return this.RedirectToAction(nameof(Manage));
            }

            DeleteJudgeViewModel? judgeToDeleteViewModel =
                await this.judgeService.GetJudgeForDeleteByIdAsync(judgeGuid);
            if (judgeToDeleteViewModel == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            return this.View(judgeToDeleteViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SoftDeleteConfirmed(DeleteJudgeViewModel judge)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Guid judgeGuid = Guid.Empty;
            if (!this.IsGuidValid(judge.Id, ref judgeGuid))
            {
                return this.RedirectToAction(nameof(Manage));
            }

            bool isDeleted = await this.judgeService
                .SoftDeleteJudgeAsync(judgeGuid);
            if (!isDeleted)
            {
                TempData["ErrorMessage"] =
                    "Unexpected error occurred while trying to delete the judge! Please contact system administrator!";
                return this.RedirectToAction(nameof(Delete), new { id = judge.Id });
            }

            return this.RedirectToAction(nameof(Manage));
        }
    }
}
