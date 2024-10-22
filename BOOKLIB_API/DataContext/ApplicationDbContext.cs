﻿using DataAccessLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BOOKLIB_API.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Borrower> Borrower { get; set; }
        public DbSet<ReturnRecord> ReturnRecord { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable($"tbl{nameof(User)}");
            builder.Entity<Book>().ToTable($"tbl{nameof(Book)}");
            builder.Entity<Borrower>().ToTable($"tbl{nameof(Borrower)}");
            builder.Entity<ReturnRecord>().ToTable($"tbl{nameof(ReturnRecord)}");
            builder.Entity<User>().Property(u => u.CustomerId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        }
    }
}
