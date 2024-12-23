﻿namespace JudoApp.Web.ViewModels.Admin.UserManagement
{
    using JudoApp.Data.Models;
    using JudoApp.Services.Mapping;

    public class ManagerRequestViewModel : IMapFrom<ManagerRequest>
    {
        public string Id { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public string Reason { get; set; } = null!;

        public bool IsApproved { get; set; }

        public DateTime RequestedOn { get; set; }
    }
}
