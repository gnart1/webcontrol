using System.ComponentModel.DataAnnotations;

namespace webcontrol.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public ICollection<ItemModel> Items { get; set; }
        public ICollection<SubCategoryModel> SubCategoryModels { get; set; }
    }
}
