using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalCV.WebApp.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PersonalCV.Core.Enums;
using PersonalCV.Core.Services;

namespace PersonalCV.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SiteInfoService _siteInfoService;
        private readonly TemplateGroupService _templateGroupService;
        private readonly TemplateService _templateService;
        private readonly SkillService _skillService;
        private readonly HostPlanService _hostPlanService;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var siteInfo = await _siteInfoService.GetAll();
            var model = new HomePageViewModel()
            {
                Phone = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Phone)?.Value,
                BirthDay = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.BirthDay)?.Value,
                Email = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Email)?.Value,
                AboutText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.AboutText)?.Value,
                Age = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Age)?.Value,
                City = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.City)?.Value,
                CountOfCustomers = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.CountOfCustomers)?.Value,
                CountOfPublishedProjects = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.CountOfPublishedProjects)?.Value,
                CountOfTestProjects = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.CountOfTestProjects)?.Value,
                Degree = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Degree)?.Value,
                FactsText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.FactsText)?.Value,
                FreeLanceText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.FreeLanceText)?.Value,
                InstagramUrl = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.InstagramUrl)?.Value,
                SkillsText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.SkillsText)?.Value,
                TelegramUrl = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.TelegramUrl)?.Value,
                Website = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Website)?.Value,
                WhatsappUrl = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.WhatsappUrl)?.Value,
                YearsCountOfExperience = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.YearsCountOfExperience)?.Value,
                Skills = await _skillService.GetAll(),
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
