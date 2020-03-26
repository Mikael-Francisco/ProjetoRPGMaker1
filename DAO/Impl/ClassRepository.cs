using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class ClassRepository : IClassRepository
    {
        private RPGContext _context;
        public ClassRepository(RPGContext ctx)
        {
            this._context = ctx;
        }
        public async Task Create(Class classes)
        {
            _context.Classes.Add(classes);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Class classes = _context.Classes.Find(id);
            if (classes != null)
            {
                _context.Classes.Remove(classes);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Class>> GetAllClasses()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class> GetClass(int id)
        {
            return await _context.Classes.FirstOrDefaultAsync(u => u.ID == id);
        }

        public async Task Update(Class classChanges)
        {
            var classes = _context.Classes.Attach(classChanges);
            classes.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
