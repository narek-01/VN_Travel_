using System.Threading.Tasks;
using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;
using VN_Travel_.Service.Interface;

namespace VN_Travel_.Service.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        this._customerRepository = customerRepository;
    }
    public async Task CreateCustomerAsync(CustomerDTO customerDTO)
    {
        await _customerRepository.CreateCustomerAsync(customerDTO);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await _customerRepository.DeleteCustomerAsync(id);
    }

    public async Task<List<CustomerModel>> GetAllAsync()
    {
        return await _customerRepository.GetAllAsync();
    }

    public async Task<CustomerModel> GetByIdAsync(int id)
    {
        return await _customerRepository.GetByIdAsync(id);
    }

    public async Task UpdateCustomer(int id, CustomerDTO customerDTO)
    {
        await _customerRepository.UpdateCustomerAsync(id, customerDTO);
    }

    public async Task<CustomerModel> GetByEmailAsync(string email)
    {
        var users = await _customerRepository.GetAllAsync();
        var user =  users.SingleOrDefault(x => x.Email == email);

        return user;
    }
}
