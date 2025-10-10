using System;
using library_management_system_api.DTOs.Siswa;

namespace library_management_system_api.Services.Interfaces;

public interface ISiswaService
{
    Task<SiswaDto> CreateSiswaAsync(CreateSiswaDto createSiswaDto);
    Task<IEnumerable<SiswaDto>> GetAllSiswasAsync();
    Task<SiswaDto?> GetByIdSiswaAsync(Guid siswaId);
    Task<SiswaDto?> PatchSiswaAsync(Guid siswaId, PatchSiswaDto patchSiswaDto);
    Task<bool> DeleteSiswaAsync(Guid siswaId);
}
