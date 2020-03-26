using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICreatureService
    {
        Task Create(Creature creature);
        Task<IEnumerable<Creature>> GetAllCreatures();
        Task Delete(int id);
        Task Update(Creature creatureChanges);
        Task<Creature> GetCreature(int id);
    }
}
