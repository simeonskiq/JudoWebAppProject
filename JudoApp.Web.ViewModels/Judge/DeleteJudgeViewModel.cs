﻿namespace JudoApp.Web.ViewModels.Judge
{
    using Services.Mapping;
    using Data.Models;


    public class DeleteJudgeViewModel : IMapFrom<Judge>
    {
        public string Id { get; set; } = null!;

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
    }
}
