using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuTor_cho_nguoi_than.Controller.Service;
using TuTor_cho_nguoi_than.DomainClass;

namespace TuTor_cho_nguoi_than.View.QuanLySinhVien
{
    public partial class QuanLySinhVien : Form
    {
        HocSinhService _studentService = new HocSinhService();
        Guid _idWhenClick;
        public QuanLySinhVien()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckTextBox())
            {
                HocSinh student = new();
                student.MaHocSinh = txtMaSinhVien.Text;
                student.TenHocSinh = txtHoTen.Text;
                student.Email = txtEmail.Text;
                student.SoDienThoai = txtSoDienThoai.Text;
                if (radNam.Checked)
                {
                    student.GioiTinh = true;
                }
                else
                {
                    student.GioiTinh = false;
                }
                student.DiaChi = txtDiaChi.Text;
                string tenLopDuocChon = cmbLop.SelectedItem.ToString();
                student.IdLop = _studentService.GetLops().Where(x => x.TenLop == tenLopDuocChon).Select(x => x.IdLop).FirstOrDefault();
                _studentService.AddHocSinh(student);
                LoadDatagridView(null);
                ResetTextBox();
            }
        }

        private void QuanLySinhVien_Load(object sender, EventArgs e)
        {
            radNam.Checked = true;
            radNu.Checked = false;
            LoadCombobox();
            LoadDatagridView(null);
        }
        public void LoadCombobox()
        {
            //cmbLop.DataSource = _studentService.GetLops();
            //cmbLop.DisplayMember = "tenLop";
            //cmbLop.ValueMember = "tenLop";
            foreach (var item in _studentService.GetLops())
            {
                cmbLop.Items.Add(item.TenLop);
            }
            cmbLop.SelectedIndex = 0;
        }
        public void LoadDatagridView(string input)
        {
            int soThuTu = 1;
            Type type = typeof(HocSinh);
            dgvSinhVien.ColumnCount = type.GetProperties().Length + 1;
            dgvSinhVien.Columns[0].Name = "STT";
            dgvSinhVien.Columns[1].Name = "Guid";
            dgvSinhVien.Columns[2].Name = "Mã sinh viên";
            dgvSinhVien.Columns[3].Name = "Họ và tên";
            dgvSinhVien.Columns[4].Name = "Email";
            dgvSinhVien.Columns[5].Name = "Số điện thoại";
            dgvSinhVien.Columns[6].Name = "Địa chỉ";
            dgvSinhVien.Columns[7].Name = "Giới tính";
            dgvSinhVien.Columns[8].Name = "Lớp";
            dgvSinhVien.Rows.Clear();
            if (input == null)
            {
                foreach (var item in _studentService.GetHocSinhs(null))
                {
                    dgvSinhVien.Rows.Add(soThuTu++, item.IdHocSinh, item.MaHocSinh, item.TenHocSinh
                        , item.Email, item.SoDienThoai, item.DiaChi,
                        (item.GioiTinh == true ? "Nam" : "Nữ"),
                        _studentService.GetLops().Where(x => x.IdLop == item.IdLop).Select(x => x.TenLop).First());
                }
            }
            else
            {
                foreach (var item in _studentService.GetHocSinhs(input))
                {
                    dgvSinhVien.Rows.Add(soThuTu++, item.IdHocSinh, item.MaHocSinh, item.TenHocSinh
                        , item.Email, item.SoDienThoai, item.DiaChi,
                        (item.GioiTinh == true ? "Nam" : "Nữ"),
                        _studentService.GetLops().Where(x => x.IdLop == item.IdLop).Select(x => x.TenLop).First());
                }
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index == _studentService.GetHocSinhs(null).Count)
            {
                return;
            }
            _idWhenClick = Guid.Parse(dgvSinhVien.Rows[index].Cells[1].Value.ToString());
            HocSinh studentWhenClick = _studentService.GetHocSinhs(null).FirstOrDefault(x => x.IdHocSinh == _idWhenClick);
            txtMaSinhVien.Text = studentWhenClick.MaHocSinh;
            txtHoTen.Text = studentWhenClick.TenHocSinh;
            txtEmail.Text = studentWhenClick.Email;
            txtSoDienThoai.Text = studentWhenClick.SoDienThoai;
            txtDiaChi.Text = studentWhenClick.DiaChi;
            if (studentWhenClick.GioiTinh == true)
            {
                radNam.Checked = true;
                radNu.Checked = false;
            }
            else
            {
                radNam.Checked = false;
                radNu.Checked = true;
            }
            cmbLop.SelectedItem = _studentService.GetLops().Where(x => x.IdLop == studentWhenClick.IdLop).Select(x => x.TenLop).First();
        }

        private void txtTimKiem_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimKiem.Text = "";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == null || txtTimKiem.Text.Length == 0)
            {
                LoadDatagridView(null);
            }
            else
            {
                LoadDatagridView(txtTimKiem.Text);
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            txtTimKiem.Text = "Nhập tên cần tìm ở đây";
            LoadDatagridView(null);
        }
        public bool CheckTextBox()
        {
            err.SetError(txtMaSinhVien, "");
            if(txtMaSinhVien.Text.Length == 0)
            {
                err.SetError(txtMaSinhVien, "Chưa nhập mã sinh viên");
                return false;
            }
            else if(_studentService.GetHocSinhs(null).Any(x => x.MaHocSinh == txtMaSinhVien.Text))
            {
                err.SetError(txtMaSinhVien, "Trùng mã sinh viên");
                return false;
            }
            return true;
        }
        public void ResetTextBox()
        {
            txtMaSinhVien.Text = "";
        }
    }
}
