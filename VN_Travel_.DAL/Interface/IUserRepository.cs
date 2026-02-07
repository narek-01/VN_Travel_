using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Entities;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Interface;

public interface IUserRepository
{
    public Task<List<UserModel>> GetAllAsync();
    public Task CreateUserAsync(RegistratonDTO registratonDTO);
    public Task UpdateUserAsync(int id, UserDTO userDTO);
    public Task DeleteUserAsync(int id);
    public Task<UserModel> GetByIdAsync(int id);
}
