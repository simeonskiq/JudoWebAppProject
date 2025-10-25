namespace JudoApp.Web.ViewModels.Article
{
    using AutoMapper;
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    using static JudoApp.Common.EntityValidationConstants.Article;

    public class EditArticleFormModel : IHaveCustomMappings
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MinLength(TittleMinLength)]
        [MaxLength(TittleMaxLength)]
        public string Tittle { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Article, EditArticleFormModel>();

            configuration
                .CreateMap<EditArticleFormModel, Article>()
                .ForMember(d => d.Id, x => x.MapFrom(s => Guid.Parse(s.Id)));
        }
    }
}
