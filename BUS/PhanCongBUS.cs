using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class PhanCongBUS
    {
        private static List<PhanCongDTO> phanCongList = new List<PhanCongDTO>();

        public List<PhanCongDTO> GetAll()
        {
            return phanCongList;
        }

        public bool Add(PhanCongDTO pc)
        {
            phanCongList.Add(pc);
            return true;
        }

        public bool Update(PhanCongDTO pc)
        {
            var existing = phanCongList.Find(x => x.Lop == pc.Lop && x.Mon == pc.Mon);
            if (existing != null)
            {
                existing.GiaoVien = pc.GiaoVien;
                return true;
            }
            return false;
        }

        public bool Delete(string lop, string mon)
        {
            var existing = phanCongList.Find(x => x.Lop == lop && x.Mon == mon);
            if (existing != null)
            {
                phanCongList.Remove(existing);
                return true;
            }
            return false;
        }
    }
}
