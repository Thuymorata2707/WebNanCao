using DataModels.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Dto
{
    public class NhaSanXuatDto
    {
        private readonly NhaSachDbContext context = new NhaSachDbContext();
        public int Create(NhaSanXuat nhaSanXuat)
        {
            try
            {
                context.NhaSanXuats.Add(nhaSanXuat);

                context.SaveChanges();

                return nhaSanXuat.Id;
            }
            catch
            {
                throw new Exception("Cannot insert");
            }
        }

        public IEnumerable<NhaSanXuat> GetAll()
        {
            return context.NhaSanXuats.AsEnumerable();
        }
    }
}
