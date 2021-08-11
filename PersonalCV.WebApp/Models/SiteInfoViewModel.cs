using Microsoft.AspNetCore.Http;
using PersonalCV.Core.Enums;

namespace PersonalCV.WebApp.Models
{
    public class SiteInfoViewModel
    {
        public int Id { get; set; }

        public GeneralEnums.GeneralEnum Key { get; set; }

        public string Value { get; set; }

        public IFormFile Image { get; set; }
    }
}
