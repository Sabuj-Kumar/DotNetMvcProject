

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcFirstProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Property")]
        [Range(1,200,ErrorMessage ="value must be between 1 to 200")]
        public int DisplayProperty { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
