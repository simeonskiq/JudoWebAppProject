namespace JudoApp.Data.Models
{
    public class ManagerRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string UserId { get; set; } = null!;

        public string Reason { get; set; } = null!;

        public bool IsApproved { get; set; } 

        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
    }
}
