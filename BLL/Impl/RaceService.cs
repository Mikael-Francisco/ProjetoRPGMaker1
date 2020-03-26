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
    public class RaceService : BaseService, IRaceService
    {
        IRaceRepository _RaceRepository;

        public RaceService(IRaceRepository repo)
        {
            this._RaceRepository = repo;
        }
        public async Task Create(Race race)
        {
            List<Error> errors = new List<Error>();

            if (string.IsNullOrWhiteSpace(race.Name))
            {
                base.AddError("Nome", "O nome da raça deve ser informado");
            }
            else if (race.Name.Length > 50)
            {
                base.AddError("Nome", "O nome da raça deve conter até 50 caracteres");
            }
            base.CheckErrors();
            try
            {

                await _RaceRepository.Create(race);
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
                await _RaceRepository.Delete(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<IEnumerable<Race>> GetAllRaces()
        {
            try
            {
                return await _RaceRepository.GetAllRaces();
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<Race> GetRace(int id)
        {
            try
            {
                return await _RaceRepository.GetRace(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task Update(Race raceChanges)
        {
            try
            {
                await _RaceRepository.Update(raceChanges);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }
    }
}
