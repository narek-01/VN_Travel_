using System.Threading.Tasks;
using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;
using VN_Travel_.Service.Interface;

namespace VN_Travel_.Service.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task CreateOrderAsync(OrderDTO orderDTO)
    {
        await _orderRepository.CreateOrderAsync(orderDTO);
    }

    public async Task DeleteOrderAsync(int id)
    {
       await _orderRepository.DeleteOrderAsync(id);
    }

    public async Task<List<OrderModel>> GetAllAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public async Task<OrderModel> GetByIdAsync(int id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }

    public async Task UpdateOrderAsync(int id, OrderDTO orderDTO)
    {
        await _orderRepository.UpdateOrderAsync(id, orderDTO);
    }
}
