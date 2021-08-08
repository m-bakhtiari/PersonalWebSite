using PersonalCV.Core.Entities;
using System.Collections.Generic;

namespace PersonalCV.WebApp.Models
{
    public class HomePageViewModel
    {
        public string AboutText { get; set; }
        public string BirthDay { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Age { get; set; }
        public string Degree { get; set; }
        public string Email { get; set; }
        public string FreeLanceText { get; set; }
        public string HeaderMyPhoto { get; set; }
        public string SidebarMyPhoto { get; set; }
        public string AboutMyPhoto { get; set; }
        public string CountOfTestProjects { get; set; }
        public string CountOfPublishedProjects { get; set; }
        public string CountOfCustomers { get; set; }
        public string YearsCountOfExperience { get; set; }
        public string FactsText { get; set; }
        public string SkillsText { get; set; }
        public string TelegramUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string WhatsappUrl { get; set; }
        public string AboutTitle { get; set; }
        public string ResumeText { get; set; }
        public string BiographySummaryText { get; set; }

        public List<Skill> Skills { get; set; }
    }

}
