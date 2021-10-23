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
                            Image = tu.hinh
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

        //Thêm thức uống
        public bool ThemThucUong(ThucUong thucUong, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbContext = new QuanCafeModel())
                {
                    dbContext.ThucUongs.Add(thucUong);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message + "\n" + ex.InnerException;
                return false;
            }
        }
        //sữa thức uống
        public bool SuaThucUong(ThucUong thucUong, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbContext = new QuanCafeModel())
                {
                    var thucUongUpdate = dbContext.ThucUongs.SingleOrDefault
                        (s => s.maThucUong == thucUong.maThucUong);
                    if (thucUongUpdate == null)
                    {
                        error = "Thuc uong nay khong ton tai!!!";
                        return false;
                    }
                    thucUongUpdate.tenThucUong = thucUong.tenThucUong;
                    thucUongUpdate.price = thucUong.price;
                    thucUongUpdate.hinh = thucUong.hinh;
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message + "\n" + ex.InnerException;
                return false;
            }
        }
        //xóa khách hàng
        public bool XoaThucUong(int maThucUong, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbContext = new QuanCafeModel())
                {
                    var thucUongDelete = dbContext.ThucUongs.SingleOrDefault
                        (s => s.maThucUong == maThucUong);
                    if (thucUongDelete == null)
                    {
                        error = "Khach hang nay khong ton tai!!!";
                        return false;
                    }
                    dbContext.ThucUongs.Remove(thucUongDelete);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message + "\n" + ex.InnerException;
                return false;
            }
        }
    }
}
