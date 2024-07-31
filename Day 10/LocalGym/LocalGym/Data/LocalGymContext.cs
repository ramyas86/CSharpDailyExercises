using Microsoft.EntityFrameworkCore;
using LocalGym.Models;

namespace LocalGym.Data
{
    public class LocalGymContext : DbContext
    {
        public LocalGymContext(DbContextOptions<LocalGymContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Member>()
                .HasMany(m => m.Sessions)
                .WithOne(s => s.Member)
                .HasForeignKey(s => s.MemberId);

            modelBuilder.Entity<Trainer>()
                .HasMany(t => t.Sessions)
                .WithOne(s => s.Trainer)
                .HasForeignKey(s => s.TrainerId);
        }
    }
}
