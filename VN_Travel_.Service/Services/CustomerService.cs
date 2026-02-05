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
    public void CreateCustomer(CustomerDTO customerDTO)
    {
        _customerRepository.CreateCustomer(customerDTO);
    }

    public void DeleteCustomer(int id)
    {
        _customerRepository.DeleteCustomer(id);
    }

    public List<CustomerModel> GetAll()
    {
        return _customerRepository.GetAll();
    }

    public CustomerModel GetById(int id)
    {
        return _customerRepository.GetById(id);
    }

    public void UpdateCustomer(int id, CustomerDTO customerDTO)
    {
        _customerRepository.UpdateCustomer(id, customerDTO);
    }

    public CustomerModel GetByEmail(string email)
    {
        var users = _customerRepository.GetAll();
        var user = users.SingleOrDefault(x => x.Email == email);
       
        return user;
    }
}
