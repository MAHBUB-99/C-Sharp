using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UOW.Models;
using UOW.UnitOfWork;

namespace UOW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _unitOfWork._orderRepository.GetAllAsync();
            return Ok(orders);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _unitOfWork._orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            await _unitOfWork._orderRepository.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            var existingOrder = await _unitOfWork._orderRepository.GetByIdAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }
            existingOrder.ProductId = order.ProductId;
            existingOrder.Quantity = order.Quantity;
            _unitOfWork._orderRepository.Update(existingOrder);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _unitOfWork._orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            _unitOfWork._orderRepository.Delete(order);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

    }
}
