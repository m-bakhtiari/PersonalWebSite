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

        public HomeController(ILogger<HomeController> logger, SiteInfoService siteInfoService, TemplateGroupService templateGroupService, TemplateService templateService, SkillService skillService, HostPlanService hostPlanService)
        {
            _logger = logger;
            _siteInfoService = siteInfoService;
            _templateGroupService = templateGroupService;
            _templateService = templateService;
            _skillService = skillService;
            _hostPlanService = hostPlanService;
        }

        public async Task<IActionResult> Index(int? groupId, int pageId = 1)
        {
            var siteInfo = await _siteInfoService.GetAll();
            var template = await _templateService.GetAllByPaging(groupId, pageId);
            var templateVm = new TemplatePaging()
            {
                PageCount = template.Item2,
                Templates = template.Item1,
                TemplateGroups = await _templateGroupService.GetAll(),
                PageId = pageId,
                TemplateText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.TemplateText)?.Value,
            };
            var model = new HomePageViewModel
            {
                Skills = await _skillService.GetAll(),
                TemplatePaging = templateVm,
                Phone = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Phone)?.Value,
                BirthDay = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.BirthDay)?.Value,
                Email = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Email)?.Value,
                AboutText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.AboutText)?.Value,
                Age = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Age)?.Value,
                City = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.City)?.Value,
                CountOfCustomers = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.CountOfCustomers)
                    ?.Value,
                CountOfPublishedProjects = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.CountOfPublishedProjects)?.Value,
                CountOfTestProjects = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.CountOfTestProjects)?.Value,
                Degree = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Degree)?.Value,
                FactsText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.FactsText)?.Value,
                LinkedIn = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.LinkedIn)
                    ?.Value,
                InstagramUrl = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.InstagramUrl)
                    ?.Value,
                SkillsText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.SkillsText)
                    ?.Value,
                TelegramUrl = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.TelegramUrl)
                    ?.Value,
                Website = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Website)?.Value,
                WhatsappUrl = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.WhatsappUrl)
                    ?.Value,
                ResumeText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.ResumeText)
                    ?.Value,
                YearsCountOfExperience = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.YearsCountOfExperience)?.Value,
                BiographySummaryText = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.BiographySummaryText)?.Value,
            };

            ViewBag.IsAllSelected = "true";
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetTemplateGroups(int? groupId, int pageId = 1)
        {
            var template = await _templateService.GetAllByPaging(groupId, pageId);

            var model = new TemplatePaging()
            {
                PageCount = template.Item2,
                Templates = template.Item1,
                TemplateGroups = await _templateGroupService.GetAll(),
                PageId = pageId,
                TemplateText = await _siteInfoService.GetTemplateText(),
            };
            if (groupId.HasValue==false)
            {
                ViewBag.IsAllSelected = "true";
            }
            else
            {
                ViewBag.IsAllSelected = "false";
            }
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
