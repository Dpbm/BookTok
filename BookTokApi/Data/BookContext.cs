using Microsoft.EntityFrameworkCore;
using BookTokApi.Models;

namespace BookTokApi.Data;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;
}