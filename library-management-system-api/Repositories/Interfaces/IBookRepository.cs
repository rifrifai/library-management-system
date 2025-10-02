using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_management_system_api.Models;

namespace library_management_system_api.Repositories.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync(string? searchItem);
    Task<Book?> GetByIdAsync(Guid id);
    Task CreateAsync(Book book);
    Task <bool>UpdateAsync(Book book);
    Task <bool>SoftDeleteAsync(Guid id);
}