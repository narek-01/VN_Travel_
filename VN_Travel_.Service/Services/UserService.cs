using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;
using VN_Travel_.Service.Interface;

namespace VN_Travel_.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void CreateUser(UserDTO userDTO)
    {
        _userRepository.CreateUser(userDTO);
    }

    public void DeleteUser(int id)
    {
        _userRepository.DeleteUser(id);
    }

    public List<UserModel> GetAll()
    {
        return _userRepository.GetAll();
    }

    public UserModel GetById(int id)
    {
        return _userRepository.GetById(id);
    }

    public void UpdateUser(int id, UserDTO userDTO)
    {
        _userRepository.UpdateUser(id, userDTO);
    }
}
