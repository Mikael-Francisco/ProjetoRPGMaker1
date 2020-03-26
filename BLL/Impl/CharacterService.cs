using BLL.Interfaces;
using Common;
using DAO;
using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class CharacterService : BaseService, ICharacterService
    {
        ICharacterRepository _CharacterRepository;

        public CharacterService(ICharacterRepository repo)
        {
            this._CharacterRepository = repo;
        }
        public async Task Create(Character character)
        {
            List<Error> errors = new List<Error>();

            if (string.IsNullOrWhiteSpace(character.Name))
            {
                base.AddError("Nome", "O nome do personagem deve ser informado");
            }
            else if (character.Name.Length > 50)
            {
                base.AddError("Nome", "O nome do personagem deve conter até 50 caracteres");
            }
            if (character.Age <= 0)
            {
                base.AddError("Idade", "A idade do personagem deve ser informada");
            }
            if (character.Height <= 0)
            {
                base.AddError("Altura", "A altura do personagem deve ser informada");
            }

            base.CheckErrors();
            try
            {

                await _CharacterRepository.Create(character);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o admnistrador.");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
               await _CharacterRepository.Delete(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            try
            {
               return await _CharacterRepository.GetAllCharacters();
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<Character> GetCharacter(int id)
        {
            try
            {
               return await _CharacterRepository.GetCharacter(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task Update(Character characterChanges)
        {
            try
            {
               await _CharacterRepository.Update(characterChanges);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }
    }
}
