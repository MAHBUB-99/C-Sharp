using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PC.Application.Common;
using PC.Application.DTOs;
using PC.Application.IService;
using PC.Application.Wrappers;

namespace PC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        // GET: api/Product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ProductOutDto>>> GetById(int id)
        {
            var response = await _service.GetByIdAsync(id);

            if (!response.Success)
                return StatusCode(response.StatusCode, response);

            return Ok(response);
        }

        // GET: api/Product?page=1&pageSize=10
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<PaginatedResult<ProductOutDto>>>> GetPaged([FromQuery] PaginationParameters paginationParameters)
        {
            var response = await _service.GetPagedAsync(paginationParameters);

            if (!response.Success)
                return StatusCode(response.StatusCode, response);

            return Ok(response);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ProductOutDto>>> Create([FromBody] ProductInDto productInDto)
        {
            var response = await _service.CreateAsync(productInDto);

            if (!response.Success)
                return StatusCode(response.StatusCode, response);

            return CreatedAtAction(nameof(GetById), new { id = response.Data!.Id }, response);
        }

        // PUT: api/Product/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<ProductOutDto>>> Update(int id, [FromBody] ProductUpdateDto productUpdateDto)
        {
            var response = await _service.UpdateAsync(id, productUpdateDto);

            if (!response.Success)
                return StatusCode(response.StatusCode, response);

            return Ok(response);
        }

        // DELETE: api/Product/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            var response = await _service.DeleteAsync(id);

            if (!response.Success)
                return StatusCode(response.StatusCode, response);

            return Ok(response);
        }
    }
}
