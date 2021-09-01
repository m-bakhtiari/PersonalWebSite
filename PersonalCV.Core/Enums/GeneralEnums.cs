using System.ComponentModel;

namespace PersonalCV.Core.Enums
{
    public class GeneralEnums
    {
        public enum GeneralEnum : int
        {
            [Description("AboutText")]
            AboutText = 1,

            [Description("Phone")]
            Phone = 2,

            [Description("Age")]
            Age = 3,

            [Description("Email")]
            Email = 4,

            [Description("LinkedIn")]
            LinkedIn = 5,

            [Description("CountOfTestProjects")]
            CountOfTestProjects = 6,

            [Description("CountOfPublishedProjects")]
            CountOfPublishedProjects = 7,

            [Description("CountOfCustomers")]
            CountOfCustomers = 8,

            [Description("YearsCountOfExperience")]
            YearsCountOfExperience = 9,

            [Description("TelegramUrl")]
            TelegramUrl = 10,

            [Description("InstagramUrl")]
            InstagramUrl = 11,

            [Description("WhatsappUrl")]
            WhatsappUrl = 12,

            [Description("Username")]
            Username = 13,

            [Description("Password")]
            Password = 14,

            [Description("HeaderPhoto")]
            HeaderMyPhoto = 15,

            [Description("AboutTitle")]
            AboutTitle = 16,

            [Description("FirstEducationTime")]
            FirstEducationTime = 17,

            [Description("FirstEducationDegree")]
            FirstEducationDegree = 18,

            [Description("FirstEducationTitle")]
            FirstEducationTitle = 19,

            [Description("FirstEducationName")]
            FirstEducationName = 20,

            [Description("FirstEducationDescription")]
            FirstEducationDescription = 21,

            [Description("SecondEducationTime")]
            SecondEducationTime = 22,

            [Description("SecondEducationDegree")]
            SecondEducationDegree = 23,

            [Description("SecondEducationTitle")]
            SecondEducationTitle = 24,

            [Description("SecondEducationName")]
            SecondEducationName = 25,

            [Description("SecondEducationDescription")]
            SecondEducationDescription = 26,

            [Description("JobFirstTitle")]
            FirstJobTitle = 27,

            [Description("JobFirstYear")]
            FirstJobYear = 28,

            [Description("JobFirstSubject")]
            FirstJobAddress = 29,

            [Description("JobFirstDescription")]
            FirstJobDescription = 30,

            [Description("JobSecondTitle")]
            SecondJobTitle = 31,

            [Description("JobSecondYear")]
            SecondJobYear = 32,

            [Description("JobSecondSubject")]
            SecondJobAddress = 33,

            [Description("JobSecondDescription")]
            SecondJobDescription = 34,

            [Description("Language")]
            Language = 35,

            [Description("Address")]
            Address = 36,

            [Description("GithubUrl")]
            GithubUrl = 37,

            [Description("GithubText")]
            GithubText = 38,

            [Description("NotFoundPageBackground")]
            NotFoundPageBackground = 39,

            [Description("ProfilePhoto")]
            ProfilePhoto = 40,

            [Description("FirstJobSubject")]
            FirstJobSubject = 41,

            [Description("SecondJobSubject")]
            SecondJobSubject = 42,

            [Description("CvFileForDownload")]
            CvFileForDownload=43,

            [Description("MapPhoto")]
            MapPhoto=44,
        }
    }
}
