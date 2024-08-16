using Microsoft.AspNetCore.Mvc;
using StudySessionManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgressManagement.Controllers
{
    [Route("api/StudySession/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly ApiService _apiService;

        public ProgressController()
        {
            _apiService = new ApiService("https://localhost:44369"); // Server API base address
        }

        // GET: api/Progress
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgressModel>>> Get()
        {
            var progresses = await _apiService.GetProgressesAsync();
            return Ok(progresses);
        }

        // GET api/Progress/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgressModel>> Get(int id)
        {
            var progressEntity = await _apiService.GetProgressByIdAsync(id);
            if (progressEntity == null)
            {
                return NotFound();
            }
            return Ok(progressEntity);
        }

        // GET api/Progress/session/5
        [HttpGet("session/{id}")]
        public async Task<ActionResult<IEnumerable<ProgressModel>>> GetByStudySessionId(int id)
        {
            var progresses = await _apiService.GetProgressesByStudySessionIdAsync(id);
            if (progresses == null || progresses.Count == 0)
            {
                return NotFound();
            }
            return Ok(progresses);
        }

        // POST api/Progress
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProgressModel progressModel)
        {
            await _apiService.CreateProgressAsync(progressModel);
            return NoContent();
        }

        // PUT api/Progress/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProgressModel progressModel)
        {
            await _apiService.UpdateProgressAsync(id, progressModel);
            return NoContent();
        }

        // DELETE api/Progress/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _apiService.DeleteProgressAsync(id);
            return NoContent();
        }
    }
}
