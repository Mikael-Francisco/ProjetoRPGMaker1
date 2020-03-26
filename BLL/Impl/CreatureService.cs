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
    public class CreatureService : BaseService, ICreatureService
    {
        ICreatureRepository _CreatureRepository;

        public CreatureService(ICreatureRepository repo)
        {
            this._CreatureRepository = repo;
        }
        public async Task Create(Creature creature)
        {
            List<Error> errors = new List<Error>();

            if (string.IsNullOrWhiteSpace(creature.Name))
            {
                base.AddError("Nome", "O nome da criatura deve ser informado");
            }
            else if (creature.Name.Length > 50)
            {
                base.AddError("Nome", "O nome da criatura deve conter até 50 caracteres");
            }
            if (creature.Age <= 0)
            {
                base.AddError("Idade", "A idade da criatura deve ser informada");
            }
            if (creature.Height <= 0)
            {
                base.AddError("Altura", "A altura da criatura deve ser informada");
            }

            base.CheckErrors();
            try
            {
                await _CreatureRepository.Create(creature);
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
               await _CreatureRepository.Delete(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<IEnumerable<Creature>> GetAllCreatures()
        {
            try
            {
                return await _CreatureRepository.GetAllCreatures();
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<Creature> GetCreature(int id)
        {
            try
            {
                return await _CreatureRepository.GetCreature(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task Update(Creature creatureChanges)
        {
            try
            {
                await _CreatureRepository.Update(creatureChanges);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }
    }
}
