using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseConnection;
using DatabaseConnection.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class UserService
    {
        public CarManagementContext Context { get; set; }

        public UserService(CarManagementContext context)
        {
            Context = context;
        }

        public async Task<(int?, bool?)> Login(string username, string password)
        {
            User user = await Context.Users.FirstOrDefaultAsync(record => record.Nick == username);
//            byte[] hash;
//            using (SHA256 mySha256 = SHA256.Create())
//            {
//                hash = mySha256.ComputeHash(Encoding.ASCII.GetBytes(password));
//            }
//
//            if (user.Password != Encoding.ASCII.GetString(hash))
//            {
//                return (null, null);
//            }

            if (user?.Password != password)
            {
                return (null, null);
            }

            bool? isFirstLogin = user?.IsFirstLogIn;

            return (user?.UserId, isFirstLogin);
        }

        public async Task<bool> Authorize(int userId, string password)
        {
            User user = await Context.Users.FindAsync(userId);
//            byte[] hash;
//            using (SHA256 mySha256 = SHA256.Create())
//            {
//                hash = mySha256.ComputeHash(Encoding.ASCII.GetBytes(password));
//            }

//            return user.Password == Encoding.ASCII.GetString(hash);
            return user.Password == password;
        }

        public async Task UpdatePassword(int userId, string newPassword)
        {
            User user = await Context.Users.FindAsync(userId);
//            byte[] hash;
//            using (SHA256 mySha256 = SHA256.Create())
//            {
//                hash = mySha256.ComputeHash(Encoding.ASCII.GetBytes(newPassword));
//            }

//            user.Password = Encoding.ASCII.GetString(hash);
            user.Password = newPassword;
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Car>> GetUsersCarsAsync(int userId)
        {
            var user = await Context.Users
                .Include(u => u.Cars)
                .FirstOrDefaultAsync(u => u.UserId == userId);
            var test = Context.Users.Find(userId);
            return user?.Cars;
        }
    }
}