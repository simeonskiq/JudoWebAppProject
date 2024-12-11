namespace JudoApp.Services.Data
{

    using JudoApp.Data.Models;
    using JudoApp.Data.Repository.Interfaces;
    using JudoApp.Services.Data.Interfaces;
    using JudoApp.Services.Mapping;
    using JudoApp.Web.ViewModels.Article;
    using Microsoft.EntityFrameworkCore;

    public class ArticleService : BaseService, IArticleService
    {
        private readonly IRepository<Article, Guid> articleRepository;

        public ArticleService(IRepository<Article, Guid> articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public async Task<IEnumerable<ArticleIndexViewModel>> IndexGetAllOrderedByNameAsync()
        {
            IEnumerable<ArticleIndexViewModel> articles = await this.articleRepository
                .GetAllAttached()
                .Where(a => a.IsDeleted == false)
                .OrderBy(a => a.Tittle)
                .To<ArticleIndexViewModel>()
                .ToArrayAsync();

            return articles;
        }

        public async Task AddArticleAsync(AddArticleFormModel model)
        {
            Article article = new Article();
            AutoMapperConfig.MapperInstance.Map(model, article);

            await this.articleRepository.AddAsync(article);
        }

        public async Task<ArticleDetailsViewModel?> GetArticleDetailsByIdAsync(Guid id)
        {
            Article? article = await this.articleRepository
              .GetAllAttached()
              .Where(a => a.IsDeleted == false)
              .FirstOrDefaultAsync(a => a.Id == id);

            ArticleDetailsViewModel? viewModel = null;
            if (article != null)
            {
                viewModel = new ArticleDetailsViewModel()
                {
                    Id = article.Id.ToString(),
                    Tittle = article.Tittle,
                    Description = article.Description,
                    ImageUrl = article.ImageUrl,
                    DateUploaded = article.DateUploaded,
                };
            }

            return viewModel;
        }

        public async Task<EditArticleFormModel?> GetArticleForEditByIdAsync(Guid id)
        {
            EditArticleFormModel? articleModel = await this.articleRepository
                .GetAllAttached()
                .Where(a => a.IsDeleted == false)
                .To<EditArticleFormModel>()
                .FirstOrDefaultAsync(a => a.Id.ToLower() == id.ToString().ToLower());

            return articleModel;
        }

        public async Task<bool> EditArticleAsync(EditArticleFormModel model)
        {
            Article articleEntity = AutoMapperConfig.MapperInstance
                .Map<EditArticleFormModel, Article>(model);

            bool result = await this.articleRepository.UpdateAsync(articleEntity);

            return result;
        }

        public async Task<DeleteArticleViewModel?> GetArticleForDeleteByIdAsync(Guid id)
        {
            DeleteArticleViewModel? articleToDelete = await this.articleRepository
                .GetAllAttached()
                .Where(a => a.IsDeleted == false)
                .To<DeleteArticleViewModel>()
                .FirstOrDefaultAsync(a => a.Id.ToLower() == id.ToString().ToLower());

            return articleToDelete;
        }

        public async Task<bool> SoftDeleteArticleAsync(Guid id)
        {
            Article? articleToDelete = await this.articleRepository
                .FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToString().ToLower());
            if (articleToDelete == null)
            {
                return false;
            }

            articleToDelete.IsDeleted = true;
            return await this.articleRepository.UpdateAsync(articleToDelete);
        }
    }
}