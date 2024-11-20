
namespace JudoApp.Web.ViewModels.Judge
{
    using Services.Mapping;
    using Data.Models;

    public class JudgeIndexViewModel : IMapFrom<Judge>
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
