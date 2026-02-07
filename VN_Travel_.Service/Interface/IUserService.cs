namespace VN_Travel_.Service.Interface;
using VN_Travel_.DAL.Models;
using VN_Travel_.DAL.DTOs;


public interface IUserService
{
    public Task<List<UserModel>> GetAllAsync();
    public Task CreateUserAsync(RegistratonDTO registratonDTO);
    public Task UpdateUserAsync(int id, UserDTO userDTO);
    public Task DeleteUserAsync(int id);
    public Task<UserModel> GetByIdAsync(int id);
}

