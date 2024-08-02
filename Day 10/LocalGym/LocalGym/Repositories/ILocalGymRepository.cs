using LocalGym.Models;

namespace LocalGym.Repositories;

public interface ILocalGymRepository
{
    Task<IEnumerable<Member>> GetMembersAsync();
    Task<Member> GetMemberAsync(int id);
    Task<IEnumerable<Trainer>> GetTrainersAsync();
    Task<Trainer> GetTrainerAsync(int id);
    Task<IEnumerable<Session>> GetSessionsAsync();
    Task<IEnumerable<Session>> GetSessionsForTrainerAsync(int id);
    Task<IEnumerable<Session>> GetSessionsForMemberAsync(int id);
    Task<IEnumerable<Session>> GetSessionsForMemberAndTrainerAsync(int memberId, int trainerId);
    Task<Member> CreateMemberAsync(Member member);
    Task<Member> UpdateMemberAsync(int id, Member member);
    Task<Trainer> CreateTrainerAsync(Trainer trainer);
    Task<Trainer> UpdateTrainerAsync(int id, Trainer trainer);
}
