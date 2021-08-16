using PersonalCV.Core.Entities;
using System.Collections.Generic;

namespace PersonalCV.WebApp.Models
{
    public class TemplatePaging
    {
        public string TemplateText { get; set; }
        public int? PageId { get; set; } = 1;
        public int PageCount { get; set; }
        public List<TemplateGroup> TemplateGroups { get; set; }
    }
}
