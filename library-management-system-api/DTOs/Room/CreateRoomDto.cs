using System.ComponentModel.DataAnnotations;

namespace library_management_system_api.DTOs.Room;

public record class CreateRoomDto(

    /// <summary>
    /// DTO untuk membuat data kamar baru.
    /// Hanya berisi properti yang dibutuhkan saat pembuatan.
    /// </summary>

    [Required]
    [StringLength(10, ErrorMessage = "Nomor kamar tidak boleh lebih dari 5 karakter!")]
    string RoomName,

    [Required]
    string Type,

    [Range(1, 10, ErrorMessage = "Kapasitas harus antara 1 dan 10!")]
    int Capacity
);
