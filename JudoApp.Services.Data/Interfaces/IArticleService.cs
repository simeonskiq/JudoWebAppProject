namespace JudoApp.Services.Data.Interfaces
{

    using JudoApp.Web.ViewModels.Article;

    public interface IArticleService
    {
        Task<IEnumerable<ArticleIndexViewModel>> IndexGetAllOrderedByNameAsync();

        Task AddArticleAsync(AddArticleFormModel model);

        Task<ArticleDetailsViewModel?> GetArticleDetailsByIdAsync(Guid id);

        Task<EditArticleFormModel?> GetArticleForEditByIdAsync(Guid id);

        Task<bool> EditArticleAsync(EditArticleFormModel model);

        Task<DeleteArticleViewModel?> GetArticleForDeleteByIdAsync(Guid id);

        Task<bool> SoftDeleteArticleAsync(Guid id);
    }
}
