using System.ComponentModel.DataAnnotations;

namespace webcontrol.Models
{
    public class CouponModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Type { get; set; }
        public double Discount { get; set; }
        public double MinimumAmount { get; set; }
        public byte[] CouponPicture { get; set; }
        public bool IsActive { get; set; }

    }
    public enum CouponType
    {
        Percent=0, Percents=1,
    }
}
