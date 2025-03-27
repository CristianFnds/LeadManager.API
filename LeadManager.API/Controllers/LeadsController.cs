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

        public LeadsController(ILeadService leadService, ILogger<LeadsController> logger)
        {
            _leadService = leadService;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var leads = await _leadService.GetAllAsync();
            return Ok(leads);
        }

        [HttpGet("inviteds")]
        public async Task<IActionResult> GetAllInvited()
        {
            var inviteds = await _leadService.GetAllInvitedAsync();
            return Ok(inviteds);
        }

        [HttpGet("accepteds")]
        public async Task<IActionResult> GetAllAccepteds()
        {
            var accepteds = await _leadService.GetAllAcceptedsAsync();
            return Ok(accepteds);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lead = await _leadService.GetByIdAsync(id);
            if (lead == null)
                return NotFound();

            return Ok(lead);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Lead lead)
        {
            if (lead == null)
                return BadRequest();

            await _leadService.AddAsync(lead);
            return CreatedAtAction(nameof(GetById), new { id = lead.Id }, lead);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Lead lead)
        {
            if (id != lead.Id)
                return BadRequest();

            await _leadService.UpdateAsync(lead);
            return NoContent();
        }

        [HttpPut("{id}/accept")]
        public async Task<IActionResult> AcceptLead(int id)
        {
            var lead = await _leadService.GetByIdAsync(id);

            if (lead == null)
            {
                return NotFound();
            }

            await _leadService.AcceptLeadAsync(lead);

            return NoContent();
        }

        [HttpPut("{id}/reject")]
        public async Task<IActionResult> RejectLead(int id)
        {
            var lead = await _leadService.GetByIdAsync(id);

            if (lead == null)
            {
                return NotFound();
            }

            await _leadService.RejectLeadAsync(lead);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _leadService.DeleteAsync(id);
            return NoContent();
        }
    }
}
