using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalCV.Core.Entities
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(800)]
        public string Title { get; set; }

        public ICollection<SkillDetail> SkillDetails { get; set; }
    }
}
