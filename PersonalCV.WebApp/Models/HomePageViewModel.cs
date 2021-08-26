using PersonalCV.Core.Entities;
using System.Collections.Generic;

namespace PersonalCV.WebApp.Models
{
    public class HomePageViewModel
    {
        public string AboutText { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string LinkedIn { get; set; }
        public string HeaderPhoto { get; set; }
        public string ProfilePhoto { get; set; }
        public string CountOfTestProjects { get; set; }
        public string CountOfPublishedProjects { get; set; }
        public string CountOfCustomers { get; set; }
        public string YearsCountOfExperience { get; set; }
        public string TelegramUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string WhatsappUrl { get; set; }
        public string GithubText { get; set; }
        public string GithubUrl { get; set; }
        public string FirstEducationTitle { get; set; }
        public string FirstEducationTime { get; set; }
        public string FirstEducationDegree { get; set; }
        public string FirstEducationName{ get; set; }
        public string FirstEducationDescription { get; set; }
        public string SecondEducationTitle { get; set; }
        public string SecondEducationTime { get; set; }
        public string SecondEducationDegree { get; set; }
        public string SecondEducationName { get; set; }
        public string SecondEducationDescription { get; set; }
        public string FirstJobYear { get; set; }
        public string FirstJobTitle { get; set; }
        public string FirstJobSubject { get; set; }
        public string FirstJobDescription { get; set; }
        public string SecondJobYear { get; set; }
        public string SecondJobTitle { get; set; }
        public string SecondJobSubject { get; set; }
        public string SecondJobDescription { get; set; }
        public string Language { get; set; }

        public List<Skill> Skills { get; set; }
        public Contact Contact { get; set; }
        public TemplatePaging TemplatePaging { get; set; }
    }

}
