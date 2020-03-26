using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class CreatureRepository : ICreatureRepository
    {
        private RPGContext _context;
        public CreatureRepository(RPGContext ctx)
        {
            this._context = ctx;
        }
        public async Task Create(Creature creature)
        {
            _context.Creatures.Add(creature);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Creature creature = _context.Creatures.Find(id);
            if (creature != null)
            {
                _context.Creatures.Remove(creature);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Creature>> GetAllCreatures()
        {
            return await _context.Creatures.ToListAsync();
        }

        public async Task<Creature> GetCreature(int id)
        {
            return await _context.Creatures.FirstOrDefaultAsync(u => u.ID == id);
        }

        public async Task Update(Creature creatureChanges)
        {
            var creature = _context.Creatures.Attach(creatureChanges);
            creature.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
