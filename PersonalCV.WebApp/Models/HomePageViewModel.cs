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
        public string GithubText { get; set; }
        public string GithubUrl { get; set; }
        public string ContactText { get; set; }
        public string EducationFirstTitle { get; set; }
        public string EducationFirstYear { get; set; }
        public string EducationFirstAddress { get; set; }
        public string EducationSecondTitle { get; set; }
        public string EducationSecondYear { get; set; }
        public string EducationSecondAddress { get; set; }
        public string JobFirstTitle { get; set; }
        public string JobFirstYear { get; set; }
        public string JobFirstAddress { get; set; }
        public string JobFirstDescription1 { get; set; }
        public string JobFirstDescription2 { get; set; }
        public string JobFirstDescription3 { get; set; }
        public string JobSecondTitle { get; set; }
        public string JobSecondYear { get; set; }
        public string JobSecondAddress { get; set; }
        public string JobSecondDescription1 { get; set; }
        public string JobSecondDescription2 { get; set; }
        public string JobSecondDescription3 { get; set; }
        public string TemplateText { get; set; }

        public List<Skill> Skills { get; set; }
        public Contact Contact { get; set; }
        public TemplatePaging TemplatePaging { get; set; }
    }

}
