namespace DoAn_QuanLyQuanCafe.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        public int idTK { get; set; }

        [Required]
        [StringLength(100)]
        public string useName { get; set; }

        [Required]
        [StringLength(50)]
        public string matKhau { get; set; }

        public int loaiTK { get; set; }

        public int maNV { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
