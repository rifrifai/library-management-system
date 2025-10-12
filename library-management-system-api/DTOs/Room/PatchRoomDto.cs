using System.ComponentModel.DataAnnotations;

namespace library_management_system_api.DTOs.Room;

public record class PatchRoomDto(

    /// <summary>
    /// DTO untuk melakukan pembaruan parsial (PATCH).
    /// Semua properti dibuat nullable (?) untuk menandakan properti mana yang ingin diubah.
    /// Jika sebuah properti bernilai null, artinya properti tersebut tidak diubah.
    /// </summary>

    [StringLength(10)]
    string? RoomName,

    string? Type,

    [Range(1, 10)]
    int? Capacity,

    bool? IsAvailable
);
