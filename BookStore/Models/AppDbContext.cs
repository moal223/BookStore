using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BookStore.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions option) : base(option)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Category)
                .WithMany(c => c.Books)
                .UsingEntity<BookCategory>(
                    j => j
                        .HasOne(bc => bc.Category)
                        .WithMany(c => c.BookCategories)
                        .HasForeignKey(bc => bc.CategoryId),
                    j => j
                        .HasOne(bc => bc.Book)
                        .WithMany(b => b.BookCategory)
                        .HasForeignKey(bc => bc.BookId),
                    j => { 
                        j.HasKey(bc => new { bc.CategoryId, bc.BookId }); 
                    }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book>? Books { get; set; }
        public DbSet<Category>? categories { get; set; }
        public DbSet<BookCategory>? BookCategories { get; set; }
        public DbSet<Cart>? Carts { get; set; }
    }
}
