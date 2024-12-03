namespace JudoApp.Services.Data.Interfaces
{
    using JudoApp.Data.Models;
    using JudoApp.Web.ViewModels.Admin.UserManagement;

    public interface IManagerRequestService
    {
        Task<IEnumerable<ManagerRequestViewModel>> GetPendingRequestsAsync(); 
        Task SubmitRequestAsync(AddManagerRequestViewModel model);           
        Task ApproveRequestAsync(Guid id);                                   
        Task<DeleteManagerRequestViewModel?> RejectRequestAsync(Guid id);
    }
}
