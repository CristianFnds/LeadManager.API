using LeadManager.Application.Interfaces;
using LeadManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LeadManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeadsController : ControllerBase
    {

        private readonly ILeadService _leadService;
        private readonly ILogger<LeadsController> _logger;

        public LeadsController(ILeadService invitedService, ILogger<LeadsController> logger)
        {
            _leadService = invitedService;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var inviteds = await _leadService.GetAllAsync();
            return Ok(inviteds);
        }

        [HttpGet("inviteds")]
        public async Task<IActionResult> GetAllInvited()
        {
            var inviteds = await _leadService.GetAllInvitedAsync();
            return Ok(inviteds);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invited = await _leadService.GetByIdAsync(id);
            if (invited == null)
                return NotFound();

            return Ok(invited);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Lead invited)
        {
            if (invited == null)
                return BadRequest();

            await _leadService.AddAsync(invited);
            return CreatedAtAction(nameof(GetById), new { id = invited.Id }, invited);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Lead invited)
        {
            if (id != invited.Id)
                return BadRequest();

            await _leadService.UpdateAsync(invited);
            return NoContent();
        }

        [HttpPut("{id}/accept")]
        public async Task<IActionResult> AcceptLead(int id)
        {
            var lead = await _leadService.AcceptLeadAsync(id);
            return Ok(lead);
        }

        [HttpPut("{id}/reject")]
        public async Task<IActionResult> RejectLead(int id)
        {
            var lead = await _leadService.RejectLeadAsync(id);
            return Ok(lead);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _leadService.DeleteAsync(id);
            return NoContent();
        }
    }
}
