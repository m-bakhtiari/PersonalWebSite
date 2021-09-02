using System;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Context;
using PersonalCV.Core.Entities;
using PersonalCV.Core.Enums;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PersonalCV.Core.Services
{
    public class SiteInfoService
    {
        private readonly PersonalCVContext _context;

        public SiteInfoService(PersonalCVContext context)
        {
            _context = context;
        }

        public async Task Add(SiteInfo siteInfo, [AllowNull] IFormFile image)
        {
            if (siteInfo.Key == GeneralEnums.GeneralEnum.ProfilePhoto || siteInfo.Key == GeneralEnums.GeneralEnum.HeaderMyPhoto)
            {
                siteInfo.Value = GenerateUniqCode() + Path.GetExtension(image.FileName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/profile", siteInfo.Value);
                await using var stream = new FileStream(imagePath, FileMode.Create);
                await image.CopyToAsync(stream);
            }

            await _context.SiteInfos.AddAsync(siteInfo);
            await _context.SaveChangesAsync();
        }

        public async Task Update(SiteInfo siteInfo, [AllowNull] IFormFile image)
        {
            var oldData = await _context.SiteInfos.FirstOrDefaultAsync(x => x.Key == siteInfo.Key);
            if (siteInfo.Key == GeneralEnums.GeneralEnum.ProfilePhoto || siteInfo.Key == GeneralEnums.GeneralEnum.HeaderMyPhoto)
            {
                var deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/profile", oldData.Value);
                if (File.Exists(deleteImagePath))
                {
                    File.Delete(deleteImagePath);
                }

                siteInfo.Value = GenerateUniqCode() + Path.GetExtension(image.FileName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/profile", siteInfo.Value);
                await using var stream = new FileStream(imagePath, FileMode.Create);
                await image.CopyToAsync(stream);
            }
            _context.Entry(oldData).CurrentValues.SetValues(siteInfo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SiteInfo siteInfo)
        {
            if (siteInfo.Key == GeneralEnums.GeneralEnum.ProfilePhoto || siteInfo.Key == GeneralEnums.GeneralEnum.HeaderMyPhoto)
            {
                var deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/profile", siteInfo.Value);
                if (File.Exists(deleteImagePath))
                {
                    File.Delete(deleteImagePath);
                }
            }
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

        public async Task<bool> IsEnumTypeExist(int? id, GeneralEnums.GeneralEnum generalEnum)
        {
            if (id.HasValue)
            {
                return await _context.SiteInfos.AnyAsync(x => x.Key == generalEnum && x.Id != id);
            }
            return await _context.SiteInfos.AnyAsync(x => x.Key == generalEnum);
        }

        public async Task<bool> IsUsernameExist(string username, string password)
        {
            var info = await _context.SiteInfos.FirstOrDefaultAsync(x => x.Key == GeneralEnums.GeneralEnum.Username);
            var model = await _context.SiteInfos.FirstOrDefaultAsync(x => x.Key == GeneralEnums.GeneralEnum.Password);
            if (username == info.Value && password == model.Value)
            {
                return true;
            }

            return false;
        }


        public async Task<List<SiteInfo>> GetInfoForErrorPage()
        {
            return await _context.SiteInfos.Where(x => x.Key == GeneralEnums.GeneralEnum.WhatsappUrl ||
                                                 x.Key == GeneralEnums.GeneralEnum.InstagramUrl || x.Key == GeneralEnums.GeneralEnum.TelegramUrl ||
               x.Key == GeneralEnums.GeneralEnum.LinkedIn || x.Key == GeneralEnums.GeneralEnum.InstagramUrl).ToListAsync();
        }

        public async Task<string> GetCvLink()
        {
            var link = await _context.SiteInfos.FirstOrDefaultAsync(x => x.Key == GeneralEnums.GeneralEnum.CvFileForDownload);
            return link.Value;
        }

        public async Task<List<SiteInfo>> GetLayoutInfo()
        {
            return await _context.SiteInfos.Where(x => x.Key == GeneralEnums.GeneralEnum.WhatsappUrl ||
                                                       x.Key == GeneralEnums.GeneralEnum.InstagramUrl || x.Key == GeneralEnums.GeneralEnum.TelegramUrl ||
                                                       x.Key == GeneralEnums.GeneralEnum.LinkedIn || x.Key == GeneralEnums.GeneralEnum.InstagramUrl).ToListAsync();
        }

        private string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
