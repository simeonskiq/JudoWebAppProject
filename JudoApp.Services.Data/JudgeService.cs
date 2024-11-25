namespace JudoApp.Services.Data
{
    using JudoApp.Data.Models;
    using JudoApp.Data.Repository.Interfaces;
    using JudoApp.Services.Data.Interfaces;
    using JudoApp.Services.Mapping;
    using JudoApp.Web.ViewModels.Judge;
    using Microsoft.EntityFrameworkCore;

    public class JudgeService : BaseService, IJudgeService
    {
        private readonly IRepository<Judge, Guid> judgeRepository;

        public JudgeService(IRepository<Judge, Guid> judgeRepository)
        {
            this.judgeRepository = judgeRepository;
        }

        public async Task<IEnumerable<JudgeIndexViewModel>> IndexGetAllOrderedByNameAsync()
        {
            IEnumerable<JudgeIndexViewModel> judges = await this.judgeRepository
                .GetAllAttached()
                .Where(j => j.IsDeleted == false)
                .OrderBy(j => j.Name)
                .To<JudgeIndexViewModel>()
                .ToArrayAsync();

            return judges;
        }

        public async Task AddJudgeAsync(AddJudgeFormModel model)
        {
            Judge judge = new Judge();
            AutoMapperConfig.MapperInstance.Map(model, judge);

            await this.judgeRepository.AddAsync(judge);
        }

        public async Task<EditJudgeFormModel?> GetJudgeForEditByIdAsync(Guid id)
        {
            EditJudgeFormModel? judgeModel = await this.judgeRepository
                .GetAllAttached()
                .Where(j => j.IsDeleted == false)
                .To<EditJudgeFormModel>()
                .FirstOrDefaultAsync(j => j.Id.ToLower() == id.ToString().ToLower());

            return judgeModel;
        }

        public async Task<bool> EditJudgeAsync(EditJudgeFormModel model)
        {
            Judge judgeEntity = AutoMapperConfig.MapperInstance
                .Map<EditJudgeFormModel, Judge>(model);

            bool result = await this.judgeRepository.UpdateAsync(judgeEntity);

            return result;
        }

        public async Task<DeleteJudgeViewModel?> GetJudgeForDeleteByIdAsync(Guid id)
        {
            DeleteJudgeViewModel? judgeToDelete = await this.judgeRepository
                .GetAllAttached()
                .Where(j => j.IsDeleted == false)
                .To<DeleteJudgeViewModel>()
                .FirstOrDefaultAsync(j => j.Id.ToLower() == id.ToString().ToLower());

            return judgeToDelete;
        }

        public async Task<bool> SoftDeleteJudgeAsync(Guid id)
        {
            Judge? judgeToDelete = await this.judgeRepository
                .FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToString().ToLower());
            if (judgeToDelete == null)
            {
                return false;
            }

            judgeToDelete.IsDeleted = true;
            return await this.judgeRepository.UpdateAsync(judgeToDelete);
        }
    }
}
