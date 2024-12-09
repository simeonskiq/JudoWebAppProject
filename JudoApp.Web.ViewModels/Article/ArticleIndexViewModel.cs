namespace JudoApp.Web.ViewModels.Article
{
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;

    public class ArticleIndexViewModel : IMapFrom<Article>
    {
        public string Id { get; set; } = null!;

        public string Tittle { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}
