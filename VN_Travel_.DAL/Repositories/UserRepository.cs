using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Entities;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context = new ApplicationDbContext();
    //public UserRepository(ApplicationDbContext applicationDbContext)
    //{
    //    _context = applicationDbContext;
    //}
    public async Task CreateUserAsync(RegistratonDTO registratonDTO)
    {
        var customer = new User 
        {
            Username = registratonDTO.username,
            Email = registratonDTO.Email,
            Password = registratonDTO.Password
        };
        _context.Add(customer);
        try
        {
        await _context.SaveChangesAsync();

        }
        catch(Exception e)
        {

        }
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = _context.Users.Find(id);

        if (user == null)
        {
            throw new Exception($"Customer with ID {id} not found");
        }
        _context.Users.Remove(user);
         await _context.SaveChangesAsync();
    }

    public async Task<List<UserModel>> GetAllAsync()
    {

        var users = await _context.Users.ToListAsync();
        var userModels = new List<UserModel>();

        foreach (var user in users)
        {
            userModels.Add(new UserModel
            {
                Email = user.Email,
                Username = user.Username,
                Password = user.Password
            });
        }

        return userModels;
    }

    public async Task<UserModel> GetByIdAsync(int id)
    {
        var users = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        var userModels = new UserModel
        {
            Email = users.Email,
            Username = users.Username,
            Password = users.Password
        };
        return userModels;

    }

    public async Task UpdateUserAsync(int id, UserDTO userDTO)
    {
        var user = _context.Users.Find(id);

        if (user == null)
        {
            throw new Exception($"Customer with ID {id} not found");
        }
        user.Username = userDTO.Username;
        user.Password = userDTO.Password;
        //user.Email = userDTO.Email;



        _context.Update(user);
        await _context.SaveChangesAsync();
    }
}
