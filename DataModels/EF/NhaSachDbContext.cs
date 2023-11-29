using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataModels.EF
{
    public partial class NhaSachDbContext : DbContext
    {
        public NhaSachDbContext()
            : base("name=NhaSachDbContext")
        {

        }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuats { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.NguoiDungs)
                .WithOptional(e => e.ChucVu1)
                .HasForeignKey(e => e.ChucVu);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.GioHangs)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.NguoiDung)
                .HasForeignKey(e => e.NguoiMua);

            modelBuilder.Entity<NhaSanXuat>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.NhaSanXuat)
                .HasForeignKey(e => e.NhaSanXuatId);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietHoaDon)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.GioHang)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);
        }
    }
}
