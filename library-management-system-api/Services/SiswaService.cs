using System;
using library_management_system_api.DTOs.Siswa;
using library_management_system_api.Repositories.Interfaces;
using library_management_system_api.Services.Interfaces;

namespace library_management_system_api.Services;

public class SiswaService : ISiswaService
{
    private readonly ISiswaRepository _siswaRepo;
    public SiswaService(ISiswaRepository siswaRepo)
    {
        _siswaRepo = siswaRepo;
    }
    public Task<SiswaDto> CreateSiswaAsync(CreateSiswaDto createSiswaDto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SiswaDto>> GetAllSiswasAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SiswaDto?> GetByIdSiswaAsync(Guid siswaId)
    {
        throw new NotImplementedException();
    }

    public Task<SiswaDto?> PatchSiswaAsync(Guid siswaId, PatchSiswaDto patchSiswaDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteSiswaAsync(Guid siswaId)
    {
        throw new NotImplementedException();
    }
}
