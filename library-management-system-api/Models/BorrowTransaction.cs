using System;

namespace library_management_system_api.Models;

public class BorrowTransaction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid BookId { get; set; }
    public Guid UserId { get; set; }
    public DateOnly BorrowDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly ReturnDate { get; set; }
    public string Status { get; set; } = "Borrowed";
    public required Book Book { get; set; }
    public required User User { get; set; }
}
