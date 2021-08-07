using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Context;
using PersonalCV.Core.Entities;
using PersonalCV.Core.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            _context.SiteInfos.Update(siteInfo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SiteInfo siteInfo)
        {
            _context.SiteInfos.Remove(siteInfo);
            await _context.SaveChangesAsync();
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
