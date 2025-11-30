using Hangfire;
using HangfireTest.Models;
using HangfireTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangfireTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IBackgroundJobClient _backgroundJobClient;
        public ProductController(IProductRepository productRepository,IBackgroundJobClient backgroundJobClient)
        {
            _productRepository = productRepository;
            _backgroundJobClient = backgroundJobClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAll();
            if(!products.Any())
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            var createdProduct = await _productRepository.Create(product);

            _backgroundJobClient.Schedule<INotificationService>(
                z => z.SendNotification(createdProduct),
                TimeSpan.FromSeconds(20));

            return CreatedAtAction(nameof(GetById), new { id = createdProduct.id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            var updatedProduct = await _productRepository.Update(id, product);
            if (updatedProduct == null)
            {
                return NotFound();
            }
            _backgroundJobClient.Schedule<INotificationService>(
                x => x.SendNotification(updatedProduct),
                TimeSpan.FromSeconds(20));
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productRepository.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }
            _backgroundJobClient.Schedule(
                () => Console.WriteLine("Deleted"),
                TimeSpan.FromSeconds(20));
            return Ok("Deleted Successfully.");
        }

    }
}
