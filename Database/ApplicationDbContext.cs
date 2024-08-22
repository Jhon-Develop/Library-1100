using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using library_1100.Models;

namespace library_1100.Controllers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración explícita de las tablas
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<DocumentType>().ToTable("documentTypes");
            modelBuilder.Entity<Role>().ToTable("roles");
            modelBuilder.Entity<Loan>().ToTable("loans");
            modelBuilder.Entity<Book>().ToTable("books");
            modelBuilder.Entity<Category>().ToTable("categories");

            // Configuración de la relación entre User y DocumentType
            modelBuilder.Entity<User>()
                .HasOne(u => u.DocumentType)
                .WithMany(dt => dt.Users)
                .HasForeignKey(u => u.DocumentTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la relación entre User y Role
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la relación entre Book y Category
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la relación entre Loan y User
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.User)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la relación entre Loan y Book
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}