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
    public class HostPlansController : Controller
    {
        private readonly HostPlanService _hostPlanService;

        public HostPlansController(HostPlanService hostPlanService)
        {
            _hostPlanService = hostPlanService;
        }

        // GET: HostPlans
        public async Task<IActionResult> Index()
        {
            return View(await _hostPlanService.GetAll());
        }

        // GET: HostPlans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HostPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HostPlan hostPlan)
        {
            if (ModelState.IsValid)
            {
                await _hostPlanService.CreateHostPlan(hostPlan);
                return RedirectToAction(nameof(Index));
            }
            return View(hostPlan);
        }

        // GET: HostPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostPlan = await _hostPlanService.GetHostPlanById(id.Value);
            if (hostPlan == null)
            {
                return NotFound();
            }
            return View(hostPlan);
        }

        // POST: HostPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HostPlan hostPlan)
        {
            if (id != hostPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _hostPlanService.UpdateHostPlan(hostPlan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _hostPlanService.HostPlanExists(hostPlan.Id))
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
            return View(hostPlan);
        }

        // GET: HostPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostPlan = await _hostPlanService.GetHostPlanById(id.Value);
            if (hostPlan == null)
            {
                return NotFound();
            }

            return View(hostPlan);
        }

        // POST: HostPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hostPlan = await _hostPlanService.GetHostPlanById(id);
            await _hostPlanService.DeleteHostPlan(hostPlan);
            return RedirectToAction(nameof(Index));
        }
    }
}
