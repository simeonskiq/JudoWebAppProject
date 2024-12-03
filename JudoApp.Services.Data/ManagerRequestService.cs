namespace JudoApp.Services.Data
{
    using JudoApp.Data.Models;
    using JudoApp.Data.Repository.Interfaces;
    using JudoApp.Services.Data.Interfaces;
    using JudoApp.Services.Mapping;
    using JudoApp.Web.ViewModels.Admin.UserManagement;
    using Microsoft.EntityFrameworkCore;

    public class ManagerRequestService : BaseService, IManagerRequestService
    {
        private readonly IRepository<ManagerRequest, Guid> managerRequestRepository;

        public ManagerRequestService(IRepository<ManagerRequest, Guid> managerRequestRepository)
        {
            this.managerRequestRepository = managerRequestRepository;
        }

        public async Task<IEnumerable<ManagerRequestViewModel>> GetPendingRequestsAsync()
        {
            return await managerRequestRepository
                 .GetAllAttached()
                 .Where(r => !r.IsApproved)
                 .To<ManagerRequestViewModel>()
                 .ToListAsync();
        }

        public async Task SubmitRequestAsync(AddManagerRequestViewModel model)
        {
            ManagerRequest request = new ManagerRequest();
            AutoMapperConfig.MapperInstance.Map(model, request);

            await this.managerRequestRepository.AddAsync(request);
        }

        public async Task ApproveRequestAsync(Guid id)
        {
            var request = await this.managerRequestRepository.GetByIdAsync(id);

            if (request == null)
            {
                throw new KeyNotFoundException($"No manager request found with ID: {id}");
            }

            request.IsApproved = true;
            await this.managerRequestRepository.UpdateAsync(request);
        }

        public async Task<DeleteManagerRequestViewModel?> RejectRequestAsync(Guid id)
        {
            var request = await this.managerRequestRepository.GetByIdAsync(id);

            if (request == null)
                return null;

            request.IsDeleted = true; 
            await this.managerRequestRepository.UpdateAsync(request);

            return new DeleteManagerRequestViewModel
            {
                Id = request.Id.ToString(),
                Reason = request.Reason
            };
        }
    }
}
