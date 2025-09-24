using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_management_system_api.Models;
using Microsoft.EntityFrameworkCore;

namespace library_management_system_api.Data;

public class LibraryContext(DbContextOptions<LibraryContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<BorrowTransaction> BorrowTransactions => Set<BorrowTransaction>();
}