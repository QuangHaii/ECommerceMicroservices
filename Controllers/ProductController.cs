using ECommerceMicroservices.Data;
using ECommerceMicroservices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ECommerceMicroservices.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IMongoCollection<Product>? _productCollection;
		public ProductController(MongoDbService mongoDbService)
		{
			_productCollection = mongoDbService.Database?.GetCollection<Product>("Products");
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
		{
			return await _productCollection.Find(Builders<Product>.Filter.Empty).ToListAsync();
		}

		[HttpGet("{productId}")]
		public async Task<ActionResult<Product>> GetById(string productId)
		{
			var product = await _productCollection.Find(Builders<Product>.Filter.Eq(p => p.productId, productId)).FirstOrDefaultAsync();
			if (product == null)
			{
				return NotFound();
			}
			return product;
		}

		[HttpPost]
		public async Task<ActionResult> CreateProduct(Product product)
		{
			await _productCollection.InsertOneAsync(product);
			return CreatedAtAction(nameof(GetById), new { productId = product.productId }, product);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateProduct(Product product)
		{
			await _productCollection.ReplaceOneAsync(Builders<Product>.Filter.Eq(p => p.productId, product.productId), product);
			return Ok();
		}

		[HttpDelete("{productId}")]
		public async Task<ActionResult> DeleteProduct(string productId)
		{
			await _productCollection.DeleteOneAsync(Builders<Product>.Filter.Eq(p => p.productId, productId));
			return Ok();
		}
	}
}
