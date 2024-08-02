using LocalGym.Models;
using LocalGym.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalGym.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SessionsController : ControllerBase
{
    private readonly ILocalGymRepository _repository;

    public SessionsController(ILocalGymRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Session>>> GetSessions()
    {
        var sessions = await _repository.GetSessionsAsync();
        return Ok(sessions);
    }

    [HttpGet("member/{memberId}")]
    public async Task<ActionResult<IEnumerable<Session>>> GetSessionsForMember(int memberId)
    {
        var sessions = await _repository.GetSessionsForMemberAsync(memberId);
        return Ok(sessions);
    }

    [HttpGet("trainer/{trainerId}")]
    public async Task<ActionResult<IEnumerable<Session>>> GetSessionsForTrainer(int trainerId)
    {
        var sessions = await _repository.GetSessionsForTrainerAsync(trainerId);
        return Ok(sessions);
    }

    [HttpGet("member/{memberId}/trainer/{trainerId}")]
    public async Task<ActionResult<IEnumerable<Session>>> GetSessionsForMemberAndTrainer(int memberId, int trainerId)
    {
        var sessions = await _repository.GetSessionsForMemberAndTrainerAsync(memberId, trainerId);
        return Ok(sessions);
    }
}
