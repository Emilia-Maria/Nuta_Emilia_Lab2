using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nuta_Emilia_Lab2.Models;

namespace Nuta_Emilia_Lab2.Data
{
    public class Nuta_Emilia_Lab2Context : DbContext
    {
        public Nuta_Emilia_Lab2Context (DbContextOptions<Nuta_Emilia_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Nuta_Emilia_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Nuta_Emilia_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Nuta_Emilia_Lab2.Models.Author>? Author { get; set; }

        public DbSet<Nuta_Emilia_Lab2.Models.Category>? Category { get; set; }

        public DbSet<Nuta_Emilia_Lab2.Models.Member>? Member { get; set; }

        public DbSet<Nuta_Emilia_Lab2.Models.Borrowing>? Borrowing { get; set; }
    }
}
