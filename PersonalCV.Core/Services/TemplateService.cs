using System;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Context;
using PersonalCV.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PersonalCV.Core.Services
{
    public class TemplateService
    {
        private readonly PersonalCVContext _context;

        public TemplateService(PersonalCVContext context)
        {
            _context = context;
        }

        public async Task Add(Template template)
        {
            await _context.Templates.AddAsync(template);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Template template)
        {
            _context.Templates.Update(template);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Template template)
        {
            _context.Templates.Remove(template);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Template>> GetAll()
        {
            return await _context.Templates.Include(x => x.TemplateGroup).ToListAsync();
        }

        public async Task<Template> GetItemById(int id)
        {
            return await _context.Templates.Include(x => x.TemplateGroup).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> TemplateExists(int id)
        {
            return await _context.Templates.AnyAsync(e => e.Id == id);
        }
    }
}
