using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DoAn_QuanLyQuanCafe.DataContext
{
    public partial class QuanCafeModel : DbContext
    {
        public QuanCafeModel()
            : base("name=QuanCafeModel")
        {
        }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThucUong> ThucUongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.useName)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.matKhau)
                .IsUnicode(false);

            modelBuilder.Entity<ThucUong>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.ThucUong)
                .WillCascadeOnDelete(false);
        }
    }
}
