namespace DoAn_QuanLyQuanCafe.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        [Key]
        public int maNV { get; set; }

        [Required]
        [StringLength(100)]
        public string tenNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? namSinh { get; set; }

        [StringLength(11)]
        public string soDienThoai { get; set; }

        [StringLength(50)]
        public string chucVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
