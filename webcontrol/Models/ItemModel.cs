using System.ComponentModel.DataAnnotations;

namespace webcontrol.Models
{
    public class ItemModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        //public int SubCategoryId { get; set; }
        //public SubCategoryModel SubCategory { get; set; }
    }
}
