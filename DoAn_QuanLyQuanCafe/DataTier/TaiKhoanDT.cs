using DoAn_QuanLyQuanCafe.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLyQuanCafe.DataTier
{
    class TaiKhoanDT
    {
        public bool KiemTraDangNhap(string userName, string passWord)
        {

            using (var dbContext = new QuanCafeModel())
            {
                return dbContext.TaiKhoans.Any(tk => tk.useName == userName && tk.matKhau == passWord);
            }

        }

        public string LayTenHienThi(string useName)
        {
            using (var dbContext = new QuanCafeModel())
            {
                return dbContext.TaiKhoans.Where(s => s.useName == useName).FirstOrDefault().tenHienThi;
            }
        }
    }
}
