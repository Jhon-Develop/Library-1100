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

            // Ejemplo de mapeo explícito de columnas
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");
                entity.Property(e => e.DocumentNumber).HasColumnName("document_number");
                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
                entity.Property(e => e.RoleId).HasColumnName("role_id");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.Author).HasColumnName("author");
                entity.Property(e => e.Isbn).HasColumnName("isbn");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.Avalibility).HasColumnName("avalibility");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("category");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.BookId).HasColumnName("book_id");
                entity.Property(e => e.LoanStartDate).HasColumnName("loan_start_date");
                entity.Property(e => e.LoanEndDate).HasColumnName("loan_end_date");
            });
        }

    }
}