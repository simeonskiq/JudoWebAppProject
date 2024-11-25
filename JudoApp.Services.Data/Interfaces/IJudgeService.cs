namespace JudoApp.Services.Data.Interfaces
{

    using JudoApp.Web.ViewModels.Judge;

    public interface IJudgeService
    {
        Task<IEnumerable<JudgeIndexViewModel>> IndexGetAllOrderedByNameAsync();

        Task AddJudgeAsync(AddJudgeFormModel model);

        Task<EditJudgeFormModel?> GetJudgeForEditByIdAsync(Guid id);

        Task<bool> EditJudgeAsync(EditJudgeFormModel model);

        Task<DeleteJudgeViewModel?> GetJudgeForDeleteByIdAsync(Guid id);

        Task<bool> SoftDeleteJudgeAsync(Guid id);
    }
}
