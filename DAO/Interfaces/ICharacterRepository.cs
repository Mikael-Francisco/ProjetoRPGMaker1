using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface ICharacterRepository
    {
        Task Create(Character character);
        Task<IEnumerable<Character>> GetAllCharacters();
        Task Delete(int id);
        Task Update(Character characterChanges);
        Task<Character> GetCharacter(int id);
    }
}
