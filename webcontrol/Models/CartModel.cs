using System.ComponentModel.DataAnnotations;

namespace webcontrol.Models
{
    public class CartModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ItemId { get; set; }
        public ItemModel Item { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Required, MinLength(1)]
        public int Count { get; set; }
    }
}
