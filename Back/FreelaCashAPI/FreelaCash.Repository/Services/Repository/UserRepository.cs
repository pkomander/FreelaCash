using FreelaCash.Dominio.Identity;
using FreelaCash.Repository.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelaCash.Repository.Services.Repository
{
    public class UserRepository : IUserService
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        //public Task<User> AddUserAsync(User model)
        //{
        //    try
        //    {
        //        _context.Add(model);

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                return await _context.Users.Where(x => x.Id == id).SingleOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            try
            {
                return await _context.Users.Where(x => x.UserName == username).SingleOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<User> UpdateUserAsync(int id, User model)
        {
            throw new NotImplementedException();
        }

        //public Task<bool> DeleteUserAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
