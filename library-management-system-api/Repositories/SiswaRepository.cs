using System;
using library_management_system_api.Data;
using library_management_system_api.Models;
using library_management_system_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace library_management_system_api.Repositories;

public class SiswaRepository : ISiswaRepository
{
    private readonly LibraryContext _context;
    public SiswaRepository(LibraryContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Siswa siswa)
    {
        await _context.Siswas.AddAsync(siswa);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Siswa>> GetAllAsync()
    {
        var siswas = await _context.Siswas.AsNoTracking().ToListAsync();
        return siswas;
    }

    public async Task<Siswa?> GetByIdAsync(Guid siswaId)
    {
        var siswa = await _context.Siswas.FirstOrDefaultAsync(s => s.Id == siswaId);
        return siswa;
    }

    public async Task<bool> UpdateAsync(Siswa siswa)
    {
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Siswa siswa)
    {
        _context.Siswas.Remove(siswa);
        await _context.SaveChangesAsync();
        return true;
    }
}
