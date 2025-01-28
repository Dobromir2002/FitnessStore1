using FitnessStore.Data;
using FitnessStore.Models;

namespace FitnessStore.Business
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(string id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(string id, Product product);
        Task DeleteProductAsync(string id);
    }

    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() =>
            await _productRepository.GetAllAsync();

        public async Task<Product> GetProductByIdAsync(string id) =>
            await _productRepository.GetByIdAsync(id);

        public async Task AddProductAsync(Product product) =>
            await _productRepository.CreateAsync(product);

        public async Task UpdateProductAsync(string id, Product product) =>
            await _productRepository.UpdateAsync(id, product);

        public async Task DeleteProductAsync(string id) =>
            await _productRepository.DeleteAsync(id);
    }
}