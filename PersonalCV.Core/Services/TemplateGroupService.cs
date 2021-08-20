using System;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Context;
using PersonalCV.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalCV.Core.Services
{
    public class TemplateGroupService
    {
        private readonly PersonalCVContext _context;

        public TemplateGroupService(PersonalCVContext context)
        {
            _context = context;
        }

        public async Task<List<TemplateGroup>> GetAll()
        {
            return await _context.TemplateGroups.ToListAsync();
        }

        public async Task CreateGroup(TemplateGroup templateGroup)
        {
            await _context.TemplateGroups.AddAsync(templateGroup);
            await _context.SaveChangesAsync();
        }

        public async Task<TemplateGroup> GetGroupById(int groupId)
        {
            return await _context.TemplateGroups.FindAsync(groupId);
        }

        public async Task UpdateGroup(TemplateGroup templateGroup)
        {
            var oldData = await _context.TemplateGroups.FindAsync(templateGroup.Id);
            _context.Entry(oldData).CurrentValues.SetValues(templateGroup);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> TemplateGroupExists(int groupId)
        {
            return await _context.TemplateGroups.AnyAsync(e => e.Id == groupId);
        }

        public async Task DeleteGroup(TemplateGroup templateGroup)
        {
            _context.TemplateGroups.Remove(templateGroup);
            await _context.SaveChangesAsync();
        }
    }
}
