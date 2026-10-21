using Microsoft.EntityFrameworkCore;
using BookReviews.Models;

namespace BookReviews.Data {
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) 
            : base(options)
            {
            }

        public DbSet<Book> Books { get; set; }
    }
}
