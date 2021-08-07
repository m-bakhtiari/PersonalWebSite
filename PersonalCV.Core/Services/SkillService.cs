using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Context;
using PersonalCV.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalCV.Core.Services
{
    public class SkillService
    {
        private readonly PersonalCVContext _context;

        public SkillService(PersonalCVContext context)
        {
            _context = context;
        }

        public async Task Add(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Skill skill)
        {
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Skill skill)
        {
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Skill>> GetAll()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<Skill> GetItemById(int id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task<bool> SkillExists(int id)
        {
            return await _context.Skills.AnyAsync(e => e.Id == id);
        }
    }
}
