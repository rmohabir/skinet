using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;
        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<Product> GetProductsByIdAsync(int id)
        {
            return await _storeContext.Products
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _storeContext.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .ToListAsync();
        }

        public async  Task<List<ProductBrand>> GetProductBrandsAsync()
        {
            return await _storeContext.ProductBrands.ToListAsync();
        }

        public  async Task<List<ProductType>> GetProductTypesAsync()
        {
            return await _storeContext.ProductTypes.ToListAsync();
        }
    }
}