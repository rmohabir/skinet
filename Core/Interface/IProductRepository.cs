using Core.Entities;

namespace Core.Interface
{
    public interface IProductRepository
    {
        Task<Product> GetProductsByIdAsync(int id);
        Task<List<Product>> GetProductsAsync();

        Task<List<ProductBrand>> GetProductBrandsAsync();

        Task<List<ProductType>> GetProductTypesAsync();


    }
}