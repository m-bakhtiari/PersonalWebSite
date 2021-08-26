using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Context;
using PersonalCV.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalCV.Core.Services
{
    public class TemplateService
    {
        private readonly PersonalCVContext _context;

        public TemplateService(PersonalCVContext context)
        {
            _context = context;
        }

        public async Task Add(Template template, [AllowNull] IFormFile image)
        {
            template.MainImage = GenerateUniqCode() + Path.GetExtension(image.FileName);
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/template", template.MainImage);
            await using var stream = new FileStream(imagePath, FileMode.Create);
            await image.CopyToAsync(stream);

            await _context.Templates.AddAsync(template);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Template template, [AllowNull] IFormFile image)
        {
            var oldData = await _context.Templates.FindAsync(template.Id);
            if (image != null)
            {
                var deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/template", oldData.MainImage);
                if (File.Exists(deleteImagePath))
                {
                    File.Delete(deleteImagePath);
                }
                template.MainImage = GenerateUniqCode() + Path.GetExtension(image.FileName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/template", template.MainImage);
                await using var stream = new FileStream(imagePath, FileMode.Create);
                await image.CopyToAsync(stream);
            }
            _context.Entry(oldData).CurrentValues.SetValues(template);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Template template)
        {
            var deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/template", template.MainImage);
            if (File.Exists(deleteImagePath))
            {
                File.Delete(deleteImagePath);
            }
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

        private string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        public async Task<Tuple<List<Template>, int>> GetAllByPaging(int? groupId, int pageId = 1)
        {
            IQueryable<Template> templates = _context.Templates;
            if (groupId.HasValue)
            {
                templates = templates.Where(x => x.GroupId == groupId);
            }

            var countAll = await templates.CountAsync();
            var skip = (pageId - 1) * 9;
            var groupsItem = await templates.Skip(skip).Take(9).ToListAsync();

            return Tuple.Create(groupsItem, countAll);
        }
    }
}
