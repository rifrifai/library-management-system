using System;
using library_management_system_api.Models;

namespace library_management_system_api.Repositories.Interfaces;

public interface ISiswaRepository
{
    Task<IEnumerable<Siswa>> GetAllAsync();
    Task<Siswa?> GetByIdAsync(Guid siswaId);
    Task CreateAsync(Siswa siswa);
    Task<bool> UpdateAsync(Siswa siswa);
    Task<bool> DeleteAsync(Guid siswaId);
}
