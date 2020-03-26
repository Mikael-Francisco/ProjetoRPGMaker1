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
    public class ItemService : BaseService, IItemService
    {
        IItemRepository _ItemRepository;


        public ItemService(IItemRepository repo)
        {
            this._ItemRepository = repo;
        }
        public async Task Create(Item item)
        {
            List<Error> errors = new List<Error>();

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                base.AddError("Nome", "O nome do item deve ser informado");
            }
            else if (item.Name.Length > 50)
            {
                base.AddError("Nome", "O nome do item deve conter até 50 caracteres");
            }
            base.CheckErrors();
            try
            {
                await _ItemRepository.Create(item);
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
                await _ItemRepository.Delete(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            try
            {
                return await _ItemRepository.GetAllItems();
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }

        public async Task<Item> GetItem(int id)
        {
            try
            {
                return await _ItemRepository.GetItem(id);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }
                
        public async Task Update(Item itemChanges)
        {
            try
            {
                 await _ItemRepository.Update(itemChanges);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador");
            }
        }
    }
}
