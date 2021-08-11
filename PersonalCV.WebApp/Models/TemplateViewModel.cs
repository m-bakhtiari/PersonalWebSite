using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalCV.Core.Entities;

namespace PersonalCV.WebApp.Models
{
    public class TemplateViewModel
    {
        public string TemplateText { get; set; }
        public int? PageId { get; set; } = 1;
        public int PageCount { get; set; }
        public List<TemplateGroup> TemplateGroups { get; set; }
    }
}
