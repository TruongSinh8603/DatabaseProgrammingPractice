using SaleManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaleManager.Controllers
{
    public class NguoidungController : Controller
    {
        private readonly ApplicationDbContext context;
        // GET: Nguoidung
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Dangky(FormCollection collection, KhachHang kh)
        {
            var hoTen = collection["HotenKH"];
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            var matkhaunhaplai = collection["Matkhaunhaplai"];
            var diachi = collection["Diachi"];
            var email = collection["Email"];
            var dienthoai = collection["Dienthoai"];
            var ngsysinh = String.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);
            if (String.IsNullOrEmpty(hoTen))
            {
                ViewData["Loi1"] = "Họ Tên khách hàng không được để trống";
            }
            else if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Phải nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi4"] = "Phải nhập lại mật khẩu";
            }
            else if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = "Email không được bỏ trống";
            }
            else if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi6"] = "Phải nhập điện thoại";
            }
            else
            {
                kh.HoTen = hoTen;
                kh.TaiKhoan = tendn;
                kh.MatKhau = matkhau;
                kh.Email = email;
                kh.DiachiKH = diachi;
                kh.DienthoaiKH = dienthoai;
                kh.Ngaysinh = DateTime.Parse(ngsysinh);
                context.KhachHangs.Add(kh);
                context.SaveChangesAsync();
                return RedirectToAction("Dangnhap");
            }
            return View();
        }

        // POST: Nguoidung/Dangnhap
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dangnhap(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                var khachHangDb = context.KhachHangs.FirstOrDefault(kh => kh.TaiKhoan == khachHang.TaiKhoan && kh.MatKhau == khachHang.MatKhau);
                if (khachHangDb != null)
                {
                    // Đăng nhập thành công, thực hiện các hành động cần thiết, ví dụ: lưu thông tin đăng nhập vào session
                    Session["UserID"] = khachHangDb.MaKH;
                    return RedirectToAction("Index", "Home"); // Chuyển hướng đến trang chính sau khi đăng nhập thành công
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng.");
                }
            }
            return View(khachHang);
        }
    }
}