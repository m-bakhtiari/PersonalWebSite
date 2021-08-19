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
        private readonly ClientLanguageService _clientLanguageService;

        public HomeController(ILogger<HomeController> logger, SiteInfoService siteInfoService, TemplateGroupService templateGroupService, TemplateService templateService, SkillService skillService, HostPlanService hostPlanService, ClientLanguageService clientLanguageService)
        {
            _logger = logger;
            _siteInfoService = siteInfoService;
            _templateGroupService = templateGroupService;
            _templateService = templateService;
            _skillService = skillService;
            _hostPlanService = hostPlanService;
            _clientLanguageService = clientLanguageService;
        }

        public async Task<IActionResult> Index(int? groupId, int pageId = 1)
        {
            if (await _clientLanguageService.IsIPExist(Request.HttpContext.Connection.RemoteIpAddress?.ToString()) == false)
            {
                await _clientLanguageService.Add(Request.HttpContext.Connection.RemoteIpAddress?.ToString());
            }
            var siteInfo = await _siteInfoService.GetAll();
            var template = await _templateGroupService.GetAllByPaging(groupId, pageId);
            var templateVm = new TemplatePaging()
            {
                PageCount = template.Item2,
                TemplateGroups = template.Item1,
                PageId = pageId,
                TemplateText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.TemplateText)?.Value,
            };
            var model = new HomePageViewModel()
            {
                Skills = await _skillService.GetAll(),
                TemplatePaging = templateVm,
            };
            if (await _clientLanguageService.IsInEnglish(Request.HttpContext.Connection.RemoteIpAddress?.ToString()))
            {
                model.Phone = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Phone)?.Value;
                model.BirthDay = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.BirthDay)?.Value;
                model.Email = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Email)?.Value;
                model.AboutText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.AboutText)?.Value;
                model.Age = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Age)?.Value;
                model.City = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.City)?.Value;
                model.CountOfCustomers =
                    siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.CountOfCustomers)?.Value;
                model.CountOfPublishedProjects = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.CountOfPublishedProjects)?.Value;
                model.CountOfTestProjects = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.CountOfTestProjects)?.Value;
                model.Degree = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Degree)?.Value;
                model.FactsText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.FactsText)?.Value;
                model.FreeLanceText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.FreeLanceText)
                    ?.Value;
                model.InstagramUrl = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.InstagramUrl)
                    ?.Value;
                model.SkillsText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.SkillsText)
                    ?.Value;
                model.TelegramUrl = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.TelegramUrl)
                    ?.Value;
                model.Website = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Website)?.Value;
                model.WhatsappUrl = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.WhatsappUrl)
                    ?.Value;
                model.ResumeText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.ResumeText)
                    ?.Value;
                model.YearsCountOfExperience = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.YearsCountOfExperience)?.Value;
                model.BiographySummaryText = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.BiographySummaryText)?.Value;
            }
            else
            {
                model.Phone = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Phone)?.PersianValue;
                model.BirthDay = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.BirthDay)?.PersianValue;
                model.Email = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Email)?.PersianValue;
                model.AboutText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.AboutText)?.PersianValue;
                model.Age = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Age)?.PersianValue;
                model.City = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.City)?.PersianValue;
                model.CountOfCustomers =
                    siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.CountOfCustomers)?.PersianValue;
                model.CountOfPublishedProjects = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.CountOfPublishedProjects)?.PersianValue;
                model.CountOfTestProjects = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.CountOfTestProjects)?.PersianValue;
                model.Degree = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Degree)?.PersianValue;
                model.FactsText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.FactsText)?.PersianValue;
                model.FreeLanceText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.FreeLanceText)
                    ?.PersianValue;
                model.InstagramUrl = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.InstagramUrl)
                    ?.PersianValue;
                model.SkillsText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.SkillsText)
                    ?.PersianValue;
                model.TelegramUrl = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.TelegramUrl)
                    ?.PersianValue;
                model.Website = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Website)?.PersianValue;
                model.WhatsappUrl = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.WhatsappUrl)
                    ?.PersianValue;
                model.ResumeText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.ResumeText)
                    ?.PersianValue;
                model.YearsCountOfExperience = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.YearsCountOfExperience)?.PersianValue;
                model.BiographySummaryText = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.BiographySummaryText)?.PersianValue;
            }

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetTemplateGroups(int? groupId, int pageId = 1)
        {
            var template = await _templateGroupService.GetAllByPaging(groupId, pageId);

            var model = new TemplatePaging()
            {
                PageCount = template.Item2,
                TemplateGroups = template.Item1,
                PageId = pageId,
                TemplateText = await _siteInfoService.GetTemplateText(),
            };
            return PartialView("_Template", model);
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

        public ActionResult Admin()
        {
            return View();
        }
    }
}
