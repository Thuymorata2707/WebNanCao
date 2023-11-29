namespace DataModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SanPhamId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NguoiDungId { get; set; }

        public int? SoLuong { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
