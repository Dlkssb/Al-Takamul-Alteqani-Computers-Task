using DataAccess.ResponseDTOs;
using Microsoft.EntityFrameworkCore;
using Models;


namespace DataAccess.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookResponse> bookResponses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
             .Entity<BookResponse>()
             .ToView("BookAuthorsView");
                 
            modelBuilder.Entity<Book>();
            modelBuilder.Entity<Book>();
            modelBuilder.Entity<Book>();
        }
    }
}

