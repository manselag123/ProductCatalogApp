using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.UseCases
{
    public class GetProductByIdUseCase
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> ExecuteAsync(int id)
        {
           return await _productRepository.GetByIdAsync(id);
        }
    }
}
