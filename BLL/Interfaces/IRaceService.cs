using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRaceService
    {
        Task Create(Race race);
        Task<IEnumerable<Race>> GetAllRaces();
        Task Delete(int id);
        Task Update(Race raceChanges);
        Task<Race> GetRace(int id);
    }
}
