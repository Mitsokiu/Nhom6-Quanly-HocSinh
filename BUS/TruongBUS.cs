using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class TruongBUS
    {
        private static List<TruongDTO> listTruong = new List<TruongDTO>();

        public List<TruongDTO> GetAll()
        {
            return listTruong;
        }

        public bool Add(TruongDTO truong)
        {
            listTruong.Add(truong);
            return true;
        }

        public bool Update(TruongDTO truong)
        {
            var existing = listTruong.FirstOrDefault(t => t.Id == truong.Id);
            if (existing != null)
            {
                existing.TenTruong = truong.TenTruong;
                existing.DiaChi = truong.DiaChi;
                existing.Gmail = truong.Gmail;
                existing.NamThanhLap = truong.NamThanhLap;
                existing.LogoPath = truong.LogoPath;
                return true;
            }
            return false;
        }
    }
}
