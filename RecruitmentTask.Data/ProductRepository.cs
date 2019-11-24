using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Product>> GetAll(string name=null, Category? category = null)
        {
            return await Task.Run(() =>_db.Products.Where(p => string.IsNullOrWhiteSpace(name) || p.Name.Contains(name))
                                                    .Where(p => category == null || p.Category == category)
                                                    .OrderBy(p=>p.Name));
        }

        public async Task<Product> GetById(int id)
        {
            return await Task.Run(() => _db.Products.SingleOrDefault(p => p.Id==id));
        }

        public async Task Create(Product createProduct)
        {
            await _db.Products.AddAsync(createProduct);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Product updatedProduct)
        {
            if(_db.Products.Any(p => p.Id == updatedProduct.Id))
            {
                _db.Products.Update(updatedProduct);
            }
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Product deleteProduct)
        {
            if (_db.Products.Any(p => p.Id == deleteProduct.Id))
            {
                _db.Products.Remove(deleteProduct);
            }
            await _db.SaveChangesAsync();
        }
    }
}
