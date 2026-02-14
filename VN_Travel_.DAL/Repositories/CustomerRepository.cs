using Microsoft.EntityFrameworkCore;
using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Entities;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;
    public CustomerRepository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    public async Task CreateCustomerAsync(CustomerDTO customerDTO)
    {
        var customer = new Customer
        {
            Address = customerDTO.Address,
            CreatedAt = DateTime.UtcNow,
            DateOfBirth = DateTime.UtcNow,
            Email = customerDTO.Email,
            IsActive = customerDTO.IsActive,
            Name = customerDTO.Name,
            Nationality = customerDTO.Nationality,
            PassportExpiryDate = customerDTO.PassportExpiryDate,
            PassportId = customerDTO.PassportId,
            PhoneNumber = customerDTO.PhoneNumber,
            Surname = customerDTO.Surname,
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var customer = _context.Customers.Find(id);

        if (customer == null)
        {
            throw new Exception($"Customer with ID {id} not found");
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CustomerModel>> GetAllAsync()
    {
        var customers = await _context.Customers.ToListAsync();
        var customerModels = new List<CustomerModel>();

        foreach (var customer in customers)
        {
            customerModels.Add(new CustomerModel
            {
                CreatedAt = customer.CreatedAt,
                Address = customer.Address,
                DateOfBirth = customer.DateOfBirth,
                Email = customer.Email,
                IsActive = customer.IsActive,
                Name = customer.Name,
                Nationality = customer.Nationality,
                PassportExpiryDate = customer.PassportExpiryDate,
                PassportId = customer.PassportId,
                PhoneNumber = customer.PhoneNumber,
                Surname = customer.Surname,
            });
        }

        return customerModels;
    }

    public async Task<CustomerModel> GetByIdAsync(int id)
    {
        var customers = await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);
        var customerModels = new CustomerModel
        {
            Address = customers.Address,
            CreatedAt = DateTime.UtcNow,
            DateOfBirth = DateTime.UtcNow,
            Email = customers.Email,
            IsActive = customers.IsActive,
            Name = customers.Name,
            Nationality = customers.Nationality,
            PassportExpiryDate = customers.PassportExpiryDate,
            PassportId = customers.PassportId,
            PhoneNumber = customers.PhoneNumber,
            Surname = customers.Surname,
        };
        return customerModels;
    }

    public async Task UpdateCustomerAsync(int id, CustomerDTO customerDTO)
    {
        var customer = _context.Customers.Find(id);

        if (customer == null)
        {
            throw new Exception($"Customer with ID {id} not found");
        }
        customer.DateOfBirth = DateTime.UtcNow;
        customer.Email = customerDTO.Email;
        customer.IsActive = customerDTO.IsActive;
        customer.Name = customerDTO.Name;
        customer.Nationality = customerDTO.Nationality;
        customer.PassportExpiryDate = customerDTO.PassportExpiryDate;
        customer.PassportId = customerDTO.PassportId;
        customer.PhoneNumber = customerDTO.PhoneNumber;
        customer.Surname = customerDTO.Surname;
        customer.DateOfBirth = customerDTO.DateOfBirth;

        _context.Update(customer);
        await _context.SaveChangesAsync();
    }
}
