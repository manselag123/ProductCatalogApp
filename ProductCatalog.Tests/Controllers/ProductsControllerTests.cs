using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductCatalog.API;
using ProductCatalog.Application.UseCases;
using ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Tests.Controllers
{
    public class ProductsControllerTests
    {
        [Fact]
        public async Task GetAllProducts_ShouldReturnOkResultWithProducts()
        {
            // Arrange 
            var mockGetAllProductsUseCase = new Mock<GetAllProductsUseCase>(null);
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 10.5m, StockQuantity = 100 }

            };
            mockGetAllProductsUseCase.Setup(u => u.ExecuteAsync()).ReturnsAsync(products);
            var controller = new ProductsController(null, null, null, mockGetAllProductsUseCase.Object, null);


            var result = await controller.GetAllProducts();
            var okresult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Product>>(okresult.Value);
            Assert.Single(returnValue);
        }
    }
}
