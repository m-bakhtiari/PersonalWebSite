using Microsoft.AspNetCore.Http;

namespace PersonalCV.WebApp.Models
{
    public class TemplateViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Code { get; set; }

        public string SiteUrlForPreview { get; set; }

        public string MainSiteUrl { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string MainImage { get; set; }

        public int GroupId { get; set; }

        public IFormFile Image { get; set; }
    }
}
