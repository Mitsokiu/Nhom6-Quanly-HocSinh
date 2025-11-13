using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class XepLoaiBUS
    {
        private static List<XepLoaiDTO> listXepLoai = new List<XepLoaiDTO>();

        public List<XepLoaiDTO> GetAll()
        {
            return listXepLoai;
        }

        public bool Add(XepLoaiDTO xl)
        {
            listXepLoai.Add(xl);
            return true;
        }

        public bool Update(XepLoaiDTO xl)
        {
            var existing = listXepLoai.FirstOrDefault(x => x.Id == xl.Id);
            if (existing != null)
            {
                existing.Gioi = xl.Gioi;
                existing.Kha = xl.Kha;
                existing.TrungBinh = xl.TrungBinh;
                existing.Yeu = xl.Yeu;
                existing.HanhKiem = xl.HanhKiem;
                existing.CongThucTB = xl.CongThucTB;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var existing = listXepLoai.FirstOrDefault(x => x.Id == id);
            if (existing != null)
            {
                listXepLoai.Remove(existing);
                return true;
            }
            return false;
        }
    }
}
