using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Context;
using PersonalCV.Core.Entities;
using PersonalCV.Core.Enums;

namespace PersonalCV.Core.Services
{
    public class SiteInfoService
    {
        private readonly PersonalCVContext _context;

        public SiteInfoService(PersonalCVContext context)
        {
            _context = context;
        }

        public async Task Add(SiteInfo siteInfo)
        {
            await _context.SiteInfos.AddAsync(siteInfo);
            await _context.SaveChangesAsync();
        }

        public async Task Update(SiteInfo siteInfo)
        {
            _context.Update(siteInfo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SiteInfo siteInfo)
        {

        }

        public async Task<List<SiteInfo>> GetAll()
        {
            return await _context.SiteInfos.ToListAsync();
        }

        public async Task<SiteInfo> GetItemById(int id)
        {
            return await _context.SiteInfos.FindAsync(id);
        }

        public async Task<bool> SiteInfoExists(int id)
        {
            return await _context.SiteInfos.AnyAsync(e => e.Id == id);
        }

        public async Task<bool> IsEnumTypeExist(GeneralEnums.GeneralEnum generalEnum)
        {
            return await _context.SiteInfos.AnyAsync(x => x.Key == generalEnum);
        }
    }
}
