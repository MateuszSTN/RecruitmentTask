using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RecruitmentTask.Core;

namespace RecruitmentTask.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            // jakiś await?
            return _db.Products;
        }

        public async Task<Product> GetById(int id)
        {
            return await _db.Products.FindAsync(id)
        }

        public async Task Add(Product product)
        {
            // Pomyśleć o dodaniu Cancellation Token
            await _db.AddAsync(product);
            await _db.SaveChangesAsync();
        }
        public async Task<Product> Update(Product updatedProduct)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
