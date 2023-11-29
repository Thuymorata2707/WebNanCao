namespace DataModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            GioHangs = new HashSet<GioHang>();
            HoaDons = new HashSet<HoaDon>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string SĐT { get; set; }

        public int? ChucVu { get; set; }

        [StringLength(32)]
        public string TaiKhoan { get; set; }

        [StringLength(150)]
        public string MatKhau { get; set; }

        public virtual ChucVu ChucVu1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
