using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalCV.Core.Entities
{
    public class Template
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(1600)]
        [Required]
        public string Title { get; set; }

        [MaxLength(3600)]
        public string SiteUrlForPreview { get; set; }

        [MaxLength(3600)]
        [Required]
        public string MainSiteUrl { get; set; }

        [MaxLength(5000)]
        public string Description { get; set; }

        public int Price { get; set; }

        [MaxLength(800)]
        public string MainImage { get; set; }

        public int GroupId { get; set; }

        [ForeignKey(nameof(GroupId))]
        public TemplateGroup TemplateGroup { get; set; }
    }
}
