using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Entities;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Interface;

public interface IUserRepository
{
    public List<UserModel> GetAll();
    public void CreateUser(UserDTO userDTO);
    public void UpdateUser(int id, UserDTO userDTO);
    public void DeleteUser(int id);
    public UserModel GetById(int id);
}
