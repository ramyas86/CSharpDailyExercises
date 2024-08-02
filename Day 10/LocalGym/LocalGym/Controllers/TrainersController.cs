using LocalGym.Models;
using LocalGym.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalGym.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TrainersController : ControllerBase
{
    private readonly ILocalGymRepository _repository;

    public TrainersController(ILocalGymRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainers()
    {
        var trainers = await _repository.GetTrainersAsync();
        return Ok(trainers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Trainer>> GetTrainer(int id)
    {
        var trainer = await _repository.GetTrainerAsync(id);

        if (trainer == null)
        {
            return NotFound();
        }

        return Ok(trainer);
    }

    [HttpGet("{id}/sessions")]
    public async Task<ActionResult<IEnumerable<Session>>> GetSessionsForTrainer(int id)
    {
        var sessions = await _repository.GetSessionsForTrainerAsync(id);
        return Ok(sessions);
    }

    [HttpPost]
    public async Task<ActionResult<Trainer>> CreateTrainer(Trainer trainer)
    {
        var createdTrainer = await _repository.CreateTrainerAsync(trainer);
        return CreatedAtAction(nameof(GetTrainer), new { id = createdTrainer.TrainerId }, createdTrainer);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Trainer>> UpdateTrainer(int id, Trainer trainer)
    {
        var updatedTrainer = await _repository.UpdateTrainerAsync(id, trainer);
        if (updatedTrainer == null)
        {
            return NotFound();
        }

        return Ok(updatedTrainer);
    }
}
