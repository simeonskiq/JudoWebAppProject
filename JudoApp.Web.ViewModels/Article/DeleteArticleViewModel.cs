namespace JudoApp.Web.ViewModels.Article
{
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;

    public class DeleteArticleViewModel : IMapFrom<Article>
    {
        public string Id { get; set; } = null!;

        public string? Tittle { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
    }
}
