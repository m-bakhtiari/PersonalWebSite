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
            _context.TemplateGroups.Update(templateGroup);
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

        public async Task<Tuple<List<TemplateGroup>, int>> GetAllByPaging(int? groupId, int pageId = 1)
        {
            IQueryable<TemplateGroup> groups = _context.TemplateGroups.Include(x => x.Templates);
            if (groupId.HasValue)
            {
                groups = groups.Where(x => x.Id == groupId);
            }

            var countAll = await groups.CountAsync();
            var skip = (pageId - 1) * 9;
            var groupsItem = await groups.Skip(skip).Take(9).ToListAsync();

            return Tuple.Create(groupsItem, countAll);
        }
    }
}
