﻿using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IClassRepository
    {
        Task Create(Class classes);
        Task<IEnumerable<Class>> GetAllClasses();
        Task Delete(int id);
        Task Update(Class classChanges);
        Task<Class> GetClass(int id);
    }
}
