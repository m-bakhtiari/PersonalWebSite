using PersonalCV.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalCV.Core.Entities
{
    public class SiteInfo
    {
        [Key]
        public int Id { get; set; }

        public GeneralEnums.GeneralEnum Key { get; set; }

        public string Value { get; set; }

        public string PersianValue { get; set; }

    }
}
