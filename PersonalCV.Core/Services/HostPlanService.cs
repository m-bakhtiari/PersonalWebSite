using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Context;
using PersonalCV.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalCV.Core.Services
{
    public class HostPlanService
    {
        private readonly PersonalCVContext _context;

        public HostPlanService(PersonalCVContext context)
        {
            _context = context;
        }

        public async Task<List<HostPlan>> GetAll()
        {
            return await _context.HostPlans.ToListAsync();
        }

        public async Task CreateHostPlan(HostPlan hostPlan)
        {
            await _context.HostPlans.AddAsync(hostPlan);
            await _context.SaveChangesAsync();
        }

        public async Task<HostPlan> GetHostPlanById(int hostPlanId)
        {
            return await _context.HostPlans.FindAsync(hostPlanId);
        }

        public async Task UpdateHostPlan(HostPlan hostPlan)
        {
            var oldData = await _context.HostPlans.FindAsync(hostPlan.Id);
            _context.Entry(oldData).CurrentValues.SetValues(hostPlan);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HostPlanExists(int hostPlanId)
        {
            return await _context.TemplateGroups.AnyAsync(e => e.Id == hostPlanId);
        }

        public async Task DeleteHostPlan(HostPlan hostPlanId)
        {
            _context.HostPlans.Remove(hostPlanId);
            await _context.SaveChangesAsync();
        }
    }
}
