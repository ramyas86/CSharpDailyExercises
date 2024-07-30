using System;
using Microsoft.EntityFrameworkCore;
using LocalGym.Models;

namespace LocalGym.Data
{
    public class LocalGymContext : DbContext
    {
        public LocalGymContext(DbContextOptions<LocalGymContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Member>().HasData(
                new Member { MemberId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", JoinDate = DateTime.Now },
                new Member { MemberId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", JoinDate = DateTime.Now }
            );

            modelBuilder.Entity<Trainer>().HasData(
                new Trainer { TrainerId = 1, FirstName = "Alice", LastName = "Johnson", Speciality = "Yoga", FeePer30Minutes = 20m, HireDate = DateTime.Now },
                new Trainer { TrainerId = 2, FirstName = "Bob", LastName = "Brown", Speciality = "Weightlifting", FeePer30Minutes = 25m, HireDate = DateTime.Now }
            );

            modelBuilder.Entity<Session>().HasData(
                new Session { SessionId = 1, MemberId = 1, TrainerId = 1, SessionDate = DateTime.Now, Duration = 60 },
                new Session { SessionId = 2, MemberId = 2, TrainerId = 2, SessionDate = DateTime.Now, Duration = 30 }
            );
        }
    }
}
