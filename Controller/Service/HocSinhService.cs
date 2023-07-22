using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuTor_cho_nguoi_than.Controller.Respository;
using TuTor_cho_nguoi_than.DomainClass;

namespace TuTor_cho_nguoi_than.Controller.Service
{
    internal class HocSinhService
    {
        SinhVienRespository _res;
        public HocSinhService()
        {
            _res = new SinhVienRespository();
        }
        public List<Lop> GetLops()
        {
            return _res.GetLops();
        }
        public List<HocSinh> GetHocSinhs(string find)
        {
            return _res.GetHocSinhs(find);
        }
        public void AddHocSinh(HocSinh student)
        {
            if (_res.AddHocSinh(student))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
    }
}
