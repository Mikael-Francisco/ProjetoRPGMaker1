using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class RPGCreatedRepository : iRPGCreatedRepository
    {
        private RPGContext _context;
        public RPGCreatedRepository(RPGContext ctx)
        {
            this._context = ctx;
        }
        public async Task Create(RPGCreated rpg)
        {
            _context.RPGs.Add(rpg);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            RPGCreated rpg = _context.RPGs.Find(id);
            if (rpg != null)
            {
                _context.RPGs.Remove(rpg);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<RPGCreated>> GetAllRPGs()
        {
            return await _context.RPGs.ToListAsync();
        }

        public async Task<RPGCreated> GetRPG(int id)
        {
            return await _context.RPGs.FirstOrDefaultAsync(u => u.ID == id);
        }

        public async Task Update(RPGCreated RPGChanges)
        {
            var rpg = _context.RPGs.Attach(RPGChanges);
            rpg.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
