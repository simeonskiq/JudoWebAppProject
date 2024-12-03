namespace JudoApp.Web.Areas.Admin.Controllers
{

    using JudoApp.Services.Data.Interfaces;
    using JudoApp.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Common.ApplicationConstants;

    [Area(AdminRoleName)]
    [Authorize(Roles = AdminRoleName)]
    public class HomeController : BaseController
    {
        private readonly IManagerRequestService managerRequestService;

        public HomeController(IManagerRequestService managerRequestService, IManagerService managerService)
            : base(managerService)
        {
            this.managerRequestService = managerRequestService;
        }

        public async Task<IActionResult> Index()
        {
            var pendingRequests = await this.managerRequestService.GetPendingRequestsAsync();
            return View("PendingRequests", pendingRequests);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveRequest(Guid id)
        {
            await this.managerRequestService.ApproveRequestAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RejectRequest(Guid id)
        {
            await this.managerRequestService.RejectRequestAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}