using System.Collections.Generic;
using System.Reflection.Emit;
using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.DB
{
    public sealed class Lab3Context : DbContext
    {
        public DbSet<Equation> EqList { get; set; }

        public Lab3Context(DbContextOptions<Lab3Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equation>().HasKey(c => c.number);
        }
    }
}