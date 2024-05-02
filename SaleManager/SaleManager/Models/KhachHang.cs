using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SaleManager.Models
{
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }
        [Required, StringLength(50)]
        public string HoTen { get; set; }
        [StringLength(50)]
        public string TaiKhoan { get; set; }
        [Required, StringLength(50)]
        public string MatKhau { get; set;}
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(200)]
        public string DiachiKH { get; set; }
        [StringLength(50)]
        public string DienthoaiKH { get; set; }
        public DateTime Ngaysinh { get; set; }
    }
}