namespace VN_Travel_.Service.Interface;
using VN_Travel_.DAL.Models;
using VN_Travel_.DAL.DTOs;


public interface IUserService
{
    public List<UserModel> GetAll();

    public void CreateUser(RegistratonDTO RegistrationDTO);
    public void UpdateUser(int id, UserDTO userDTO);
    public void DeleteUser(int id);
    public UserModel GetById(int id);
}

