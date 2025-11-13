using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class PhieuThuBUS
    {
        private static List<PhieuThuDTO> listPhieuThu = new List<PhieuThuDTO>();

        public List<PhieuThuDTO> GetAll()
        {
            return listPhieuThu;
        }

        public bool Add(PhieuThuDTO pt)
        {
            listPhieuThu.Add(pt);
            return true;
        }

        public bool Update(PhieuThuDTO pt)
        {
            var existing = listPhieuThu.FirstOrDefault(x => x.Id == pt.Id);
            if (existing != null)
            {
                existing.MaKhoanThu = pt.MaKhoanThu;
                existing.TenKhoanThu = pt.TenKhoanThu;
                existing.SoTien = pt.SoTien;
                existing.NamHoc = pt.NamHoc;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var existing = listPhieuThu.FirstOrDefault(x => x.Id == id);
            if (existing != null)
            {
                listPhieuThu.Remove(existing);
                return true;
            }
            return false;
        }
    }
}
