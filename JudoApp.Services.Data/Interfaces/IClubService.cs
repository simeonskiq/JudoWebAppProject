namespace JudoApp.Services.Data.Interfaces
{
    using Web.ViewModels.Club;
    public interface IClubService
    {
        Task<IEnumerable<ClubIndexViewModel>> IndexGetAllOrderedByNameAsync();

        Task AddClubAsync(AddClubFormModel model);

        Task<ClubDetailsViewModel?> GetClubDetailsByIdAsync(Guid id);

        Task<EditClubFormModel?> GetClubForEditByIdAsync(Guid id);

        Task<bool> EditClubAsync(EditClubFormModel model);

        Task<DeleteClubViewModel?> GetClubForDeleteByIdAsync(Guid id);

        Task<bool> SoftDeleteClubAsync(Guid id);
    }
}
