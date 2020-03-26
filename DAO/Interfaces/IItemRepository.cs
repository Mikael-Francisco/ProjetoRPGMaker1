using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IItemRepository
    {
        Task Create(Item item);
        Task<IEnumerable<Item>> GetAllItems();
        Task Delete(int id);
        Task Update(Item itemChanges);
        Task<Item> GetItem(int id);
    }
}
