namespace JudoApp.Web.ViewModels.Judge
{
    using Services.Mapping;
    using Data.Models;
    using AutoMapper;

    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Judge;
    public class EditJudgeFormModel : IHaveCustomMappings
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [MinLength(ImageUrlMinLength)]
        [MaxLength(ImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Judge, EditJudgeFormModel>();

            configuration
                .CreateMap<EditJudgeFormModel, Judge>()
                .ForMember(d => d.Id, x => x.MapFrom(s => Guid.Parse(s.Id)));
        }
    }
}
