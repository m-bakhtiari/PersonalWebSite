using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Entities;
using PersonalCV.Core.Services;
using System.Threading.Tasks;

namespace PersonalCV.WebApp.Controllers
{
    public class SkillDetailsController : Controller
    {
        private readonly SkillDetailService _skillDetailService;
        private readonly SkillService _skillService;

        public SkillDetailsController(SkillDetailService skillDetailService, SkillService skillService)
        {
            _skillDetailService = skillDetailService;
            _skillService = skillService;
        }

        // GET: SkillDetails
        public async Task<IActionResult> Index()
        {
            return View(await _skillDetailService.GetAll());
        }

        // GET: SkillDetails/Create
        public async Task<IActionResult> Create()
        {
            ViewData["SkillId"] = new SelectList(await _skillService.GetAll(), "Id", "Title");
            return View();
        }

        // POST: SkillDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SkillDetail skillDetail)
        {
            if (ModelState.IsValid)
            {
                await _skillDetailService.Add(skillDetail);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SkillId"] = new SelectList(await _skillService.GetAll(), "Id", "Title", skillDetail.SkillId);
            return View(skillDetail);
        }

        // GET: SkillDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillDetail = await _skillDetailService.GetItemById(id.Value);
            if (skillDetail == null)
            {
                return NotFound();
            }
            ViewData["SkillId"] = new SelectList(await _skillService.GetAll(), "Id", "Title", skillDetail.SkillId);
            return View(skillDetail);
        }

        // POST: SkillDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SkillDetail skillDetail)
        {
            if (id != skillDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _skillDetailService.Update(skillDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _skillDetailService.SkillDetailExists(skillDetail.Id))
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
            ViewData["SkillId"] = new SelectList(await _skillService.GetAll(), "Id", "Title", skillDetail.SkillId);
            return View(skillDetail);
        }

        // GET: SkillDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillDetail = await _skillDetailService.GetItemById(id.Value);
            if (skillDetail == null)
            {
                return NotFound();
            }

            return View(skillDetail);
        }

        // POST: SkillDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skillDetail = await _skillDetailService.GetItemById(id);
            await _skillDetailService.Delete(skillDetail);
            return RedirectToAction(nameof(Index));
        }
    }
}
