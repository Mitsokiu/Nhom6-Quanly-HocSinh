using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class HocKiBUS
    {
        private static List<HocKiDTO> listHocKi = new List<HocKiDTO>();

        public List<HocKiDTO> GetAll()
        {
            return listHocKi;
        }

        public bool Add(HocKiDTO hk)
        {
            listHocKi.Add(hk);
            return true;
        }

        public bool Update(HocKiDTO hk)
        {
            var existing = listHocKi.FirstOrDefault(x => x.Id == hk.Id);
            if (existing != null)
            {
                existing.NamHoc = hk.NamHoc;
                existing.HocKi = hk.HocKi;
                existing.NgayBatDau = hk.NgayBatDau;
                existing.NgayKetThuc = hk.NgayKetThuc;
                existing.TrangThai = hk.TrangThai;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var existing = listHocKi.FirstOrDefault(x => x.Id == id);
            if (existing != null)
            {
                listHocKi.Remove(existing);
                return true;
            }
            return false;
        }
    }
}
