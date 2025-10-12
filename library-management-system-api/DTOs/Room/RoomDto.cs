namespace library_management_system_api.DTOs.Room;

public record class RoomDto(

    /// <summary>
    /// DTO yang merepresentasikan data kamar untuk ditampilkan ke client.
    /// Berisi data lengkap yang aman untuk diekspos.
    /// </summary>

    Guid Id,
    string RoomName,
    string Type,
    int Capacity,
    bool IsAvailable,
    DateTime CreatedAt
);
