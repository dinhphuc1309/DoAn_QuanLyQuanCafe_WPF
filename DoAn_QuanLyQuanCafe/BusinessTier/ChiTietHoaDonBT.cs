using DoAn_QuanLyQuanCafe.DataTier;
using DoAn_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLyQuanCafe.BusinessTier
{
    class ChiTietHoaDonBT
    {
        private readonly ChiTietHoaDonDT chiTietHoaDonDT;
        public ChiTietHoaDonBT()
        {
            chiTietHoaDonDT = new ChiTietHoaDonDT();
        }

        internal List<ChiTietHoaDonDTO> LayDanhSachChiTietTheoMaHoaDon(int maHoaDonChon)
        {
            return chiTietHoaDonDT.LayDanhSachChiTietTheoMaHoaDOn(maHoaDonChon);
        }
    }
}
