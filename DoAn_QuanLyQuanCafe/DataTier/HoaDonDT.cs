using DoAn_QuanLyQuanCafe.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLyQuanCafe.DataTier
{
    class HoaDonDT
    {
        public int NhapHoaDon(string ghiChu, int tongTien)
        {
            using (var dbcontext = new QuanCafeModel())
            {
                HoaDon hd = new HoaDon
                {
                    ngayLap = DateTime.Now,
                    ghiChu = ghiChu,
                    tongTien = tongTien
                };
                dbcontext.HoaDons.Add(hd);
                dbcontext.SaveChanges();
                // Sau khi thêm mới vào db thì nó sẽ tự trả về id tự tăng
                return hd.maHoaDon;
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
        public HoaDon LayHoaDon(int maHoaDon)
        {
            using (var dbcontext = new QuanCafeModel())
            {
                return dbcontext.HoaDons.SingleOrDefault(s => s.maHoaDon == maHoaDon);
            }
        }
        public List<ChiTietHoaDon> LayCTHoaDon(int maHoaDon)
        {
            using (var dbcontext = new QuanCafeModel())
            {
                return dbcontext.ChiTietHoaDons.Where(x => x.maHoaDon.Equals(maHoaDon)).ToList();
            }
        }
    }
}
