namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_simple_database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietHoaDon",
                c => new
                    {
                        HoaDonId = c.Int(nullable: false),
                        SanPhamId = c.Int(nullable: false),
                        SoLuong = c.Int(),
                        DonGia = c.Decimal(precision: 18, scale: 0),
                        GiamGia = c.Double(),
                    })
                .PrimaryKey(t => new { t.HoaDonId, t.SanPhamId })
                .ForeignKey("dbo.HoaDon", t => t.HoaDonId)
                .ForeignKey("dbo.SanPham", t => t.SanPhamId)
                .Index(t => t.HoaDonId)
                .Index(t => t.SanPhamId);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NgayTao = c.DateTime(storeType: "date"),
                        ThanhToan = c.Boolean(),
                        NguoiMua = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NguoiDung", t => t.NguoiMua)
                .Index(t => t.NguoiMua);
            
            CreateTable(
                "dbo.NguoiDung",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(maxLength: 50),
                        DiaChi = c.String(maxLength: 50),
                        GioiTinh = c.String(maxLength: 50),
                        NgaySinh = c.DateTime(storeType: "date"),
                        SĐT = c.String(maxLength: 50),
                        ChucVu = c.Int(),
                        TaiKhoan = c.String(maxLength: 32),
                        MatKhau = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChucVu", t => t.ChucVu)
                .Index(t => t.ChucVu);
            
            CreateTable(
                "dbo.ChucVu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenChucVu = c.String(maxLength: 50),
                        MoTa = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GioHang",
                c => new
                    {
                        SanPhamId = c.Int(nullable: false),
                        NguoiDungId = c.Int(nullable: false),
                        SoLuong = c.Int(),
                    })
                .PrimaryKey(t => new { t.SanPhamId, t.NguoiDungId })
                .ForeignKey("dbo.SanPham", t => t.SanPhamId)
                .ForeignKey("dbo.NguoiDung", t => t.NguoiDungId)
                .Index(t => t.SanPhamId)
                .Index(t => t.NguoiDungId);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenSP = c.String(maxLength: 50),
                        SoLuong = c.Int(),
                        DonGiaBan = c.Double(),
                        DonGiaNhap = c.Double(),
                        NgayNhap = c.DateTime(storeType: "date"),
                        NhaSanXuatId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NhaSanXuat", t => t.NhaSanXuatId)
                .Index(t => t.NhaSanXuatId);
            
            CreateTable(
                "dbo.NhaSanXuat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenNSX = c.String(maxLength: 50),
                        MoTa = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoaDon", "NguoiMua", "dbo.NguoiDung");
            DropForeignKey("dbo.GioHang", "NguoiDungId", "dbo.NguoiDung");
            DropForeignKey("dbo.SanPham", "NhaSanXuatId", "dbo.NhaSanXuat");
            DropForeignKey("dbo.GioHang", "SanPhamId", "dbo.SanPham");
            DropForeignKey("dbo.ChiTietHoaDon", "SanPhamId", "dbo.SanPham");
            DropForeignKey("dbo.NguoiDung", "ChucVu", "dbo.ChucVu");
            DropForeignKey("dbo.ChiTietHoaDon", "HoaDonId", "dbo.HoaDon");
            DropIndex("dbo.SanPham", new[] { "NhaSanXuatId" });
            DropIndex("dbo.GioHang", new[] { "NguoiDungId" });
            DropIndex("dbo.GioHang", new[] { "SanPhamId" });
            DropIndex("dbo.NguoiDung", new[] { "ChucVu" });
            DropIndex("dbo.HoaDon", new[] { "NguoiMua" });
            DropIndex("dbo.ChiTietHoaDon", new[] { "SanPhamId" });
            DropIndex("dbo.ChiTietHoaDon", new[] { "HoaDonId" });
            DropTable("dbo.NhaSanXuat");
            DropTable("dbo.SanPham");
            DropTable("dbo.GioHang");
            DropTable("dbo.ChucVu");
            DropTable("dbo.NguoiDung");
            DropTable("dbo.HoaDon");
            DropTable("dbo.ChiTietHoaDon");
        }
    }
}
