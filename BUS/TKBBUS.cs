using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class TKBBUS
    {
        private static List<TKBDTO> listTKB = new List<TKBDTO>();

        public List<TKBDTO> GetAll()
        {
            return listTKB;
        }

        public bool Add(TKBDTO tkb)
        {
            listTKB.Add(tkb);
            return true;
        }

        public bool Update(TKBDTO tkb)
        {
            var existing = listTKB.FirstOrDefault(x => x.Id == tkb.Id);
            if (existing != null)
            {
                existing.NamHoc = tkb.NamHoc;
                existing.HocKi = tkb.HocKi;
                existing.Lop = tkb.Lop;
                existing.Thu = tkb.Thu;
                existing.Tiet = tkb.Tiet;
                existing.GiaoVien = tkb.GiaoVien;
                existing.MonHoc = tkb.MonHoc;
                existing.Phong = tkb.Phong;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var existing = listTKB.FirstOrDefault(x => x.Id == id);
            if (existing != null)
            {
                listTKB.Remove(existing);
                return true;
            }
            return false;
        }
    }
}
