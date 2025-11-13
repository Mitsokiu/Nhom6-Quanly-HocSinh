using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class ThangDiemBUS
    {
        private static List<ThangDiemDTO> listThangDiem = new List<ThangDiemDTO>();

        public List<ThangDiemDTO> GetAll()
        {
            return listThangDiem;
        }

        public bool Add(ThangDiemDTO td)
        {
            listThangDiem.Add(td);
            return true;
        }

        public bool Update(ThangDiemDTO td)
        {
            var existing = listThangDiem.FirstOrDefault(x => x.Id == td.Id);
            if (existing != null)
            {
                existing.LoaiThangDiem = td.LoaiThangDiem;
                existing.DiemMieng = td.DiemMieng;
                existing.Diem15P = td.Diem15P;
                existing.Diem1Tiet = td.Diem1Tiet;
                existing.HocKi = td.HocKi;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var existing = listThangDiem.FirstOrDefault(x => x.Id == id);
            if (existing != null)
            {
                listThangDiem.Remove(existing);
                return true;
            }
            return false;
        }
    }
}
