using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Context;
using PersonalCV.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalCV.Core.Services
{
    public class SkillDetailService
    {
        private readonly PersonalCVContext _context;

        public SkillDetailService(PersonalCVContext context)
        {
            _context = context;
        }

        public async Task Add(SkillDetail skillDetail)
        {
            await _context.SkillDetails.AddAsync(skillDetail);
            await _context.SaveChangesAsync();
        }

        public async Task Update(SkillDetail skillDetail)
        {
            var oldData = await _context.SkillDetails.FindAsync(skillDetail.Id);
            _context.Entry(oldData).CurrentValues.SetValues(skillDetail);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SkillDetail skillDetail)
        {
            _context.SkillDetails.Remove(skillDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SkillDetail>> GetAll()
        {
            return await _context.SkillDetails.Include(x => x.Skill).ToListAsync();
        }

        public async Task<SkillDetail> GetItemById(int id)
        {
            return await _context.SkillDetails.FindAsync(id);
        }

        public async Task<bool> SkillDetailExists(int id)
        {
            return await _context.SkillDetails.AnyAsync(e => e.Id == id);
        }
    }
}
