using Caco.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Caco.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Card> Cards { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Board>().ToTable("Boards");
            builder.Entity<Board>().HasKey(p => p.Id);
            builder.Entity<Board>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Board>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Board>().HasMany(p => p.Columns).WithOne(p => p.Board).HasForeignKey(p => p.BoardId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Board>().HasData
            (
                new Board { Id = 100, Name = "Dailies" },
                new Board { Id = 101, Name = "Sprint Rocket" }
            );

            builder.Entity<Column>().ToTable("Columns");
            builder.Entity<Column>().HasKey(p => p.Id);
            builder.Entity<Column>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Column>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Column>().HasMany(p => p.Cards).WithOne(p => p.Column).HasForeignKey(p => p.ColumnId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Column>().HasData
            (
                new Column { Id = 100, Name = "Inbox", BoardId = 100 },
                new Column { Id = 101, Name = "Backlog", BoardId = 101 }
            );

            builder.Entity<Card>().ToTable("Cards");
            builder.Entity<Card>().HasKey(p => p.Id);
            builder.Entity<Card>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Card>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Card>().Property(p => p.Description).HasMaxLength(4000);

            builder.Entity<Card>().HasData
            (
                new Card { Id = 100, Name = "My first card", Description = "I like cards.", ColumnId = 100 },
                new Card { Id = 101, Name = "Add more", Description = "One card isn't enough.", ColumnId = 101 }
            );
        }
    }
}