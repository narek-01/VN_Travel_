using VN_Travel_.DAL.DTOs;
using VN_Travel_.DAL.Entities;
using VN_Travel_.DAL.Interface;
using VN_Travel_.DAL.Models;

namespace VN_Travel_.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    public void CreateUser(RegistratonDTO registratonDTO)
    {
        var customer = new User 
        {
            Username = registratonDTO.Name,
            Email = registratonDTO.Email,
            Password = registratonDTO.Password
        };
        _context.Add(customer);
        _context.SaveChanges();
    }

    public void DeleteUser(int id)
    {
        var user = _context.Users.Find(id);

        if (user == null)
        {
            throw new Exception($"Customer with ID {id} not found");
        }
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public List<UserModel> GetAll()
    {

        var users = _context.Users.ToList();
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

    public UserModel GetById(int id)
    {
        var users = _context.Users.SingleOrDefault(x => x.Id == id);
        var userModels = new UserModel
        {
            Email = users.Email,
            Username = users.Username,
            Password = users.Password
        };
        return userModels;

    }

    public void UpdateUser(int id, UserDTO userDTO)
    {
        var user = _context.Users.Find(id);

        if (user == null)
        {
            throw new Exception($"Customer with ID {id} not found");
        }
        user.Username = userDTO.Username;
        user.Password = userDTO.Password;
        user.Email = userDTO.Email;



        _context.Update(user);
        _context.SaveChanges();
    }
}
