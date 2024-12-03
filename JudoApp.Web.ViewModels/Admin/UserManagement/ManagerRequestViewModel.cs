using System.ComponentModel.DataAnnotations;

namespace JudoApp.Web.ViewModels.Admin.UserManagement
{
    public class ManagerRequestViewModel
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string RequestMessage { get; set; }

        public bool IsApproved { get; set; }

        public DateTime RequestedOn { get; set; }
    }
}
