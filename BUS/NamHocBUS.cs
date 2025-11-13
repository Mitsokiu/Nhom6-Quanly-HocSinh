using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class NamHocBUS
    {
        private static List<NamHocDTO> listNamHoc = new List<NamHocDTO>();

        public List<NamHocDTO> GetAll()
        {
            return listNamHoc;
        }

        public bool Add(NamHocDTO nh)
        {
            listNamHoc.Add(nh);
            return true;
        }

        public bool Update(NamHocDTO nh)
        {
            var existing = listNamHoc.FirstOrDefault(x => x.Id == nh.Id);
            if (existing != null)
            {
                existing.NamHoc = nh.NamHoc;
                existing.HocKi = nh.HocKi;
                existing.TKB = nh.TKB;
                existing.HocPhi = nh.HocPhi;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var existing = listNamHoc.FirstOrDefault(x => x.Id == id);
            if (existing != null)
            {
                listNamHoc.Remove(existing);
                return true;
            }
            return false;
        }
    }
}
