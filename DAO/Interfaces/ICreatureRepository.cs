using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface ICreatureRepository
    {
        Task Create(Creature creature);
        Task<IEnumerable<Creature>> GetAllCreatures();
        Task Delete(int id);
        Task Update(Creature creatureChanges);
        Task<Creature> GetCreature(int id);
    }
}
