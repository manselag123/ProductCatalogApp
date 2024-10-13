using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.UseCases;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AddProductUseCase _addProductUseCase;
        private readonly UpdateProductUseCase _updateProductUseCase;
        private readonly DeleteProductUseCase _deleteProductUseCase;
        private readonly GetAllProductsUseCase _getAllProductsUseCase;
        private readonly GetProductByIdUseCase _getProductByIdUseCase;

        public ProductsController(AddProductUseCase addProductUseCase,UpdateProductUseCase updateProductUseCase,DeleteProductUseCase deleteProductUseCase, GetAllProductsUseCase getAllProductsUseCase,GetProductByIdUseCase getProductByIdUseCase)
        {
            _addProductUseCase = addProductUseCase;
            _updateProductUseCase = updateProductUseCase;
            _deleteProductUseCase = deleteProductUseCase;
            _getAllProductsUseCase = getAllProductsUseCase;
            _getProductByIdUseCase = getProductByIdUseCase;
        }

        // api for adding new product
        [Authorize(Policy ="AdminPolicy")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _addProductUseCase.ExecuteAsync(product);
            return CreatedAtAction(nameof(AddProduct), new
            {
                id = product.Id
            }, product);
        }
        // update product 
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id !=product.Id)
            {
                return BadRequest("Product Id mismatch");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _updateProductUseCase.ExecuteAsync(product);
            return NoContent();
        }

        // get all products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _getAllProductsUseCase.ExecuteAsync();
            return Ok(products);
        }
        // get product by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _getProductByIdUseCase.ExecuteAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // delete product by id
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _deleteProductUseCase.ExecuteAsync(id);
            return NoContent();
        }


    }
}
