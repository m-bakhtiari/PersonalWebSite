using System;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Context;
using PersonalCV.Core.Entities;
using PersonalCV.Core.Enums;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
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
            if (siteInfo.Key == GeneralEnums.GeneralEnum.AboutMyPhoto || siteInfo.Key == GeneralEnums.GeneralEnum.HeaderMyPhoto ||
                siteInfo.Key == GeneralEnums.GeneralEnum.SidebarMyPhoto)
            {
                siteInfo.Value = GenerateUniqCode() + Path.GetExtension(image.FileName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/img/profile", siteInfo.Value);
                await using var stream = new FileStream(imagePath, FileMode.Create);
                await image.CopyToAsync(stream);
            }

            await _context.SiteInfos.AddAsync(siteInfo);
            await _context.SaveChangesAsync();
        }

        public async Task Update(SiteInfo siteInfo, [AllowNull] IFormFile image)
        {
            var oldData = await _context.SiteInfos.FirstOrDefaultAsync(x => x.Key == siteInfo.Key);
            if (siteInfo.Key == GeneralEnums.GeneralEnum.AboutMyPhoto || siteInfo.Key == GeneralEnums.GeneralEnum.HeaderMyPhoto ||
                siteInfo.Key == GeneralEnums.GeneralEnum.SidebarMyPhoto)
            {
                var deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/img/profile", oldData.Value);
                if (File.Exists(deleteImagePath))
                {
                    File.Delete(deleteImagePath);
                }

                siteInfo.Value = GenerateUniqCode() + Path.GetExtension(image.FileName);
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/img/profile", siteInfo.Value);
                await using var stream = new FileStream(imagePath, FileMode.Create);
                await image.CopyToAsync(stream);
            }
            _context.SiteInfos.Update(siteInfo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SiteInfo siteInfo)
        {
            if (siteInfo.Key == GeneralEnums.GeneralEnum.AboutMyPhoto || siteInfo.Key == GeneralEnums.GeneralEnum.HeaderMyPhoto ||
                siteInfo.Key == GeneralEnums.GeneralEnum.SidebarMyPhoto)
            {
                var deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/img/profile", siteInfo.Value);
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

        public async Task<bool> IsEnumTypeExist(GeneralEnums.GeneralEnum generalEnum)
        {
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

        public async Task<string> GetTemplateText()
        {
            var template =
                await _context.SiteInfos.FirstOrDefaultAsync(x => x.Key == GeneralEnums.GeneralEnum.TemplateText);
            return template?.Value;
        }

        private string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
