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
        [StringLength(100)]
        public string useName { get; set; }

        [Required]
        [StringLength(50)]
        public string matKhau { get; set; }

        [Required]
        [StringLength(200)]
        public string tenHienThi { get; set; }
    }
}
