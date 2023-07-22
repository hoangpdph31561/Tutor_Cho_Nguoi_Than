using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuTor_cho_nguoi_than.Context;
using TuTor_cho_nguoi_than.DomainClass;

namespace TuTor_cho_nguoi_than.Controller.Respository
{
    internal class SinhVienRespository
    {
        DBContext _db;
        public SinhVienRespository()
        {
            _db = new DBContext();
        }
        public List<Lop> GetLops()
        {
            return _db.Lops.ToList();
        }
        public List<HocSinh>? GetHocSinhs(string find)
        {
            if(find == null)
            {
                return _db.HocSinhs.ToList();
            }
            return _db.HocSinhs.Where(x => x.TenHocSinh.Trim().ToLower().StartsWith(find.Trim().ToLower())).ToList();
        }
        public bool AddHocSinh(HocSinh student)
        {
            if(student == null)
            {
                return false;
            }
            student.IdHocSinh = Guid.NewGuid();
            _db.HocSinhs.Add(student);
            _db.SaveChanges();
            return true;
        }
    }
}
