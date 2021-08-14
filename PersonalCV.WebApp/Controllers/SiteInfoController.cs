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
using Microsoft.AspNetCore.Authorization;
using PersonalCV.WebApp.Models;

namespace PersonalCV.WebApp.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Create(SiteInfoViewModel siteInfo)
        {
            if (ModelState.IsValid)
            {
                if (await _siteInfoService.IsEnumTypeExist(siteInfo.Key) == false)
                {
                    var model = new SiteInfo()
                    {
                        Id = siteInfo.Id,
                        Value = siteInfo.Value,
                        Key = siteInfo.Key
                    };
                    await _siteInfoService.Add(model, siteInfo.Image);
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
            var enumData = from GeneralEnums.GeneralEnum e in Enum.GetValues(typeof(GeneralEnums.GeneralEnum))
                select new
                {
                    ID = (int)e,
                    Name = e.GetEnumDescription()
                };
            ViewBag.EnumList = new SelectList(enumData, "ID", "Name");
            var model = new SiteInfoViewModel()
            {
                Value = siteInfo.Value,
                Key = siteInfo.Key,
                Id = siteInfo.Id,
            };
            return View(model);
        }

        // POST: SiteInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SiteInfoViewModel siteInfoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (await _siteInfoService.IsEnumTypeExist(siteInfoViewModel.Key) == false)
                    {
                        var model = new SiteInfo()
                        { Id = siteInfoViewModel.Id, Key = siteInfoViewModel.Key, Value = siteInfoViewModel.Value };
                        await _siteInfoService.Update(model, siteInfoViewModel.Image);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _siteInfoService.SiteInfoExists(siteInfoViewModel.Id))
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
            return View(siteInfoViewModel);
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
