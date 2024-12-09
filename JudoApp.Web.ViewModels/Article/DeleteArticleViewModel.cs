using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudoApp.Web.ViewModels.Article
{
    public class DeleteArticleViewModel
    {
        public string Id { get; set; } = null!;

        public string? Tittle { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
    }
}
