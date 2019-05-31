using RecruitmentTask.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentTask.Data
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int Id);
        Task<Product> Update(Product product);
        Task Add(Product product);
        Task<Product> Delete(int id);
    }
}
