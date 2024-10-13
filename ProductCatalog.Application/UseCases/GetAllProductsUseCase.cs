using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.UseCases
{
    public class GetAllProductsUseCase
    {
        // product repository inject and get all method
        private readonly IProductRepository _productRepository;

        public GetAllProductsUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> ExecuteAsync()
        {
           return await _productRepository.GetAllAsync( );
        }
    }
}
