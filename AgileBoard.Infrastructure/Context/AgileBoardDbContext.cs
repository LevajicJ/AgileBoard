using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileBoard.Domain.Models;


namespace AgileBoard.Infrastructure.Context
{
    public class AgileBoardDbContext : DbContext
    {
        public AgileBoardDbContext(DbContextOptions<AgileBoardDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Board> Board { get; set; }
        public DbSet<BoardUser> BoardUsers { get; set; }
        public DbSet<Column> Column { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Comment> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoardUser>().HasKey(x => new { x.BoardId, x.UserId});
        }

    }
}
