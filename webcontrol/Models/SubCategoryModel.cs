using System.ComponentModel.DataAnnotations;
using webcontrol.Migrations;

namespace webcontrol.Models
{
    public class SubCategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int CategoryId { get; set; }

        public CategoryModel Category { get; set; }
        public ICollection<ItemModel> Items { get; set; }
        
    }
}
