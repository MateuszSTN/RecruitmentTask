using RecruitmentTask.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentTask.Data
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll(string name=null, Category? category =null);
        Task<Product> GetById(int Id);
        Task Create(Product createProduct);

        Task Update(Product product);
        Task Delete(Product deleteProduct);

    }
}
