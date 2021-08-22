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
                SidebarMyPhoto = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.SidebarMyPhoto)?.Value,
                HeaderMyPhoto = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.HeaderMyPhoto)?.Value,
                AboutMyPhoto = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.AboutMyPhoto)?.Value,
                JobFirstAddress = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.JobFirstAddress)?.Value,
                JobFirstDescription1 = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.JobFirstDescription1)?.Value,
                JobFirstDescription2 = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.JobFirstDescription2)?.Value,
                JobFirstDescription3 = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.JobFirstDescription3)?.Value,
                JobSecondDescription1 = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.JobSecondDescription1)?.Value,
                JobSecondDescription2 = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.JobSecondDescription2)?.Value,
                JobSecondDescription3 = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.JobSecondDescription3)?.Value,
                JobSecondTitle = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.JobSecondTitle)?.Value,
                JobSecondAddress = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.JobSecondAddress)?.Value,
                JobSecondYear = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.JobSecondYear)?.Value,
                ContactText = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.ContactText)?.Value,
                EducationFirstAddress = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.EducationFirstAddress)?.Value,
                EducationFirstTitle = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.EducationFirstTitle)?.Value,
                EducationFirstYear = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.EducationFirstYear)?.Value,
                EducationSecondAddress = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.EducationSecondAddress)?.Value,
                EducationSecondTitle = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.EducationSecondTitle)?.Value,
                EducationSecondYear = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.EducationSecondYear)?.Value,
                GithubUrl = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.GithubUrl)?.Value,
                GithubText = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.GithubText)?.Value,
                AboutTitle = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.AboutTitle)?.Value,
                JobFirstTitle = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.JobFirstTitle)?.Value,
                JobFirstYear = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.JobFirstYear)?.Value,
                TemplateText = siteInfo
                    .FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.TemplateText)?.Value,
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
