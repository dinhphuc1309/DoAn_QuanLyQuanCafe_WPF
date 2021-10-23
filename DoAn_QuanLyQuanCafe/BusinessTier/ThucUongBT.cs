using DoAn_QuanLyQuanCafe.DataContext;
using DoAn_QuanLyQuanCafe.DataTier;
using DoAn_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_QuanLyQuanCafe.BusinessTier
{
    class ThucUongBT
    {
        private readonly ThucUongDT thucUongDT;
        public ThucUongBT()
        {
            thucUongDT = new ThucUongDT();
        }

        internal List<ThucUongDTO> LayDanhSachTatCaThucUong()
        {
            return thucUongDT.LayDanhSachTatCaThucUong();
        }

        internal ThucUong LayThucUong(int ms)
        {
            return thucUongDT.LayThucUong(ms);
        }


        public bool LuuThucUong(ThucUong thucUong, out string error)
        {
            try
            {
                //sua thuc uong
                if (thucUong.maThucUong > 0)
                {
                    return thucUongDT.SuaThucUong(thucUong, out error);
                }
                return thucUongDT.ThemThucUong(thucUong, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "\n" + ex.InnerException;
                return false;

            }
        }
        //xóa thuc uong
        public bool XoaThucUong(int maThucUong, out string error)
        {
            try
            {

                return thucUongDT.XoaThucUong(maThucUong, out error);
            }
            catch (Exception ex)
            {
                error = ex.Message + "\n" + ex.InnerException;
                return false;

            }
        }
    }
}
