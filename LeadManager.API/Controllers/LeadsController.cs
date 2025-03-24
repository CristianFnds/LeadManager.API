using LeadManager.Application.Interfaces;
using LeadManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LeadManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeadsController : ControllerBase
    {
        
        private readonly ILeadService _invitedService;
        private readonly ILogger<LeadsController> _logger;

        public LeadsController(ILeadService invitedService, ILogger<LeadsController> logger)
        {
            _invitedService = invitedService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inviteds = await _invitedService.GetAllAsync();
            return Ok(inviteds);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invited = await _invitedService.GetByIdAsync(id);
            if (invited == null)
                return NotFound();

            return Ok(invited);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Lead invited)
        {
            if (invited == null)
                return BadRequest();

            await _invitedService.AddAsync(invited);
            return CreatedAtAction(nameof(GetById), new { id = invited.Id }, invited);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Lead invited)
        {
            if (id != invited.Id)
                return BadRequest();

            await _invitedService.UpdateAsync(invited);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _invitedService.DeleteAsync(id);
            return NoContent();
        }
    }
}
