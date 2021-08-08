using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalCV.Core.Entities
{
    public class SkillDetail
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(800)]
        [Required]
        public string Title { get; set; }

        public int Percent { get; set; }

        public int SkillId { get; set; }

        [ForeignKey(nameof(SkillId))]
        public Skill Skill { get; set; }
    }
}
