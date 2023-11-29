using DataModels.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Dto
{
    public class SanPhamDto
    {
        private readonly NhaSachDbContext context = new NhaSachDbContext();
        
        public IEnumerable<SanPham> GetAll() => 
            context.SanPhams.AsEnumerable();

        public int Create(SanPham entity)
        {
            try
            {
                context.SanPhams.Add(entity);
                context.SaveChanges();
                return entity.Id;
            }
            catch
            {
                return 0;
            }
        }

        public SanPham GetById(int id)
            => context.SanPhams.FirstOrDefault(x => x.Id == id);

        public bool Update(SanPham entity)
        {
            try
            {
                var updateSanPham = context.SanPhams.FirstOrDefault(x => x.Id == entity.Id);
                if (updateSanPham == null) return false;

                updateSanPham.TenSP = entity.TenSP;
                updateSanPham.SoLuong = entity.SoLuong;
                updateSanPham.DonGiaBan = entity.DonGiaBan;
                updateSanPham.DonGiaNhap = entity.DonGiaNhap;
                updateSanPham.NgayNhap = entity.NgayNhap;
                updateSanPham.NhaSanXuatId = entity.NhaSanXuatId;

                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var deleteSanPham = context.SanPhams.FirstOrDefault(x => x.Id == id);
                if (deleteSanPham == null) return false;

                context.SanPhams.Remove(deleteSanPham);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
