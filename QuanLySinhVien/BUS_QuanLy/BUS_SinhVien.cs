using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_SinhVien
    {
        DAL_SinhVien dalSinhVien = new DAL_SinhVien();
        public DataTable getSinhVien() { return dalSinhVien.getSinhVien(); }
        public bool themSinhVien(DTO_SinhVien sv) { return dalSinhVien.themSinhVien(sv); }
        public bool suaSinhVien(DTO_SinhVien sv) { return dalSinhVien.suaSinhVien(sv); }
        public bool xoaSinhVien(int SV_ID) { return dalSinhVien.xoaSinhVien(SV_ID); }
    }
}
