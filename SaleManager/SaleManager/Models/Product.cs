using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SaleManager.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50), Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Required, Display(Name = "Giá")]
        public decimal Price { get; set; }
        [Required, Display(Name = "Danh mục")]
        public virtual Category CategoryID { get; set; }

    }
}