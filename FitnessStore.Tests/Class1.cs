using FitnessStore.Business;
using FitnessStore.Data;
using FitnessStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Serilog;
using Xunit;




// Tests with xUnit and Moq

namespace FitnessStore.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IRepository<Product>> _mockRepository;
        private readonly IProductService _productService;

        public ProductServiceTests()
        {
            _mockRepository = new Mock<IRepository<Product>>();
            _productService = new ProductService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        {
            // Arrange
            var products = new List<Product> {
                new Product { Id = "1", Name = "Dumbbell", Price = 20.0M },
                new Product { Id = "2", Name = "Treadmill", Price = 1000.0M }
            };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);

            // Act
            var result = await _productService.GetAllProductsAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }
    }
}