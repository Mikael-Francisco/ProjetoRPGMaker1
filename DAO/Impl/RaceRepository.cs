using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAO.Impl
{
    public class RaceRepository : IRaceRepository
    {
        private RPGContext _context;
        public RaceRepository(RPGContext ctx)
        {
            this._context = ctx;
        }
        public async Task Create(Race race)
        {
            _context.Races.Add(race);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Race race = _context.Races.Find(id);
            if (race != null)
            {
                _context.Races.Remove(race);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Race>> GetAllRaces()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<Race> GetRace(int id)
        {
            return await _context.Races.FirstOrDefaultAsync(u => u.ID == id);
        }
        public async Task Update(Race raceChanges)
        {
            var race = _context.Races.Attach(raceChanges);
            race.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
