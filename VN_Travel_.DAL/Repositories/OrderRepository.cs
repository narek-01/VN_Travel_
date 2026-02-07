using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
    public async Task CreateOrderAsync(OrderDTO orderDTO)
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
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(int id)
    {
        var order = _context.Orders.Find(id);

        if (order == null)
        {
            throw new Exception($"Order with ID {id} not found");
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task<List<OrderModel>> GetAllAsync()
    {
        var orders = await _context.Orders.ToListAsync();
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

    public async Task<OrderModel> GetByIdAsync(int id)
    {
        var order = await _context.Orders.SingleOrDefaultAsync(x => x.Id == id);
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

    public async Task UpdateOrderAsync(int id, OrderDTO orderDTO)
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
        await _context.SaveChangesAsync();
    }
}
