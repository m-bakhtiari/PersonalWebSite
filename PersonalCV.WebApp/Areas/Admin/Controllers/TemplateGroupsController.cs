using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Context;
using PersonalCV.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalCV.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TemplateGroupsController : Controller
    {
        private readonly PersonalCVContext _context;

        public TemplateGroupsController(PersonalCVContext context)
        {
            _context = context;
        }

        // GET: Admin/TemplateGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.TemplateGroups.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id,Title")] TemplateGroup templateGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(templateGroup);
                await _context.SaveChangesAsync();
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

            var templateGroup = await _context.TemplateGroups.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] TemplateGroup templateGroup)
        {
            if (id != templateGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(templateGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemplateGroupExists(templateGroup.Id))
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

            var templateGroup = await _context.TemplateGroups
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var templateGroup = await _context.TemplateGroups.FindAsync(id);
            _context.TemplateGroups.Remove(templateGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemplateGroupExists(int id)
        {
            return _context.TemplateGroups.Any(e => e.Id == id);
        }
    }
}
