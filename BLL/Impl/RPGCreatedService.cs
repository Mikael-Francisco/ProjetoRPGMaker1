using Common;
using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class RPGCreatedService : BaseService, IRPGCreatedService
    {
        iRPGCreatedRepository _RPGCreatedRepository;

        public RPGCreatedService(iRPGCreatedRepository repo)
        {
            this._RPGCreatedRepository = repo;
        }
        public async Task Create(RPGCreated rpg)
        {
            List<Error> errors = new List<Error>();

            if (string.IsNullOrWhiteSpace(rpg.Name))
            {
                base.AddError("Nome", "O nome do RPG deve ser informado");
            }
            else if (rpg.Name.Length > 50)
            {
                base.AddError("Nome", "O nome do RPG deve conter até 50 caracteres");
            }
            base.CheckErrors();
            try
            {
                await _RPGCreatedRepository.Create(rpg);
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
                await _RPGCreatedRepository.Delete(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<IEnumerable<RPGCreated>> GetAllRPGs()
        {
            try
            {
                return await _RPGCreatedRepository.GetAllRPGs();
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<RPGCreated> GetRPG(int id)
        {
            try
            {
                return await _RPGCreatedRepository.GetRPG(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task Update(RPGCreated RPGChanges)
        {
            try
            {
                await _RPGCreatedRepository.Update(RPGChanges);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }
    }
}
