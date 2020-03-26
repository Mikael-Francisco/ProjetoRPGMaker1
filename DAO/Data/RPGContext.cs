using DTO;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAO
{
    public class RPGContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public RPGContext(DbContextOptions<RPGContext> options) : base(options)
        {

        }

        public DbSet<Race> Races { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Creature> Creatures { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RPGCreated> RPGs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Race>().ToTable("RACES");
            modelBuilder.Entity<Character>().ToTable("CHARACTERS");
            modelBuilder.Entity<Class>().ToTable("CLASSES");
            modelBuilder.Entity<Creature>().ToTable("CREATURES");
            modelBuilder.Entity<Item>().ToTable("ITEMS");
            modelBuilder.Entity<Territory>().ToTable("TERRITORIES");
            modelBuilder.Entity<User>().ToTable("USERS");
            modelBuilder.Entity<RPGCreated>().ToTable("RPGS");
        }

    }
}
