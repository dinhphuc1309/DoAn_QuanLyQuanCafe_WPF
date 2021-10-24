using DoAn_QuanLyQuanCafe.DataContext;
using DoAn_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLyQuanCafe.DataTier
{
    class HoaDonDT
    {
        internal List<HoaDonDTO> LayDanhSachTatCaHoaDon()
        {
            using (var dbcontext = new QuanCafeModel())
            {
                return (from hd in dbcontext.HoaDons
                        select new HoaDonDTO()
                        {
                            MaHoaDon = hd.maHoaDon,
                            NgayMua = hd.ngayLap,
                            TongTien = hd.tongTien,
                            GhiChu = hd.ghiChu
                        }).ToList();
            }
        }
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
    }
}
