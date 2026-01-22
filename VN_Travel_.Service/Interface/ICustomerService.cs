using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.Service.Interface;

public interface ICustomerService
{
    public List<CustomerModel> GetAll();

    public void CreateCustomer(CustomerDTO customerDTO);
    public void UpdateCustomer(int id, CustomerDTO customerDTO);
    public void DeleteCustomer(int id);
    public CustomerModel GetById(int id);
}
