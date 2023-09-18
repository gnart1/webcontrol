using System.ComponentModel.DataAnnotations;

namespace webcontrol.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderHeaderId { get; set; }
        public OrderHeader OrderHeader { get; set; }
        public int ItemId { get; set; }
        public ItemModel Item { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
