using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Context;
using PersonalCV.Core.Entities;

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
            _context.SkillDetails.Update(skillDetail);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SkillDetail skillDetail)
        {
            _context.SkillDetails.Remove(skillDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SkillDetail>> GetAll()
        {
            return await _context.SkillDetails.ToListAsync();
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
