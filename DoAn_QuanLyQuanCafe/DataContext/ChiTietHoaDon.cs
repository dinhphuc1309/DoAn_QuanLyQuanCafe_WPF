namespace DoAn_QuanLyQuanCafe.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        public int maChiTietHoaDon { get; set; }

        public int maHoaDon { get; set; }

        public int maThucUong { get; set; }

        public int soLuong { get; set; }

        public double thanhTien { get; set; }

        public virtual ThucUong ThucUong { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
