using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalCV.Core.Services
{
    public class WhoisDomainCheckerService
    {
        public async Task<bool> CheckDomain(string domain)
        {
            //TODO Check internet to find api for check api or domain availability or free api whois lookup

            Random rng = new Random();
            bool randomBool = rng.Next(0, 2) > 0;
            return randomBool;
        }
    }
}