using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LocalGym.Models;
using LocalGym.Repositories;

namespace LocalGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
