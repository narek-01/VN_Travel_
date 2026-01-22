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
    public void CreateOrder(OrderDTO orderDTO)
    {
        _orderRepository.CreateOrder(orderDTO);
    }

    public void DeleteOrder(int id)
    {
        _orderRepository.DeleteOrder(id);
    }

    public List<OrderModel> GetAll()
    {
        return _orderRepository.GetAll();
    }

    public OrderModel GetById(int id)
    {
        return _orderRepository.GetById(id);
    }

    public void UpdateOrder(int id, OrderDTO orderDTO)
    {
        _orderRepository.UpdateOrder(id, orderDTO);
    }
}
