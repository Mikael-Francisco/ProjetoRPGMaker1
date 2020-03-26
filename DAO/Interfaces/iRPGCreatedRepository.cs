using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface iRPGCreatedRepository
    {
        Task Create(RPGCreated rpg);
        Task<IEnumerable<RPGCreated>> GetAllRPGs();
        Task Delete(int id);
        Task Update(RPGCreated RPGChanges);
        Task<RPGCreated> GetRPG(int id);
    }
}
