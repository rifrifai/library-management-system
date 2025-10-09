using System;

namespace library_management_system_api.DTOs.Siswa;

public class SiswaDto
{
    public Guid Id { get; set; }
    public string Nama { get; set; } = string.Empty;
    public int Umur { get; set; }
    public string? Kelas { get; set; }
    public DateOnly TanggalDaftar { get; set; }
}
