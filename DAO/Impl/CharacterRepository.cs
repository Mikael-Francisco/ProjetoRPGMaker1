using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class CharacterRepository : ICharacterRepository
    {
        private RPGContext _context;
        public CharacterRepository(RPGContext ctx)
        {
            this._context = ctx;
        }
        public async Task Create(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Character character = _context.Characters.Find(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character> GetCharacter(int id)
        {
            return await _context.Characters.FirstOrDefaultAsync(u => u.ID == id);
        }

        public async Task Update(Character characterChanges)
        {
            var character = _context.Characters.Attach(characterChanges);
            character.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
