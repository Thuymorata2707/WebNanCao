namespace DataModels.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaSanXuat")]
    public partial class NhaSanXuat
    {
        public NhaSanXuat()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string TenNSX { get; set; }

        [StringLength(250)]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
