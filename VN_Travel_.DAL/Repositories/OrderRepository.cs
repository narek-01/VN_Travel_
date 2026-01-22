using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;
    public OrderRepository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    public void CreateOrder(OrderDTO orderDTO)
    {
        var order = new OrderModel
        {
            Destination = orderDTO.Destination,
            NumberOfPeople = orderDTO.NumberOfPeople,
            OrderDate = orderDTO.OrderDate,
            OrderNumber = orderDTO.OrderNumber,
            PaymentStatus = orderDTO.PaymentStatus,
            Status = orderDTO.Status,
            TotalPrice = orderDTO.TotalPrice,
            TravelEndDate = orderDTO.TravelEndDate,
            TravelStartDate = orderDTO.TravelStartDate,
        };

        _context.Add(order);
        _context.SaveChanges();
    }

    public void DeleteOrder(int id)
    {
        var order = _context.Orders.Find(id);

        if (order == null)
        {
            throw new Exception($"Order with ID {id} not found");
        }

        _context.Orders.Remove(order);
        _context.SaveChanges();
    }

    public List<OrderModel> GetAll()
    {
        var orders = _context.Orders.ToList();
        var orderModels = new List<OrderModel>();

        foreach (var order in orders)
        {
            orderModels.Add(new OrderModel
            {
                Destination = order.Destination,
                NumberOfPeople = order.NumberOfPeople,
                OrderDate = order.OrderDate,
                OrderNumber = order.OrderNumber,
                PaymentStatus = order.PaymentStatus,
                Status = order.Status,
                TotalPrice = order.TotalPrice,
                TravelEndDate = order.TravelEndDate,
                TravelStartDate = order.TravelStartDate,
            });
        }

        return orderModels;
    }

    public OrderModel GetById(int id)
    {
        var order = _context.Orders.SingleOrDefault(x => x.Id == id);
        var orderModel = new OrderModel
        {
            Destination = order.Destination,
            NumberOfPeople = order.NumberOfPeople,
            OrderDate = order.OrderDate,
            OrderNumber = order.OrderNumber,
            PaymentStatus = order.PaymentStatus,
            Status = order.Status,
            TotalPrice = order.TotalPrice,
            TravelEndDate = order.TravelEndDate,
            TravelStartDate = order.TravelStartDate,
        };
        return orderModel;
    }

    public void UpdateOrder(int id, OrderDTO orderDTO)
    {
        var order = _context.Orders.Find(id);

        if (order == null)
        {
            throw new Exception($"Order with ID {id} not found");
        }
        order.OrderDate = orderDTO.OrderDate;
        order.OrderNumber = orderDTO.OrderNumber;
        order.PaymentStatus = orderDTO.PaymentStatus;
        order.Status = orderDTO.Status; 
        order.TotalPrice = orderDTO.TotalPrice;
        order.TravelStartDate = orderDTO.TravelStartDate;
        order.TravelEndDate = orderDTO.TravelEndDate;
        order.Destination = orderDTO.Destination;
        order.NumberOfPeople = orderDTO.NumberOfPeople;


        _context.Update(order);
        _context.SaveChanges();
    }
}
