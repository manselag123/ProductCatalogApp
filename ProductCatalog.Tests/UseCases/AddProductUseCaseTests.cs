using Moq;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Application.UseCases;
using ProductCatalog.Domain.Entities;
using System.Threading.Tasks;
using Xunit;

namespace ProductCatalog.Tests.UseCases
{
    public class AddProductUseCaseTests
    {
        // execute async shoud add product to the database 
        [Fact]
        public async Task ExecuteAsync_ShouldAddProduct()
        {
            // Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            var useCase = new AddProductUseCase(mockProductRepository.Object);
            var product = new Product
            {
                Id = 1,
                Name = "Test Product",
                Description = "Test Description",
                Price = 10.5m,
                StockQuantity = 100
            };

            // Act
            await useCase.ExecuteAsync(product);

            // Assert
            mockProductRepository.Verify(r => r.AddAsync(product), Times.Once);
        }
    }
}
