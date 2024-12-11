namespace JudoApp.Web.Controllers
{

    using JudoApp.Services.Data.Interfaces;
    using JudoApp.Web.ViewModels.Club;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ClubController : BaseController
    {
        private readonly IClubService clubService;
        
        public ClubController(IClubService clubService, IManagerService managerService)
            : base(managerService)
        {
            this.clubService = clubService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(AllClubsSearchFilterViewModel inputModel)
        {
            IEnumerable<ClubIndexViewModel> allClubs =
                await this.clubService.GetAllClubsAsync(inputModel);
            int allClubsCount = await this.clubService.GetClubsCountByFilterAsync(inputModel);
            AllClubsSearchFilterViewModel viewModel = new AllClubsSearchFilterViewModel
            {
                Clubs = allClubs,
                SearchQuery = inputModel.SearchQuery,
                CityFilter = inputModel.CityFilter,
                CurrentPage = inputModel.CurrentPage,
                TotalPages = (int)Math.Ceiling((double)allClubsCount /
                                               inputModel.EntitiesPerPage!.Value)
            };

            return this.View(viewModel);
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
                return this.RedirectToAction(nameof(Index));
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AddClubFormModel model)
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

            await this.clubService.AddClubAsync(model);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid clubGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref clubGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            ClubDetailsViewModel? viewModel = await this.clubService
                .GetClubDetailsByIdAsync(clubGuid);

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

            IEnumerable<ClubIndexViewModel> clubs =
                await this.clubService.GetAllClubsAsync(new AllClubsSearchFilterViewModel());

            return this.View(clubs);
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

            Guid clubGuid = Guid.Empty;
            bool isIdValid = this.IsGuidValid(id, ref clubGuid);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            EditClubFormModel? formModel = await this.clubService
                .GetClubForEditByIdAsync(clubGuid);
            if (formModel == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            return this.View(formModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditClubFormModel formModel)
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

            bool isUpdated = await this.clubService
                .EditClubAsync(formModel);
            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating the club! Please contact administrator");
                return this.View(formModel);
            }

            return this.RedirectToAction(nameof(Details), "Club", new { id = formModel.Id });
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

            Guid clubGuid = Guid.Empty;
            if (!this.IsGuidValid(id, ref clubGuid))
            {
                return this.RedirectToAction(nameof(Manage));
            }

            DeleteClubViewModel? clubToDeleteViewModel =
                await this.clubService.GetClubForDeleteByIdAsync(clubGuid);
            if (clubToDeleteViewModel == null)
            {
                return this.RedirectToAction(nameof(Manage));
            }

            return this.View(clubToDeleteViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SoftDeleteConfirmed(DeleteClubViewModel club)
        {
            bool isManager = await this.IsUserManagerAsync();
            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Guid clubGuid = Guid.Empty;
            if (!this.IsGuidValid(club.Id, ref clubGuid))
            {
                return this.RedirectToAction(nameof(Manage));
            }

            bool isDeleted = await this.clubService
                .SoftDeleteClubAsync(clubGuid);
            if (!isDeleted)
            {
                TempData["ErrorMessage"] =
                    "Unexpected error occurred while trying to delete the club! Please contact system administrator!";
                return this.RedirectToAction(nameof(Delete), new { id = club.Id });
            }

            return this.RedirectToAction(nameof(Manage));
        }
    }
}