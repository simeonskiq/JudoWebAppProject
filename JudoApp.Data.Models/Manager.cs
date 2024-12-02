namespace JudoApp.Data.Models
{
    public class Manager
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Reason { get; set; } = null!;

        public string WorkPhoneNumber { get; set; } = null!;

        public DateTime SubmittedOn { get; set; }

        public bool IsApproved { get; set; } = false;

        public DateTime? ApprovedOn { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
