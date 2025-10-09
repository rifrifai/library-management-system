using System;

namespace library_management_system_api.DTOs.Siswa;

public class PatchSiswaDto
{
    public string? Nama { get; set; }
    public int? Umur { get; set; }
    public string? Kelas { get; set; }
    public DateOnly? TanggalDaftar { get; set; }
}
