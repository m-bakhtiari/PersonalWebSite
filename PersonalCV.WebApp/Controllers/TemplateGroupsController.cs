using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Entities;
using PersonalCV.Core.Services;
using System.Threading.Tasks;

namespace PersonalCV.WebApp.Controllers
{
    public class TemplateGroupsController : Controller
    {
        private readonly TemplateGroupService _templateGroupService;

        public TemplateGroupsController(TemplateGroupService templateGroupService)
        {
            _templateGroupService = templateGroupService;
        }

        // GET: Admin/TemplateGroups
        public async Task<IActionResult> Index()
        {
            var groups = await _templateGroupService.GetAll();
            return View(groups);
        }

        // GET: Admin/TemplateGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TemplateGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TemplateGroup templateGroup)
        {
            if (ModelState.IsValid)
            {
                await _templateGroupService.CreateGroup(templateGroup);
                return RedirectToAction(nameof(Index));
            }
            return View(templateGroup);
        }

        // GET: Admin/TemplateGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var templateGroup = await _templateGroupService.GetGroupById(id.Value);
            if (templateGroup == null)
            {
                return NotFound();
            }
            return View(templateGroup);
        }

        // POST: Admin/TemplateGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TemplateGroup templateGroup)
        {
            if (id != templateGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _templateGroupService.UpdateGroup(templateGroup);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _templateGroupService.TemplateGroupExists(templateGroup.Id))
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
            return View(templateGroup);
        }

        // GET: Admin/TemplateGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var templateGroup = await _templateGroupService.GetGroupById(id.Value);
            if (templateGroup == null)
            {
                return NotFound();
            }

            return View(templateGroup);
        }

        // POST: Admin/TemplateGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var templateGroup = await _templateGroupService.GetGroupById(id);
            await _templateGroupService.DeleteGroup(templateGroup);
            return RedirectToAction(nameof(Index));
        }

    }
}
