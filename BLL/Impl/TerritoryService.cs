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
    public class TerritoryService : BaseService, ITerritoryService
    {
        ITerritoryRepository _TerritoryRepository;

        public TerritoryService(ITerritoryRepository repo)
        {
            this._TerritoryRepository = repo;
        }
        public async Task Create(Territory territory)
        {
            List<Error> errors = new List<Error>();

            if (string.IsNullOrWhiteSpace(territory.Name))
            {
                base.AddError("Nome", "O nome do território deve ser informado");
            }
            else if (territory.Name.Length > 50)
            {
                base.AddError("Nome", "O nome do território deve conter até 50 caracteres");
            }
            base.CheckErrors();
            try
            {
                await _TerritoryRepository.Create(territory);
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
                await _TerritoryRepository.Delete(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<IEnumerable<Territory>> GetAllTerritories()
        {
            try
            {
                return await _TerritoryRepository.GetAllTerritories();
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }
               
        public async Task<Territory> GetTerritory(int id)
        {
            try
            {
                return await _TerritoryRepository.GetTerritory(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task Update(Territory territoryChanges)
        {
            try
            {
                await _TerritoryRepository.Update(territoryChanges);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }
    }
}
