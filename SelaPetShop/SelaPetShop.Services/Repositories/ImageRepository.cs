using SelaPetShop.Data;
using SelaPetShop.Models.Entities;
using SelaPetShop.Models.Helpers;
using SelaPetShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelaPetShop.Services.Repositories
{
    public class ImageRepository : IRepository<Image>
    {
        private readonly PetShopDbContext _context;

        public ImageRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public Task<Image> Add(Image entity)
        {
            throw new NotImplementedException();
        }

        public Task<Image> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Image> Get(int? id)
        {
            return _context.Images.SingleOrDefault(p => p.ImageId == id);
        }

        public Task<FilterResponse<Image>> Get(Filter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetLastId()
        {
            throw new NotImplementedException();
        }

        public Task<Image> Update(Image entity)
        {
            throw new NotImplementedException();
        }
    }
}
