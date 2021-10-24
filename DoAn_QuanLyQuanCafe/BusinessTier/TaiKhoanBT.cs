using DoAn_QuanLyQuanCafe.DataTier;
using DoAn_QuanLyQuanCafe.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLyQuanCafe.BusinessTier
{
    class TaiKhoanBT
    {
        private readonly TaiKhoanDT taikhoanDT;
        public TaiKhoanBT()
        {
            taikhoanDT = new TaiKhoanDT();
        }
        public bool KiemTraDangNhap(string userName, string passWord)
        {
            passWord = Helpers.MaHoaMatKhauMd5(Helpers.MaHoaMatKhauBase64(passWord));
            return taikhoanDT.KiemTraDangNhap(userName, passWord);
        }
    }
}
