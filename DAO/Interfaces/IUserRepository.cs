using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task Delete(int id);
        Task Update(User userChanges);
        Task<User> GetUser(int id);
        Task<User> Authenticate(string email, string password);
    }
}
