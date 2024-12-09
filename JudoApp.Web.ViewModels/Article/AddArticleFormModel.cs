namespace JudoApp.Web.ViewModels.Article
{
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    using static JudoApp.Common.EntityValidationConstants.Article;

    public class AddArticleFormModel : IMapTo<Article>
    {
        [Required]
        [MinLength(TittleMinLenght)]
        [MaxLength(TittleMaxLenght)]
        public string Tittle { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLenght)]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl { get; set; }
    }
}
