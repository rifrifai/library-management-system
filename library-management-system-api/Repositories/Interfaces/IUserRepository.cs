using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_management_system_api.Models;

namespace library_management_system_api.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid id);
    Task<List<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}