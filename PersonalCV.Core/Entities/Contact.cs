using System.ComponentModel.DataAnnotations;

namespace PersonalCV.Core.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(1500)]
        public string Name { get; set; }

        [MaxLength(1500)]
        public string Email { get; set; }

        [MaxLength(4500)]
        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
