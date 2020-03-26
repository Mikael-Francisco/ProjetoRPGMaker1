using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class TerritoryRepository : ITerritoryRepository
    {
        private RPGContext _context;
        public TerritoryRepository(RPGContext ctx)
        {
            this._context = ctx;
        }
        public async Task Create(Territory territory)
        {
            _context.Territories.Add(territory);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Territory territory = _context.Territories.Find(id);
            if (territory != null)
            {
                _context.Territories.Remove(territory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Territory>> GetAllTerritories()
        {
            return await _context.Territories.ToListAsync();
        }

        public async Task<Territory> GetTerritory(int id)
        {
            return await _context.Territories.FirstOrDefaultAsync(u => u.ID == id);
        }

        public async Task Update(Territory territoryChanges)
        {
            var territory = _context.Territories.Attach(territoryChanges);
            territory.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
