using Microsoft.AspNetCore.Mvc;
using StudySessionManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakManagement.Controllers
{
    [Route("api/StudySession/[controller]")]
    [ApiController]
    public class BreakController : ControllerBase
    {
        private readonly ApiService _apiService;

        public BreakController()
        {
            //_apiService = new ApiService("https://studentperformanceserver20240729083736.azurewebsites.net/"); // Server API base address
            _apiService = new ApiService("https://localhost:44369/"); // Server API base address
        }

        // GET: api/Break
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BreakModel>>> Get()
        {
            var breaks = await _apiService.GetBreaksAsync();
            return Ok(breaks);
        }

        // GET api/Break/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BreakModel>> Get(int id)
        {
            var breakEntity = await _apiService.GetBreakByIdAsync(id);
            if (breakEntity == null)
            {
                return NotFound();
            }
            return Ok(breakEntity);
        }

        // GET api/Break/session/5
        [HttpGet("session/{id}")]
        public async Task<ActionResult<IEnumerable<BreakModel>>> GetByStudySessionId(int id)
        {
            var breaks = await _apiService.GetBreaksByStudySessionIdAsync(id);
            if (breaks == null || breaks.Count == 0)
            {
                return NotFound();
            }
            return Ok(breaks);
        }

        // POST api/Break
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BreakModel breakModel)
        {
            await _apiService.CreateBreakAsync(breakModel);
            return NoContent();
        }

        // PUT api/Break/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BreakModel breakModel)
        {
            await _apiService.UpdateBreakAsync(id, breakModel);
            return NoContent();
        }

        // DELETE api/Break/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _apiService.DeleteBreakAsync(id);
            return NoContent();
        }
    }
}
