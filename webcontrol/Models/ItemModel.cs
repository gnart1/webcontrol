using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace webcontrol.Models
{
    public class ItemModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategoryModel SubCategory { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        
    }
}
