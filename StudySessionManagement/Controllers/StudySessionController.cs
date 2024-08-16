using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudySessionManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudySessionController : ControllerBase
    {
        private readonly ApiService _apiService;

        public StudySessionController()
        {
            _apiService = new ApiService("https://localhost:44369"); // Server API base address
        }

        // GET: api/StudySession
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudySessionModel>>> Get()
        {
            var sessions = await _apiService.GetSessionsAsync();
            return Ok(sessions);
        }

        // GET api/StudySession/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudySessionModel>> Get(int id)
        {
            var session = await _apiService.GetSessionByIdAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }

        // GET api/StudySession/Student/5
        [HttpGet("Student/{studentId}")]
        public async Task<ActionResult<IEnumerable<StudySessionModel>>> GetByStudentId(int studentId)
        {
            var sessions = await _apiService.GetSessionsByStudentIdAsync(studentId);

            if (sessions == null)
            {
                return NotFound();
            }

            return Ok(sessions);
        }

        // POST api/StudySession
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudySessionModel session)
        {
            await _apiService.CreateSessionAsync(session);
            return NoContent();
        }

        // PUT api/StudySession/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StudySessionModel session)
        {
            await _apiService.UpdateSessionAsync(id, session);
            return NoContent();
        }

        // DELETE api/StudySession/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _apiService.DeleteSessionAsync(id);
            return NoContent();
        }
    }
}
