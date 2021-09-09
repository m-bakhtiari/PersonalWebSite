using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Entities;
using PersonalCV.Core.Services;
using System.Threading.Tasks;
using PersonalCV.Core.Enums;
using PersonalCV.WebApp.Models;

namespace PersonalCV.WebApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactService _contactService;
        private readonly SiteInfoService _siteInfoService;

        public ContactsController(ContactService contactService, SiteInfoService siteInfoService)
        {
            _contactService = contactService;
            _siteInfoService = siteInfoService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _contactService.GetAll());
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _contactService.GetItemById(id.Value);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            var des = "با تشکر از پیام شما به زودی به پیام شما پاسخ خواهم داد. در صورت نیاز می توانید از شبکه های مجازی زیر با من در ارتباط باشید";
            if (contact.Phone.Length != 11 || contact.Phone.Length != 8)
            {
                des = "";
                des += "شماره تماس شما معتبر نمی باشد . لطفا پیام خود را با شماره تماس معتبر دوباره وارد نمایید";
            }
            else if (string.IsNullOrWhiteSpace(contact.Phone) && string.IsNullOrWhiteSpace(contact.Email))
            {
                des = "";
                des += "ایمیل یا شماره تماس خود را وارد نمایید . لطفا پیام خود را با ایمیل یا شماره تماس دوباره وارد نمایید ";
            }
            else if (string.IsNullOrWhiteSpace(contact.Message))
            {
                des = "";
                des += "پیامی وارد نشده است ";
            }
            else
            {
                await _contactService.Add(contact);
            }
            var model = await _siteInfoService.GetInfoForErrorPage();
            return View("ContactMessage", new ErrorViewModel
            {
                TelegramUrl = model.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.TelegramUrl)?.Value,
                InstagramUrl = model.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.InstagramUrl)?.Value,
                WhatsAppUrl = model.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.WhatsappUrl)?.Value,
                LinkedInUrl = model.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.LinkedIn)?.Value,
                EmailUrl = model.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.Email)?.Value,
                NotFoundPageBackground = model.FirstOrDefault(x => x.Key == GeneralEnums.GeneralEnum.NotFoundPageBackground)?.Value,
                Description = des
            });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> SetAsRead(int id)
        {
            try
            {
                await _contactService.SetAsRead(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _contactService.ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
