using DoAn_QuanLyQuanCafe.DataContext;
using DoAn_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLyQuanCafe.DataTier
{
    class ChiTietHoaDonDT
    {
        internal List<ChiTietHoaDonDTO> LayDanhSachChiTietTheoMaHoaDOn(int maHoaDonChon)
        {
            using (var dbcontext = new QuanCafeModel())
            {
                return (from ct in dbcontext.ChiTietHoaDons
                        where ct.maHoaDon == maHoaDonChon
                        select new ChiTietHoaDonDTO()
                        {
                            MaHoaDon = ct.maHoaDon,
                            TenThucUong = ct.ThucUong.tenThucUong,
                            SoLuong = ct.soLuong
                        }).ToList();
            }
        }

        public void NhapCTHoaDon(int maHoaDon, int maThucUong, int soLuong)
        {
            using (var dbcontext = new QuanCafeModel())
            {
                ChiTietHoaDon cthd = new ChiTietHoaDon
                {
                    maHoaDon = maHoaDon,
                    maThucUong = maThucUong,
                    soLuong = soLuong
                };
                dbcontext.ChiTietHoaDons.Add(cthd);
                dbcontext.SaveChanges();
            }
        }
    }
}
