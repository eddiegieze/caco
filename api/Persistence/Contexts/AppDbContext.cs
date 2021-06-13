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
                new Board { Id = 101, Name = "Sprint Team 1" }
            );

            builder.Entity<Column>().ToTable("Columns");
            builder.Entity<Column>().HasKey(p => p.Id);
            builder.Entity<Column>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Column>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Column>().HasMany(p => p.Cards).WithOne(p => p.Column).HasForeignKey(p => p.ColumnId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Column>().HasData
            (
                new Column { Id = 100, Name = "Day 1", BoardId = 100 },
                new Column { Id = 101, Name = "Day 2", BoardId = 100 },
                new Column { Id = 102, Name = "Day 3", BoardId = 100 },
                new Column { Id = 103, Name = "Sprint", BoardId = 101 },
                new Column { Id = 104, Name = "Doing", BoardId = 101 },
                new Column { Id = 105, Name = "Done", BoardId = 101 }
            );

            builder.Entity<Card>().ToTable("Cards");
            builder.Entity<Card>().HasKey(p => p.Id);
            builder.Entity<Card>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Card>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Card>().Property(p => p.Description).HasMaxLength(4000);

            builder.Entity<Card>().HasData
            (
                new Card { Id = 100, Name = "Attending daily", Description = "The only thing I did that day.", ColumnId = 100 },
                new Card { Id = 101, Name = "Create todo app", Description = "We need more todo apps.", ColumnId = 103 },
                new Card { Id = 102, Name = "Write TPS report", Description = "", ColumnId = 104 },
                new Card { Id = 103, Name = "Buy cover sheets", Description = "", ColumnId = 105 },
                new Card { Id = 104, Name = "Read memos", Description = "", ColumnId = 105 },
                new Card { Id = 105, Name = "Buy ping pong table", Description = "", ColumnId = 103 }
            );
        }
    }
}