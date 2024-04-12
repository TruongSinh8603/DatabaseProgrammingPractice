using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QuanLy;
using BUS_QuanLy;

namespace GUI_QuanLy
{
    public partial class GUI_SinhVien : Form
    {
        BUS_SinhVien busSV = new BUS_SinhVien();

        public GUI_SinhVien()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text != "" && txtName.Text != "" && txtPhone.Text != "")
            {
                //Tạo DTO
                DTO_SinhVien tv = new DTO_SinhVien(0, txtName.Text, txtPhone.Text, txtEmail.Text);
                //Vì ID tự tăng nên để ID số gì cũng được
                //Thêm
                if(busSV.themSinhVien(tv))
                {
                    MessageBox.Show("Thêm thành công");
                    dgvSV.DataSource = busSV.getSinhVien(); //refresh datagridview
                }
                else
                    MessageBox.Show("Thêm không thành công");
            }
            else
                MessageBox.Show("Xin hãy nhập đầy đủ");
        }

        private void GUI_SinhVien_Load(object sender, EventArgs e)
        {
            dgvSV.DataSource = busSV.getSinhVien(); //lấy SinhVien
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Kiểm tra nếu có chọn table rồi
            if (dgvSV.SelectedRows.Count > 0)
            {
                if (txtEmail.Text != "" && txtName.Text != "" && txtPhone.Text != "")
                {
                    //Lấy Row hiện tại
                    DataGridViewRow row = dgvSV.SelectedRows[0];
                    int ID = Convert.ToInt16(row.Cells[0].Value.ToString());
                    //Tạo DTO
                    DTO_SinhVien tv = new DTO_SinhVien(ID, txtName.Text, txtPhone.Text, txtEmail.Text);
                    //Sửa
                    if (busSV.suaSinhVien(tv))
                    {
                        MessageBox.Show("Sửa Thành Công");
                        dgvSV.DataSource = busSV.getSinhVien();//refesh datagridview
                    }
                    else
                        MessageBox.Show("Sửa không thành công");
                }
                else
                    MessageBox.Show("Xin hãy nhập đầy đủ");
            }
            else
                MessageBox.Show("Hãy chọn thành viên muốn sửa");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //kiểm tra nếu có chọn table rồi
            if (dgvSV.SelectedRows.Count > 0)
            {
                //Lấy Row hiện tại
                DataGridViewRow row = dgvSV.SelectedRows[0];
                int ID = Convert.ToInt16(row.Cells[0].Value.ToString());
                //Xóa
                if (busSV.xoaSinhVien(ID))
                {
                    MessageBox.Show("Xóa thành công");
                    dgvSV.DataSource = busSV.getSinhVien();//refesh datagridview
                }
                else
                    MessageBox.Show("Xóa không thành công");
            }
            else
                MessageBox.Show("Hãy chọn thành viên muốn xóa");
        }
    }
}
