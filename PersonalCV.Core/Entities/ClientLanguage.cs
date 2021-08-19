using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCV.Core.Entities
{
    public class ClientLanguage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string ClientIP { get; set; }
        public bool IsEnglish { get; set; }
    }
}
