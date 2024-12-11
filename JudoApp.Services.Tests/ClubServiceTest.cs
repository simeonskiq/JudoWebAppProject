namespace JudoApp.Services.Tests
{
    using JudoApp.Data.Models;
    using JudoApp.Data.Repository.Interfaces;
    using JudoApp.Data.Seeding.DataTransferObjects;
    using JudoApp.Services.Data;
    using JudoApp.Services.Data.Interfaces;
    using JudoApp.Services.Mapping;
    using JudoApp.Web.ViewModels;
    using JudoApp.Web.ViewModels.Club;
    using MockQueryable;
    using Moq;

    [TestFixture]
    public class Tests
    {
        private IList<Club> clubsData = new List<Club>()
        {
            new Club()
            {
                Id = Guid.Parse("B090E55A-C442-44B4-9990-42682FBC426A"),
                Name = "Loko Ruse",
                Address = "Zala. „Dunav“, ul. „Chiprovci“ 40",
                City = "Ruse",
                PhoneNumber = "+359 8 7662 3232",
                ImageUrl = "https://scontent.fsof10-1.fna.fbcdn.net/v/t1.6435-1/167102064_142336974504498_8650392569226106968_n.jpg?_nc_cat=107&ccb=1-7&_nc_sid=f4b9fd&_nc_ohc=nQpOyuYQJZIQ7kNvgFgjbRG&_nc_zt=24&_nc_ht=scontent.fsof10-1.fna&_nc_gid=AReiDQjPCNMxo9mkAy5daxp&oh=00_AYAy70YvVf4Lbxi0JzzBALqDKwmN_RmQXEKi6H3pEGNlYw&oe=6781495A",
            },
            new Club()
            {
                Id = Guid.Parse("54DBFB8F-DB2C-4062-A66E-03E889B4A648"),
                Name = "SK CSKA Sofia",
                Address = "bul. „Prof. Cvetan Lazarov“ ¹14",
                City = "Sofia",
                PhoneNumber = "0898 702 088",
                ImageUrl = "https://imgs.search.brave.com/cyvqnAYUZauGHq6Rlx7FHrCdYrIAL6hbQsyJqyFGKLk/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly91cGxv/YWQud2lraW1lZGlh/Lm9yZy93aWtpcGVk/aWEvY29tbW9ucy81/LzVjL0NTS0FfOTgt/OTkucG5n",
            }
        };

        private Mock<IRepository<Club, Guid>> clubRepository;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly,
                typeof(ImportClubDto).Assembly);
        }

        [SetUp]
        public void Setup()
        {
            this.clubRepository = new Mock<IRepository<Club, Guid>>();
        }

        [Test]
        public async Task GetAllClubsNoFilterPositive()
        {
            IQueryable<Club> clubsMockQueryable = clubsData.BuildMock();
            this.clubRepository
                .Setup(r => r.GetAllAttached())
                .Returns(clubsMockQueryable);

            IClubService clubService = new ClubService(clubRepository.Object);

            IEnumerable<ClubIndexViewModel> allClubsActual = await clubService
                .GetAllClubsAsync(new AllClubsSearchFilterViewModel());

            Assert.IsNotNull(allClubsActual);
            Assert.AreEqual(this.clubsData.Count(), allClubsActual.Count());

            allClubsActual = allClubsActual
                .OrderBy(m => m.Id)
                .ToList();

            int i = 0;
            foreach (ClubIndexViewModel returnedClub in allClubsActual)
            {
                Assert.AreEqual(this.clubsData.OrderBy(m => m.Id).ToList()[i++].Id.ToString(), returnedClub.Id);
            }
        }

        [Test]
        [TestCase("Av")]
        [TestCase("av")]
        public async Task GetAllClubsSearchQueryPositive(string searchQuery)
        {
            int expectedClubsCount = 1;
            string expectedClubId = "B090E55A-C442-44B4-9990-42682FBC426A";

            IQueryable<Club> clubsMockQueryable = clubsData.BuildMock();
            this.clubRepository
                .Setup(r => r.GetAllAttached())
                .Returns(clubsMockQueryable);

            IClubService clubService = new ClubService(clubRepository.Object);

            IEnumerable<ClubIndexViewModel> allClubsActual = await clubService
                .GetAllClubsAsync(new AllClubsSearchFilterViewModel()
                {
                    SearchQuery = "Av",
                });

            Assert.IsNotNull(allClubsActual);
            Assert.AreEqual(expectedClubsCount, allClubsActual.Count());
            Assert.AreEqual(expectedClubId.ToLower(), allClubsActual.First().Id.ToLower());
        }

        [Test]
        public async Task GetAllClubsNullFilterNegative()
        {
            IQueryable<Club> clubsMockQueryable = clubsData.BuildMock();
            this.clubRepository
                .Setup(r => r.GetAllAttached())
                .Returns(clubsMockQueryable);

            IClubService clubService = new ClubService(clubRepository.Object);

            Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                IEnumerable<ClubIndexViewModel> allClubsActual = await clubService
                    .GetAllClubsAsync(null);
            });
        }
    }
}