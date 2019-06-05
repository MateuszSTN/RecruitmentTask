﻿using RecruitmentTask.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentTask.Data
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll(string name=null, Category? category =null);
        Task<Product> GetById(int Id);
        Task Update(Product product);
    }
}
