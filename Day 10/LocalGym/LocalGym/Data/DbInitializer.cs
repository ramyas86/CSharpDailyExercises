using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LocalGym.Models;

namespace LocalGym.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LocalGymContext context)
        {
            context.Database.Migrate();

            // Look for any members.
            if (context.Members.Any())
            {
                return;   // DB has been seeded
            }

            var members = new Member[]
            {
                new Member { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", JoinDate = DateTime.Now },
                new Member { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", JoinDate = DateTime.Now },
            };
            foreach (var m in members)
            {
                context.Members.Add(m);
            }
            context.SaveChanges();

            var trainers = new Trainer[]
            {
                new Trainer { FirstName = "Alice", LastName = "Johnson", Speciality = "Yoga", FeePer30Minutes = 20m, HireDate = DateTime.Now },
                new Trainer { FirstName = "Bob", LastName = "Brown", Speciality = "Weightlifting", FeePer30Minutes = 25m, HireDate = DateTime.Now },
            };
            foreach (var t in trainers)
            {
                context.Trainers.Add(t);
            }
            context.SaveChanges();

            var sessions = new Session[]
            {
                new Session { MemberId = members[0].MemberId, TrainerId = trainers[0].TrainerId, SessionDate = DateTime.Now, Duration = 60 },
                new Session { MemberId = members[1].MemberId, TrainerId = trainers[1].TrainerId, SessionDate = DateTime.Now, Duration = 30 },
            };
            foreach (var s in sessions)
            {
                context.Sessions.Add(s);
            }
            context.SaveChanges();
        }
    }
}
