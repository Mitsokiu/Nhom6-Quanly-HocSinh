using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class ThongBaoBUS
    {
        private static List<ThongBaoDTO> listTB = new List<ThongBaoDTO>();

        public List<ThongBaoDTO> GetAll()
        {
            return listTB;
        }

        public bool Add(ThongBaoDTO tb)
        {
            listTB.Add(tb);
            return true;
        }

        public bool Delete(int id)
        {
            var existing = listTB.FirstOrDefault(t => t.Id == id);
            if (existing != null)
            {
                listTB.Remove(existing);
                return true;
            }
            return false;
        }
    }
}
