﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            return await Task.Run(() =>(_db.Products).OrderBy(x=>x.Name));
        }

        public async Task<Product> GetById(int id)
        {
            return await _db.Products.FindAsync(id);
        }

        public async Task<Product> Add(Product product)
        {
            // Pomyśleć o dodaniu Cancellation Token
            await _db.AddAsync(product);
            await _db.SaveChangesAsync();
            return product;
        }
        public async Task Update(Product updatedProduct)
        {
            var product = await _db.Products.FindAsync(updatedProduct.Id);
            if(product != null)
            {
                _db.Products.Update(updatedProduct);
            }
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product != null)
            {
                _db.Products.Update(product);
            }
            await _db.SaveChangesAsync();
        }
    }
}
