using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalCV.Core.Entities
{
    public class HostPlan
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(500)]
        [Required]
        public string Title { get; set; }

        [MaxLength(500)]
        [Required]
        public string CompanyName { get; set; }

        public string Description { get; set; }
    }
}
