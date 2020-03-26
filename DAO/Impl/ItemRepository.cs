using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class ItemRepository : IItemRepository
    {
        private RPGContext _context;
        public ItemRepository(RPGContext ctx)
        {
            this._context = ctx;
        }
        public async Task Create(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Item item = _context.Items.Find(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItem(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(u => u.ID == id);
        }

        public async Task Update(Item itemChanges)
        {
            var item = _context.Items.Attach(itemChanges);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
