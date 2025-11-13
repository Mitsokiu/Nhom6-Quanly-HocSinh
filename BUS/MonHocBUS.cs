using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class MonHocBUS
    {
        private static List<MonHocDTO> monhocList = new List<MonHocDTO>();

        public List<MonHocDTO> GetAllMonHoc()
        {
            return monhocList;
        }

        public bool AddMonHoc(MonHocDTO mon)
        {
            monhocList.Add(mon);
            return true;
        }

        public bool UpdateMonHoc(MonHocDTO mon)
        {
            var mh = monhocList.Find(x => x.MaMon == mon.MaMon);
            if (mh != null)
            {
                mh.TenMon = mon.TenMon;
                return true;
            }
            return false;
        }

        public bool DeleteMonHoc(string maMon)
        {
            var mh = monhocList.Find(x => x.MaMon == maMon);
            if (mh != null)
            {
                monhocList.Remove(mh);
                return true;
            }
            return false;
        }
    }
}
