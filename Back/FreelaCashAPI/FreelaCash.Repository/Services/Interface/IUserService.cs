using FreelaCash.Dominio.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelaCash.Repository.Services.Interface
{
    public interface IUserService
    {
        //Task<User> AddUserAsync(User model);
        Task<User> UpdateUserAsync(int id, User model);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        //Task<bool> DeleteUserAsync(int id);
    }
}
