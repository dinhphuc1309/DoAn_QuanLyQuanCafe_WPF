using DoAn_QuanLyQuanCafe.DataTier;
using DoAn_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLyQuanCafe.BusinessTier
{
    class HoaDonBT
    {
        private readonly HoaDonDT hoaDonDT;
        public HoaDonBT()
        {
            hoaDonDT = new HoaDonDT();
        }

        internal List<HoaDonDTO> LayDanhSachTatCaHoaDon()
        {
            return hoaDonDT.LayDanhSachTatCaHoaDon();
        }
        internal List<HoaDonDTO> LocHoaDon(int y, int m, int d)
        {
            return hoaDonDT.LocHoaDon(y, m, d);
        }
    }
}
