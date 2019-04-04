using System;
using Microsoft.EntityFrameworkCore;
using TvMaze.Infrastructure.Models;

namespace TvMaze.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Show> Shows { get; set; }
        public DbSet<CastMember> CastMembers { get; set; }
    }
}
