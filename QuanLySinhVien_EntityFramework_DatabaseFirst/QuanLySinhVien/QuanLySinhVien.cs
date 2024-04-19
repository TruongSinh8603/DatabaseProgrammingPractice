using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class QuanLySinhVien : Form
    {
        QLSVEntities context = new QLSVEntities();

        public QuanLySinhVien()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtPhone.Text != "" && txtEmail.Text != "")
            {
                if (txtName.Text.Length > 30)
                {
                    MessageBox.Show("Tên tối đa 30 ký tự");
                    return;
                }
                if (txtPhone.Text.Length > 11)
                {
                    MessageBox.Show("Số điện thoại tối đa 11 ký tự");
                    return;
                }
                if (txtEmail.Text.Length > 30)
                {
                    MessageBox.Show("Email tối đa 30 ký tự");
                    return;
                }
                SinhVien sv = new SinhVien();
                sv.SV_Name = txtName.Text;
                sv.SV_Email = txtEmail.Text;
                sv.SV_Phone = txtPhone.Text;
                //Lưu thông tin sinh viên mới vào buffer
                context.SinhVien.Add(sv);
                //Lưu thông tin sinh viên xuống database
                context.SaveChanges();

                MessageBox.Show("Thêm thành công");
                //Làm mới data grid view
                dgvSV.DataSource = context.SinhVien.ToList();
                dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
                MessageBox.Show("Hãy nhập đủ thông tin");
        }

        private void QuanLySinhVien_Load(object sender, EventArgs e)
        {
            //lấy danh sách sinh viên
            dgvSV.DataSource = context.SinhVien.ToList();
            dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvSV_Click(object sender, EventArgs e)
        {
            //Lấy row hiện tại
            DataGridViewRow row = dgvSV.SelectedRows[0];
            //Chuyển giá trị lên form
            txtName.Text = row.Cells[1].Value.ToString();
            txtPhone.Text = row.Cells[2].Value.ToString();
            txtEmail.Text = row.Cells[3].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Kiểm tra nếu có chọn table rồi
            if (dgvSV.SelectedRows.Count > 0)
            {
                if (txtEmail.Text != "" && txtName.Text != "" && txtPhone.Text != "")
                {
                    //Lấy Row hiện tại
                    SinhVien sv = dgvSV.SelectedRows[0].DataBoundItem as SinhVien;
                    sv.SV_Name = txtName.Text;
                    sv.SV_Phone = txtPhone.Text;
                    sv.SV_Email = txtEmail.Text;
                    context.SaveChanges();
                    MessageBox.Show("Sửa Thành Công");
                    //Làm mới data grid view
                    dgvSV.DataSource = context.SinhVien.ToList();
                    dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                    MessageBox.Show("Xin hãy nhập đầy đủ");
            }
            else
                MessageBox.Show("Hãy chọn thành viên muốn sửa");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSV.SelectedRows.Count > 0)
            {
                //Lấy Row hiện tại
                SinhVien sv = dgvSV.SelectedRows[0].DataBoundItem as SinhVien;
                context.SinhVien.Remove(sv);
                context.SaveChanges();
                MessageBox.Show("Xoá Thành Công");
                //Làm mới data grid view
                dgvSV.DataSource = context.SinhVien.ToList();
                dgvSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
                MessageBox.Show("Hãy chọn thành viên muốn sửa");
        }
    }
}
