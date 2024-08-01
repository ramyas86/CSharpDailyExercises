using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LocalGym.Models;
using LocalGym.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace LocalGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MembersController : ControllerBase
    {
        private readonly ILocalGymRepository _repository;

        public MembersController(ILocalGymRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            var members = await _repository.GetMembersAsync();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = await _repository.GetMemberAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        [HttpGet("{id}/sessions")]
        public async Task<ActionResult<IEnumerable<Session>>> GetSessionsForMember(int id)
        {
            var sessions = await _repository.GetSessionsForMemberAsync(id);
            return Ok(sessions);
        }

        [HttpPost]
        public async Task<ActionResult<Member>> CreateMember(Member member)
        {
            var createdMember = await _repository.CreateMemberAsync(member);
            return CreatedAtAction(nameof(GetMember), new { id = createdMember.MemberId }, createdMember);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Member>> UpdateMember(int id, Member member)
        {
            var updatedMember = await _repository.UpdateMemberAsync(id, member);
            if (updatedMember == null)
            {
                return NotFound();
            }

            return Ok(updatedMember);
        }
    }
}
