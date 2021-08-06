using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalCV.Core.Entities
{
    public class TemplateGroup
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(800)]
        public string Title { get; set; }

        public ICollection<Template> Templates { get; set; }
    }
}
