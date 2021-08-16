using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Entities;
using PersonalCV.Core.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PersonalCV.WebApp.Models;

namespace PersonalCV.WebApp.Controllers
{
    [Authorize]
    public class TemplatesController : Controller
    {
        private readonly TemplateService _templateService;
        private readonly TemplateGroupService _templateGroupService;

        public TemplatesController(TemplateService templateService, TemplateGroupService templateGroupService)
        {
            _templateService = templateService;
            _templateGroupService = templateGroupService;
        }

        // GET: Templates
        public async Task<IActionResult> Index()
        {
            return View(await _templateService.GetAll());
        }

        // GET: Templates/Create
        public async Task<IActionResult> Create()
        {
            var model = new TemplateViewModel();
            ViewData["GroupId"] = new SelectList(await _templateGroupService.GetAll(), "Id", "Title");
            return View(model);
        }

        // POST: Templates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TemplateViewModel templateViewModel)
        {
            if (ModelState.IsValid)
            {
                var template = new Template()
                {
                    Code = templateViewModel.Code,
                    Description = templateViewModel.Description,
                    GroupId = templateViewModel.GroupId,
                    MainSiteUrl = templateViewModel.MainSiteUrl,
                    Price = templateViewModel.Price,
                    SiteUrlForPreview = templateViewModel.SiteUrlForPreview,
                    Title = templateViewModel.Title,
                };
                await _templateService.Add(template, templateViewModel.Image);
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(await _templateGroupService.GetAll(), "Id", "Title", templateViewModel.GroupId);
            return View(templateViewModel);
        }

        // GET: Templates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var template = await _templateService.GetItemById(id.Value);
            if (template == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(await _templateGroupService.GetAll(), "Id", "Title", template.GroupId);
            var model = new TemplateViewModel()
            {
                Code = template.Code,
                Description = template.Description,
                GroupId = template.GroupId,
                MainSiteUrl = template.MainSiteUrl,
                Price = template.Price,
                SiteUrlForPreview = template.SiteUrlForPreview,
                Title = template.Title,
                Id = template.Id,
                MainImage = template.MainImage
            };
            return View(model);
        }

        // POST: Templates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TemplateViewModel templateViewModel)
        {
            if (id != templateViewModel.Id)
            {
                return NotFound();
            }
            var template = new Template()
            {
                Code = templateViewModel.Code,
                Description = templateViewModel.Description,
                GroupId = templateViewModel.GroupId,
                MainSiteUrl = templateViewModel.MainSiteUrl,
                Price = templateViewModel.Price,
                SiteUrlForPreview = templateViewModel.SiteUrlForPreview,
                Title = templateViewModel.Title,
                Id = templateViewModel.Id,
                MainImage = templateViewModel.MainImage
            };
            if (ModelState.IsValid)
            {
                try
                {
                    await _templateService.Update(template, templateViewModel.Image);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _templateService.TemplateExists(id))
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
            ViewData["GroupId"] = new SelectList(await _templateGroupService.GetAll(), "Id", "Title", template.GroupId);
            return View(template);
        }

        // GET: Templates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var template = await _templateService.GetItemById(id.Value);
            if (template == null)
            {
                return NotFound();
            }

            return View(template);
        }

        // POST: Templates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var template = await _templateService.GetItemById(id);
            await _templateService.Delete(template);
            return RedirectToAction(nameof(Index));
        }
    }
}
