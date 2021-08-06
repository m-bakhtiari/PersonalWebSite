using System.ComponentModel;
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

        [Display(Name = "فضا")]
        public int Capacity { get; set; }

        [Display(Name = "پهنای باند ماهیانه")]
        public int BandwidthPerMonth { get; set; }

        [Display(Name = "وبسایت اضافی")]
        public int ExtraWebSite { get; set; }
    }
}
