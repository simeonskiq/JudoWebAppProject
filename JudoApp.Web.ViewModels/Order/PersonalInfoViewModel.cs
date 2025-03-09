namespace JudoApp.Web.ViewModels.Order
{
    public class PersonalInfoViewModel
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public int CurrentStep { get; set; }
    }
}
