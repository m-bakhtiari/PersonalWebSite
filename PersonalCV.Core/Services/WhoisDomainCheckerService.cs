using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PersonalCV.Core.Context;
using PersonalCV.Core.Enums;

namespace PersonalCV.Core.Services
{
    public class WhoisDomainCheckerService
    {
        private readonly PersonalCVContext _context;

        public WhoisDomainCheckerService(PersonalCVContext context)
        {
            _context = context;
        }
        public async Task<string> CheckDomain(string domain)
        {
            var res = "";
            var apiKeys = await _context.SiteInfos.Where(x => x.Key == GeneralEnums.GeneralEnum.ApiKey).ToListAsync();
            var random = new Random();
            int index = random.Next(apiKeys.Count);
            var key = apiKeys[index].Value;
            var apiName = $"https://www.whoisxmlapi.com/whoisserver/WhoisService?apiKey={key}&domainName={domain}";

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiName))
                {
                     res = await response.Content.ReadAsStringAsync();
                }
            }

            if (res.Contains("<expiresDate>"))
            {
                return "false";
            }
            else if (res.Contains("<parseCode>0</parseCode>"))
            {
                return "true";
            }
            else
            {
                return "error";
            }
        }

    }

}