using DoAn_QuanLyQuanCafe.DataContext;
using DoAn_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLyQuanCafe.DataTier
{
    class ThucUongDT
    {
        internal List<ThucUongDTO> LayDanhSachTatCaThucUong()
        {
            using (var dbcontext = new QuanCafeModel())
            {
                return (from tu in dbcontext.ThucUongs
                        select new ThucUongDTO()
                        {
                            maThucUong = tu.maThucUong,
                            Name = tu.tenThucUong,
                            Value = tu.price,
                            Image = tu.hinh,
                            tenLoaiThucUong = tu.LoaiThucUong.tenLoai
                        }).ToList();
            }
        }
        internal ThucUong LayThucUong(int maThucUong)
        {
            using (var dbcontext = new QuanCafeModel())
            {
                return dbcontext.ThucUongs.SingleOrDefault(s => s.maThucUong == maThucUong);
            }
        }
    }
}
