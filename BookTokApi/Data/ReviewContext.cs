using Microsoft.EntityFrameworkCore;
using BookTokApi.Models;

namespace BookTokApi.Data;

public class ReviewContext : DbContext
{
    public ReviewContext(DbContextOptions<ReviewContext> options)
        : base(options)
    {
    }

    public DbSet<Review> Reviews { get; set; } = null!;
}