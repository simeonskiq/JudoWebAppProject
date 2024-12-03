namespace JudoApp.Web.ViewModels.Admin.UserManagement
{

    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.ManagerRequest;
    public class AddManagerRequestViewModel : IMapTo<ManagerRequest>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(ReasonMinLength)]
        [MaxLength(ReasonMaxLength)]
        public string Reason { get; set; } = null!;
    }
}
