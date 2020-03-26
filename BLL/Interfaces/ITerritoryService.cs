using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITerritoryService
    {
        Task Create(Territory territory);
        Task<IEnumerable<Territory>> GetAllTerritories();
        Task Delete(int id);
        Task Update(Territory territoryChanges);
        Task<Territory> GetTerritory(int id);
    }
}
