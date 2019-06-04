using RecruitmentTask.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentTask.Data
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int Id);
        Task Update(Product product);
        Task<Product> Add(Product product);
        Task Delete(int id);
    }
}
