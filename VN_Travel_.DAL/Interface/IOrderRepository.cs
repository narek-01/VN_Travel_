using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Interface;

public interface IOrderRepository
{
    public Task<List<OrderModel>> GetAllAsync();
    public Task CreateOrderAsync(OrderDTO orderDTO);
    public Task UpdateOrderAsync(int id, OrderDTO orderDTO);
    public Task DeleteOrderAsync(int id);
    public Task<OrderModel> GetByIdAsync(int id);
}
