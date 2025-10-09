using System;

namespace library_management_system_api.Models;

public class Siswa
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Nama { get; set; }
    public int Umur { get; set; }
    public string? Kelas { get; set; }
    public DateOnly TanggalDaftar { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
}
