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
        [Required, StringLength(50), Display(Name ="Tên sản phẩm")]
        public string Name { get; set; }
        [Required, Display(Name ="Giá")]
        public decimal Price { get; set; }
        [Display(Name ="Màu")]
        public string Color { get; set; }
        [Display(Name ="Nhà sản xuất")]
        public string Producer { get; set; }
        [Required, Display(Name = "Danh mục")]
        public virtual Category CategoryID { get; set; }
    }
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}