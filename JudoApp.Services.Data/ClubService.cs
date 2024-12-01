namespace JudoApp.Services.Data
{
    using JudoApp.Data.Models;
    using JudoApp.Data.Repository.Interfaces;
    using JudoApp.Services.Data.Interfaces;
    using JudoApp.Services.Mapping;
    using JudoApp.Web.ViewModels.Club;
    using Microsoft.EntityFrameworkCore;

    public class ClubService : BaseService, IClubService
    {
        private readonly IRepository<Club, Guid> clubRepository;

        public ClubService(IRepository<Club, Guid> clubRepository)
        {
            this.clubRepository = clubRepository;
        }

        public async Task<IEnumerable<ClubIndexViewModel>> IndexGetAllOrderedByNameAsync()
        {
            IEnumerable<ClubIndexViewModel> clubs = await this.clubRepository
                .GetAllAttached()
                .Where(c => c.IsDeleted == false)
                .OrderBy(c => c.Name)
                .To<ClubIndexViewModel>()
                .ToArrayAsync();

            return clubs;
        }

        public async Task AddClubAsync(AddClubFormModel model)
        {
            Club club = new Club();
            AutoMapperConfig.MapperInstance.Map(model, club);

            await this.clubRepository.AddAsync(club);
        }

        public async Task<ClubDetailsViewModel?> GetClubDetailsByIdAsync(Guid id)
        {
            Club? club = await this.clubRepository
              .GetAllAttached()
              .Where(c => c.IsDeleted == false)
              .FirstOrDefaultAsync(c => c.Id == id);

            ClubDetailsViewModel? viewModel = null;
            if (club != null)
            {
                viewModel = new ClubDetailsViewModel()
                {
                    Id = club.Id.ToString(),
                    Name = club.Name,
                    Address = club.Address,
                    City = club.City,
                    PhoneNumber = club.PhoneNumber,
                    Email = club.Email,
                };
            }

            return viewModel;
        }

        public async Task<EditClubFormModel?> GetClubForEditByIdAsync(Guid id)
        {
            EditClubFormModel? clubModel = await this.clubRepository
                .GetAllAttached()
                .Where(c => c.IsDeleted == false)
                .To<EditClubFormModel>()
                .FirstOrDefaultAsync(c => c.Id.ToLower() == id.ToString().ToLower());

            return clubModel;
        }

        public async Task<bool> EditClubAsync(EditClubFormModel model)
        {
            Club clubEntity = AutoMapperConfig.MapperInstance
                .Map<EditClubFormModel, Club>(model);

            bool result = await this.clubRepository.UpdateAsync(clubEntity);

            return result;
        }

        public async Task<DeleteClubViewModel?> GetClubForDeleteByIdAsync(Guid id)
        {
            DeleteClubViewModel? clubToDelete = await this.clubRepository
                .GetAllAttached()
                .Where(c => c.IsDeleted == false)
                .To<DeleteClubViewModel>()
                .FirstOrDefaultAsync(c => c.Id.ToLower() == id.ToString().ToLower());

            return clubToDelete;
        }

        public async Task<bool> SoftDeleteClubAsync(Guid id)
        {
            Club? clubToDelete = await this.clubRepository
                .FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToString().ToLower());
            if (clubToDelete == null)
            {
                return false;
            }

            clubToDelete.IsDeleted = true;
            return await this.clubRepository.UpdateAsync(clubToDelete);
        }
    }
}
