using Microsoft.AspNetCore.Identity;
using Projekt_Restauracja.Data;
using Projekt_Restauracja.Models;

namespace Projekt_Restauracja.Services
{
    public interface IAccountService
    {
        void RegisterUser(User user);
    }
    public class AccountService : IAccountService
    {
        private readonly RestaurantDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(RestaurantDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public void RegisterUser(User user)
        {
            var newUser = new User()
            {
                email = user.email,
                Year = user.Year,
              

            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, user.Password);
             
            newUser.PasswordHash = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();

        }
    }
}
