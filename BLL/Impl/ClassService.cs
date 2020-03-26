using BLL.Interfaces;
using Common;
using DAO;
using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class ClassService : BaseService, IClassService
    {
        IClassRepository _ClassRepository;

        public ClassService(IClassRepository repo)
        {
            this._ClassRepository = repo;
        }
        public async Task Create(Class classes)
        {
            List<Error> errors = new List<Error>();

            if (string.IsNullOrWhiteSpace(classes.Name))
            {
                base.AddError("Nome", "O nome da classe deve ser informado");
            }
            else if (classes.Name.Length > 50)
            {
                base.AddError("Nome", "O nome da classe deve conter até 50 caracteres");
            }
            base.CheckErrors();
            try
            {
                await _ClassRepository.Create(classes);
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
                await _ClassRepository.Delete(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<IEnumerable<Class>> GetAllClasses()
        {
            try
            {
                return await _ClassRepository.GetAllClasses();
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<Class> GetClass(int id)
        {
            try
            {
                return await _ClassRepository.GetClass(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task Update(Class classChanges)
        {
            try
            {
                await _ClassRepository.Update(classChanges);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }
    }
}
