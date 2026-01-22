using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Interface;

public interface IOrderRepository
{
    public List<OrderModel> GetAll();
    public void CreateOrder(OrderDTO orderDTO);
    public void UpdateOrder(int id, OrderDTO orderDTO);
    public void DeleteOrder(int id);
    public OrderModel GetById(int id);
}
