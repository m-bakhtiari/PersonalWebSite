using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalCV.Core.Enums;
using PersonalCV.Core.Services;
using PersonalCV.WebApp.Models;
using System.Linq;
using System.Threading.Tasks;

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
            };
            var model = new HomePageViewModel
            {
                Skills = await _skillService.GetAll(),
                TemplatePaging = templateVm,
                Phone = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Phone)?.Value,
                Email = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Email)?.Value,
                AboutText = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.AboutText)?.Value,
                Age = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Age)?.Value,
                CountOfCustomers = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.CountOfCustomers)
                    ?.Value,
                CountOfPublishedProjects = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.CountOfPublishedProjects)?.Value,
                CountOfTestProjects = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.CountOfTestProjects)?.Value,
                LinkedIn = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.LinkedIn)
                    ?.Value,
                InstagramUrl = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.InstagramUrl)
                    ?.Value,
                TelegramUrl = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.TelegramUrl)
                    ?.Value,
                WhatsappUrl = siteInfo.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.WhatsappUrl)
                    ?.Value,
                YearsCountOfExperience = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.YearsCountOfExperience)?.Value,
                HeaderPhoto = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.HeaderMyPhoto)?.Value,
                GithubUrl = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.GithubUrl)?.Value,
                GithubText = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.GithubText)?.Value,
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
            };
            if (groupId.HasValue == false)
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

        [Route("Error")]
        public async Task<IActionResult> Error()
        {
            var model = await _siteInfoService.GetInfoForErrorPage();
            return View(new ErrorViewModel
            {
                TelegramUrl = model.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.TelegramUrl)?.Value,
                InstagramUrl = model.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.InstagramUrl)?.Value,
                WhatsAppUrl = model.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.WhatsappUrl)?.Value,
                LinkedInUrl = model.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.LinkedIn)?.Value,
                EmailUrl = model.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Email)?.Value,
                NotFoundPageBackground = model.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.NotFoundPageBackground)?.Value,
            });
        }

        public ActionResult Admin()
        {
            return View();
        }
    }
}
