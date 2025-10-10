using System;
using AutoMapper;
using library_management_system_api.DTOs.Siswa;
using library_management_system_api.Models;
using library_management_system_api.Repositories.Interfaces;
using library_management_system_api.Services.Interfaces;

namespace library_management_system_api.Services;

public class SiswaService : ISiswaService
{
    private readonly ISiswaRepository _siswaRepo;
    private readonly IMapper _mapper;
    public SiswaService(ISiswaRepository siswaRepo, IMapper mapper)
    {
        _siswaRepo = siswaRepo;
        _mapper = mapper;
    }
    public async Task<SiswaDto> CreateSiswaAsync(CreateSiswaDto createSiswaDto)
    {
        var siswa = _mapper.Map<Siswa>(createSiswaDto);
        await _siswaRepo.CreateAsync(siswa);

        var result = _mapper.Map<SiswaDto>(siswa);
        return result;
    }

    public async Task<IEnumerable<SiswaDto>> GetAllSiswasAsync()
    {
        var siswas = await _siswaRepo.GetAllAsync();
        var result = _mapper.Map<IEnumerable<SiswaDto>>(siswas);
        return result;
    }

    public async Task<SiswaDto?> GetByIdSiswaAsync(Guid siswaId)
    {
        var siswa = await _siswaRepo.GetByIdAsync(siswaId);
        if (siswa is null) return null;

        var result = _mapper.Map<SiswaDto>(siswa);
        return result;
    }

    public async Task<SiswaDto?> PatchSiswaAsync(Guid siswaId, PatchSiswaDto patchSiswaDto)
    {
        var siswa = await _siswaRepo.GetByIdAsync(siswaId);
        if (siswa is null) return null;

        if (patchSiswaDto.Nama != null) siswa.Nama = patchSiswaDto.Nama;
        if (patchSiswaDto.Umur.HasValue) siswa.Umur = patchSiswaDto.Umur.Value;
        if (patchSiswaDto.Kelas != null) siswa.Kelas = patchSiswaDto.Kelas;
        if (patchSiswaDto.TanggalDaftar.HasValue) siswa.TanggalDaftar = patchSiswaDto.TanggalDaftar.Value;

        await _siswaRepo.UpdateAsync(siswa);
        var result = _mapper.Map<SiswaDto>(siswa);
        return result;
    }

    public async Task<bool> DeleteSiswaAsync(Guid siswaId)
    {
        var siswa = await _siswaRepo.GetByIdAsync(siswaId);
        if (siswa is null) return false;

        await _siswaRepo.DeleteAsync(siswa);
        return true;
    }
}
