using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LocalGym.Data;
using LocalGym.Models;

namespace LocalGym.Repositories
{
    public class LocalGymRepository : ILocalGymRepository
    {
        private readonly LocalGymContext _context;

        public LocalGymRepository(LocalGymContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetMembersAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member> GetMemberAsync(int id)
        {
            return await _context.Members.FindAsync(id);
        }

        public async Task<IEnumerable<Trainer>> GetTrainersAsync()
        {
            return await _context.Trainers.ToListAsync();
        }

        public async Task<Trainer> GetTrainerAsync(int id)
        {
            return await _context.Trainers.FindAsync(id);
        }

        public async Task<IEnumerable<Session>> GetSessionsAsync()
        {
            return await _context.Sessions
                .Include(s => s.Member)
                .Include(s => s.Trainer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Session>> GetSessionsForTrainerAsync(int id)
        {
            return await _context.Sessions
                .Where(s => s.TrainerId == id)
                .Include(s => s.Member)
                .ToListAsync();
        }

        public async Task<IEnumerable<Session>> GetSessionsForMemberAsync(int id)
        {
            return await _context.Sessions
                .Where(s => s.MemberId == id)
                .Include(s => s.Trainer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Session>> GetSessionsForMemberAndTrainerAsync(int memberId, int trainerId)
        {
            return await _context.Sessions
                .Where(s => s.MemberId == memberId && s.TrainerId == trainerId)
                .Include(s => s.Trainer)
                .Include(s => s.Member)
                .ToListAsync();
        }

        public async Task<Member> CreateMemberAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<Member> UpdateMemberAsync(int id, Member member)
        {
            var existingMember = await _context.Members.FindAsync(id);
            if (existingMember == null)
            {
                return null;
            }

            existingMember.FirstName = member.FirstName;
            existingMember.LastName = member.LastName;
            existingMember.Email = member.Email;
            existingMember.JoinDate = member.JoinDate;

            await _context.SaveChangesAsync();
            return existingMember;
        }

        public async Task<Trainer> CreateTrainerAsync(Trainer trainer)
        {
            _context.Trainers.Add(trainer);
            await _context.SaveChangesAsync();
            return trainer;
        }

        public async Task<Trainer> UpdateTrainerAsync(int id, Trainer trainer)
        {
            var existingTrainer = await _context.Trainers.FindAsync(id);
            if (existingTrainer == null)
            {
                return null;
            }

            existingTrainer.FirstName = trainer.FirstName;
            existingTrainer.LastName = trainer.LastName;
            existingTrainer.Speciality = trainer.Speciality;
            existingTrainer.FeePer30Minutes = trainer.FeePer30Minutes;
            existingTrainer.HireDate = trainer.HireDate;

            await _context.SaveChangesAsync();
            return existingTrainer;
        }
    }
}
