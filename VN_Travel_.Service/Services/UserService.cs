using System.Threading.Tasks;
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

    public async Task CreateUserAsync(RegistratonDTO RegistrationDTO)
    {
        await _userRepository.CreateUserAsync(RegistrationDTO);
    }

    public async Task DeleteUserAsync(int id)
    {
        await _userRepository.DeleteUserAsync(id);
    }

    public async Task<List<UserModel>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<UserModel> GetByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task UpdateUserAsync(int id, UserDTO userDTO)
    {
        await _userRepository.UpdateUserAsync(id, userDTO);
    }

}
