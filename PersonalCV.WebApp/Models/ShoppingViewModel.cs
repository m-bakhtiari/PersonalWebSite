using PersonalCV.Core.Entities;

namespace PersonalCV.WebApp.Models
{
    public class ShoppingViewModel
    {
        public TemplatePaging TemplatePaging { get; set; }
        public Contact Contact { get; set; }

        public string Email { get; set; }
        public string LinkedIn { get; set; }
        public string HeaderPhoto { get; set; }
        public string ProfilePhoto { get; set; }
        public string TelegramUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string WhatsappUrl { get; set; }
        public string MapPhoto { get; set; }

    }
}
