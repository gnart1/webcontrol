﻿using System.Drawing;
using webcontrol.Models;

namespace webcontrol.Areas.Admin.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile ImageUrl { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
