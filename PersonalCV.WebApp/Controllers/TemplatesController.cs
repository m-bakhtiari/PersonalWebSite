using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Context;
using PersonalCV.Core.Entities;
using PersonalCV.Core.Services;

namespace PersonalCV.WebApp.Controllers
{
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
            ViewData["GroupId"] = new SelectList(await _templateGroupService.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Templates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Template template)
        {
            if (ModelState.IsValid)
            {
                await _templateService.Add(template);
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(await _templateGroupService.GetAll(), "Id", "Id", template.GroupId);
            return View(template);
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
            ViewData["GroupId"] = new SelectList(await _templateGroupService.GetAll(), "Id", "Id", template.GroupId);
            return View(template);
        }

        // POST: Templates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Template template)
        {
            if (id != template.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _templateService.Update(template);
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
            ViewData["GroupId"] = new SelectList(await _templateGroupService.GetAll(), "Id", "Id", template.GroupId);
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
