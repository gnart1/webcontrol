using System.ComponentModel.DataAnnotations;
using webcontrol.Models;

namespace webcontrol.Areas.Admin.Models
{
    public class SubCategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
    }
}
