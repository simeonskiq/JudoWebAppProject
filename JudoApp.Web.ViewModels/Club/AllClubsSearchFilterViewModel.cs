namespace JudoApp.Web.ViewModels.Club
{
    public class AllClubsSearchFilterViewModel
    {
        public IEnumerable<ClubIndexViewModel>? Clubs { get; set; }
        public string? SearchQuery { get; set; }
        public string? CityFilter { get; set; }
        public IEnumerable<string>? AllCityes { get; set; }
        public int? CurrentPage { get; set; } = 1;
        public int? EntitiesPerPage { get; set; } = 5;
        public int? TotalPages { get; set; }
    }
}
