using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookTok.Models;

    public class BookTokContext : DbContext
    {
        public BookTokContext (DbContextOptions<BookTokContext> options)
            : base(options)
        {
        }

        public DbSet<BookTok.Models.Book> Book { get; set; } = default!;

public DbSet<BookTok.Models.Costumer> Costumer { get; set; }

public DbSet<BookTok.Models.Sale> Sale { get; set; }
    }
