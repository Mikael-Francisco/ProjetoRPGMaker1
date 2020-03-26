using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICharacterService
    {
        Task Create(Character character);
        Task<IEnumerable<Character>> GetAllCharacters();
        Task Delete(int id);
        Task Update(Character characterChanges);
        Task<Character> GetCharacter(int id);
    }
}
