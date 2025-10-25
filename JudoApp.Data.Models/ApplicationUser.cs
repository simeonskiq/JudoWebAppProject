namespace JudoApp.Data.Models
{

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();

        }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
