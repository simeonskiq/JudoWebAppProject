namespace JudoApp.Web.ViewModels.Admin.UserManagement
{

    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;

    public class DeleteManagerRequestViewModel : IMapFrom<ManagerRequest>
    {
        public string Id { get; set; } = null!;

        public string Reason { get; set; } = null!;
    }
}
