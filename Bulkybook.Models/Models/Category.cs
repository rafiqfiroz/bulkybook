using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulkybook.Models.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order Must be 1 to 100!!")]
        public int Displayorder { get; set; }
        public DateTime CreateDatetime { get; set; } = DateTime.Now;
    }
}
