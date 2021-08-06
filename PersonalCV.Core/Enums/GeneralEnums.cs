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
        public enum GeneralEnum:int
        {
            [Description("AboutUsText")]
            AboutUsText = 1,

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
            FreeLance = 9,

            [Description("MyPhoto")]
            MyPhoto = 10,

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
            WhatsappUrl = 19
        }

    }
}
