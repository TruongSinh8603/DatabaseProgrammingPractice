using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SaleManager.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50), Display(Name = "Tên danh mục")]
        public string Name { get; set; }
        [Display(Name = "Mô tả chi tiết")]
        public string Description { get; set; }
    }
}