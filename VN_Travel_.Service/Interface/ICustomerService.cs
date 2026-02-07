using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.Service.Interface;

public interface ICustomerService
{
    public Task<List<CustomerModel>> GetAllAsync();
    public Task CreateCustomerAsync(CustomerDTO customerDTO);
    public Task UpdateCustomerAsync(int id, CustomerDTO customerDTO);
    public Task DeleteCustomerAsync(int id);
    public Task<CustomerModel> GetByIdAsync(int id);
    public Task<CustomerModel> GetByEmailAsync(string email);
}
