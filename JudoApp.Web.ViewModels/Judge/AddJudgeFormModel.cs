namespace JudoApp.Web.ViewModels.Judge
{
    using Services.Mapping;
    using Data.Models;

    using static Common.EntityValidationConstants.Judge;
    using System.ComponentModel.DataAnnotations;

    public class AddJudgeFormModel : IMapTo<Judge>
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [MinLength(DescriptionMinLenght)]
        [MaxLength(DescriptionMaxLenght)]
        public string? Description { get; set; }

        [MinLength(ImageUrlMinLength)]
        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl { get; set; }
    }
}
