namespace JudoApp.Services.Data
{

    using JudoApp.Data.Models;

    using JudoApp.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Identity;


    public class ManagerService : BaseService, IManagerService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;


        public ManagerService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<bool> IsUserManagerAsync(string? userId)
        {
            // Not a valid use-case, but we write defensive programming
            if (String.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            var roles = await userManager.GetRolesAsync(user);
            return roles.Contains("Admin");

        }
    }
}