using System;
using library_management_system_api.Models;
using library_management_system_api.Repositories.Interfaces;

namespace library_management_system_api.Repositories;

public class SiswaRepository : ISiswaRepository
{
    public Task CreateAsync(Siswa siswa)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Siswa>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Siswa?> GetByIdAsync(Guid siswaId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Siswa siswa)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SoftDeleteAsync(Guid siswaId)
    {
        throw new NotImplementedException();
    }
}
