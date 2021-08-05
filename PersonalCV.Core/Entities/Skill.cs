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

        [Required]
        [MaxLength(500)]
        public string SkillDetailTitle { get; set; }

        public int Percent { get; set; }
    }
}
