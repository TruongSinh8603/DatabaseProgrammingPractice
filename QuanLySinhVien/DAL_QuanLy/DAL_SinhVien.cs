using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_SinhVien : DBConnect
    {
        //Lay toan bo SinhVien
        public DataTable getSinhVien()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SINHVIEN", _conn);
            DataTable dtSinhVien = new DataTable();
            da.Fill(dtSinhVien);
            return dtSinhVien;
        }
        //Them SinhVien
        public bool themSinhVien(DTO_SinhVien sv)
        {
            try
            {
                //Ket noi
                _conn.Open();
                //Query String
                //SV_ID la identity (gia tri tu tang) nen can insert ID
                string SQL = string.Format(
                    "INSERT INTO SINHVIEN(SV_NAME, SV_PHONE, SV_EMAIL) VALUES(N'{0}','{1}','{2}')", 
                    sv.SINHVIEN_NAME, sv.SINHVIEN_PHONE, sv.SINHVIEN_EMAIL
                    );
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                //Query va Kiem tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e) { }
            finally
            {
                //Dong Ket noi
                _conn.Close();
            }
            return false;
        }
        //Sua SinhVien
        public bool suaSinhVien(DTO_SinhVien sv)
        {
            try
            {
                //Ket noi
                _conn.Open();
                //Query String
                string SQL = string.Format(
                    "UPDATE SINHVIEN SET SV_NAME = N'{0}', SV_PHONE='{1}', SV_EMAIL = '{2}' WHERE SV_ID = {3}",
                    sv.SINHVIEN_NAME, sv.SINHVIEN_PHONE, sv.SINHVIEN_EMAIL, sv.SINHVIEN_ID
                    );
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                //Query va Kiem tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e) { }
            finally
            {
                //Dong ket noi
                _conn.Close();
            }
            return false;
        }
        //Xoa SinhVien
        public bool xoaSinhVien(int SV_ID)
        {
            try
            {
                //Ket noi
                _conn.Open();
                //Query String
                string SQL = string.Format(
                    "DELETE FROM SINHVIEN WHERE SV_ID={0}",
                    SV_ID
                   );
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                //Query va Kiem tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e) { }
            finally
            {
                //Dong ket noi
                _conn.Close();
            }
            return false;
        }
    }
}
