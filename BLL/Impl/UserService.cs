using BLL.Interfaces;
using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class UserService : BaseService, IUserService
    {
        IUserRepository _UserRepository;

        public UserService(IUserRepository repo)
        {
            this._UserRepository = repo;
        }
        public async Task<User> Authenticate(string email, string password)
        {
            return await _UserRepository.Authenticate(email, password);
        }

        public async Task Create(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                base.AddError("Nome", "O nome do usuário deve ser informado.");
            }
            else if (user.Name.Length < 2 || user.Name.Length > 50)
            {
                base.AddError("Nome", "O nome do usuário deve ser conter entre 2 e 50 caracteres.");
            }
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                base.AddError("Email", "O Email do usuário deve ser informado.");
            }
            else if (user.Email.Length < 2 || user.Email.Length > 100)
            {
                base.AddError("Email", "O Email do usuário deve ser conter entre 2 e 100 caracteres.");
            }

            try
            {
                await _UserRepository.Create(user);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o admnistrador.");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _UserRepository.Delete(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                return await _UserRepository.GetAllUsers();
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                return await _UserRepository.GetUser(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task Update(User userChanges)
        {
            try
            {
                await _UserRepository.Update(userChanges);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }
    }
}
