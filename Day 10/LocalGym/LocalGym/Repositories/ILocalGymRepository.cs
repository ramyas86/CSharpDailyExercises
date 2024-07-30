using System.Collections.Generic;
using System.Threading.Tasks;
using LocalGym.Models;

namespace LocalGym.Repositories
{
    public interface ILocalGymRepository
    {
        Task<IEnumerable<Member>> GetMembersAsync();
        Task<Member> GetMemberAsync(int id);
        Task<IEnumerable<Trainer>> GetTrainersAsync();
        Task<Trainer> GetTrainerAsync(int id);
        Task<IEnumerable<Session>> GetSessionsForTrainerAsync(int id);
        Task<IEnumerable<Session>> GetSessionsForMemberAsync(int id);
        Task<Member> CreateMemberAsync(Member member);
        Task<Member> UpdateMemberAsync(int id, Member member);
    }
}
