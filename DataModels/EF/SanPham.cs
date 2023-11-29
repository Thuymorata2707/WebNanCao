namespace DataModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietHoaDon = new HashSet<ChiTietHoaDon>();
            GioHang = new HashSet<GioHang>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGiaBan { get; set; }

        public double? DonGiaNhap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }

        public int? NhaSanXuatId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHang { get; set; }

        public virtual NhaSanXuat NhaSanXuat { get; set; }
    }
}
