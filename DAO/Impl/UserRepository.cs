using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class UserRepository : IUserRepository
    {
        private RPGContext _context;
        public UserRepository(RPGContext ctx)
        {
            this._context = ctx;
        }
        public async Task<User> Authenticate(string email, string password)
        {
            User user = null;
            try
            {
                user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(password));

            }
            catch (Exception ex)
            {
                throw new Exception("Erro no banco de dados, contate o admnistrador.");
            }

            if (user == null)
            {
                throw new Exception("Email e/ou senhas inválidos.");
            }
            return user;
        }

        public async Task Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            User user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.ID == id);
        }

        public async Task Update(User userChanges)
        {
            var territory = _context.Users.Attach(userChanges);
            territory.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
