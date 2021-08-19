using PersonalCV.Core.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalCV.Core.Entities;

namespace PersonalCV.Core.Services
{
    public class ClientLanguageService
    {
        private readonly PersonalCVContext _context;

        public ClientLanguageService(PersonalCVContext context)
        {
            _context = context;
        }

        public async Task Add(string clientIP)
        {
            await _context.ClientLanguages.AddAsync(new ClientLanguage()
            {
                ClientIP = clientIP,
                IsEnglish = false
            });
        }

        public async Task ToggleClientLanguage(string clientIP)
        {
            var item = await _context.ClientLanguages.FirstOrDefaultAsync(x => x.ClientIP == clientIP);
            if (item.IsEnglish == false)
            {
                item.IsEnglish = true;
            }
            else
            {
                item.IsEnglish = false;
            }
        }

        public async Task<bool> IsIPExist(string clientIP)
        {
            return await _context.ClientLanguages.AnyAsync(x => x.ClientIP == clientIP);
        }

        public async Task<bool> IsInEnglish(string clientIP)
        {
            return await _context.ClientLanguages.AnyAsync(x => x.ClientIP == clientIP);
        }
    }
}
