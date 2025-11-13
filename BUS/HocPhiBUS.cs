using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class HocPhiBUS
    {
        private static List<HocPhiDTO> listHocPhi = new List<HocPhiDTO>();

        public List<HocPhiDTO> GetAll()
        {
            return listHocPhi;
        }

        public bool Add(HocPhiDTO hp)
        {
            listHocPhi.Add(hp);
            return true;
        }

        public bool Update(HocPhiDTO hp)
        {
            var existing = listHocPhi.FirstOrDefault(x => x.Id == hp.Id);
            if (existing != null)
            {
                existing.HoTen = hp.HoTen;
                existing.NgaySinh = hp.NgaySinh;
                existing.Lop = hp.Lop;
                existing.KhoanThu = hp.KhoanThu;
                existing.SoTien = hp.SoTien;
                existing.TrangThai = hp.TrangThai;
                existing.NgayDong = hp.NgayDong;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var existing = listHocPhi.FirstOrDefault(x => x.Id == id);
            if (existing != null)
            {
                listHocPhi.Remove(existing);
                return true;
            }
            return false;
        }
    }
}
