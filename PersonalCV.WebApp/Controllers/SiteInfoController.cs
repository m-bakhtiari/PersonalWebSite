using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Entities;
using PersonalCV.Core.Enums;
using PersonalCV.Core.Extensions;
using PersonalCV.Core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalCV.WebApp.Controllers
{
    public class SiteInfoController : Controller
    {
        private readonly SiteInfoService _siteInfoService;

        public SiteInfoController(SiteInfoService siteInfoService)
        {
            _siteInfoService = siteInfoService;
        }

        // GET: SiteInfo
        public async Task<IActionResult> Index()
        {
            return View(await _siteInfoService.GetAll());
        }

        // GET: SiteInfo/Create
        public IActionResult Create()
        {
            var enumData = from GeneralEnums.GeneralEnum e in Enum.GetValues(typeof(GeneralEnums.GeneralEnum))
                           select new
                           {
                               ID = (int)e,
                               Name = e.GetEnumDescription()
                           };
            ViewBag.EnumList = new SelectList(enumData, "ID", "Name");
            return View();
        }

        // POST: SiteInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SiteInfo siteInfo)
        {
            if (ModelState.IsValid)
            {
                if (await _siteInfoService.IsEnumTypeExist(siteInfo.Key) == false)
                {
                    await _siteInfoService.Add(siteInfo);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(siteInfo);
        }

        // GET: SiteInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteInfo = await _siteInfoService.GetItemById(id.Value);
            if (siteInfo == null)
            {
                return NotFound();
            }
            return View(siteInfo);
        }

        // POST: SiteInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SiteInfo siteInfo)
        {
            if (id != siteInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (await _siteInfoService.IsEnumTypeExist(siteInfo.Key) == false)
                    {
                        await _siteInfoService.Update(siteInfo);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _siteInfoService.SiteInfoExists(siteInfo.Id))
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
            return View(siteInfo);
        }

        // GET: SiteInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteInfo = await _siteInfoService.GetItemById(id.Value);
            if (siteInfo == null)
            {
                return NotFound();
            }

            return View(siteInfo);
        }

        // POST: SiteInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siteInfo = await _siteInfoService.GetItemById(id);
            await _siteInfoService.Delete(siteInfo);
            return RedirectToAction(nameof(Index));
        }
    }
}
