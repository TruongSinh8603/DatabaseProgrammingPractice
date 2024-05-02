using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaleManager.Models
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}