﻿using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Page> Pages { get; set; }
        DbSet<LibraryGroup> LibraryGroups { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Library> Libraries { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
