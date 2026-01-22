using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;
using VN_Travel_.Service.Interface;

namespace VN_Travel_.Service.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository hotelRepository)
    {
        _orderRepository = hotelRepository;
    }
    public void CreateOrder(OrderDTO orderDTO)
    {
        _orderRepository
    }

    public void DeleteOrder(int id)
    {
    }

    public List<OrderModel> GetAll()
    {
    }

    public OrderModel GetById(int id)
    {
    }

    public void UpdateOrder(int id, OrderDTO orderDTO)
    {
    }
}
