﻿namespace JudoApp.Web.ViewModels.Article
{
    public class ArticleDetailsViewModel
    {
        public string Id { get; set; } = null!;

        public string Tittle { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}