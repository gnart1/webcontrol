using System.ComponentModel.DataAnnotations;
using webcontrol.Models;

namespace webcontrol.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
