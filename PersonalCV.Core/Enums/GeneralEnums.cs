using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCV.Core.Enums
{
    public class GeneralEnums
    {
        public enum GeneralEnum : int
        {
            [Description("AboutUsText")]
            AboutText = 1,

            [Description("BirthDay")]
            BirthDay = 2,

            [Description("Website")]
            Website = 3,

            [Description("Phone")]
            Phone = 4,

            [Description("City")]
            City = 5,

            [Description("Age")]
            Age = 6,

            [Description("Degree")]
            Degree = 7,

            [Description("Email")]
            Email = 8,

            [Description("FreeLance")]
            FreeLanceText = 9,

            [Description("SidebarMyPhoto")]
            SidebarMyPhoto = 10,

            [Description("CountOfTestProjects")]
            CountOfTestProjects = 11,

            [Description("CountOfPublishedProjects")]
            CountOfPublishedProjects = 12,

            [Description("CountOfCustomers")]
            CountOfCustomers = 13,

            [Description("YearsCountOfExperience")]
            YearsCountOfExperience = 14,

            [Description("FactsText")]
            FactsText = 15,

            [Description("SkillsText")]
            SkillsText = 16,

            [Description("TelegramUrl")]
            TelegramUrl = 17,

            [Description("InstagramUrl")]
            InstagramUrl = 18,

            [Description("WhatsappUrl")]
            WhatsappUrl = 19,

            [Description("Username")]
            Username = 20,

            [Description("Password")]
            Password = 21,

            [Description("HeaderMyPhoto")]
            HeaderMyPhoto = 21,

            [Description("AboutMyPhoto")]
            AboutMyPhoto = 22,

            [Description("AboutTitle")]
            AboutTitle = 23,

            [Description("ResumeText")]
            ResumeText = 24,

            [Description("BiographySummaryText")]
            BiographySummaryText=25,
        }

    }
}
