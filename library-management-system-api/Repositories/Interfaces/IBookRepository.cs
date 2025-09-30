using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_management_system_api.Models;

namespace library_management_system_api.Repositories.Interfaces;

public interface IBookRepository
{
    Task<Book?> GetByIdAsync(Guid id);
    Task<List<Book>> GetAllAsync();
    Task AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task SoftDeleteAsync(Guid id);
}