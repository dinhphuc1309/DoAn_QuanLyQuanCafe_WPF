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
    }
}
