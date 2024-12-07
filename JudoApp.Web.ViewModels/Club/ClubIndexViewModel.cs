﻿namespace JudoApp.Web.ViewModels.Club
{
    using Services.Mapping;
    using Data.Models;

    public class ClubIndexViewModel : IMapFrom<Club>
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string City { get; set; } = null!;

        public string? PhoneNumber { get; set; }
    }
}
