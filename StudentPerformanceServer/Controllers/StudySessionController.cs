using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentPerformanceServer.Data;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentPerformanceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudySessionController : ControllerBase
    {
        private readonly ILogger<StudySessionController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public StudySessionController(ILogger<StudySessionController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }


        // GET: <StudySessionController>
        [HttpGet]
        public IEnumerable<StudySession> Get()
        {
            return _applicationDbContext.StudySessions.ToArray();
        }

        // GET <StudySessionController>/5
        [HttpGet("{id}")]
        public ActionResult<StudySession> Get(int id)
        {
            var session = _applicationDbContext.StudySessions.Find(id);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }

        // GET <StudySessionController>/Student/{studentId}
        [HttpGet("Student/{studentId}")]
        public ActionResult<IEnumerable<StudySession>> GetByStudentId(int studentId)
        {
            var sessions = _applicationDbContext.StudySessions
                .Where(s => s.StudentId == studentId)
                .ToList();

            if (sessions == null)
            {
                return NotFound();
            }
            return Ok(sessions);
        }

        // POST <StudySessionController>
        [HttpPost]
        public ActionResult<StudySession> Post([FromBody] StudySession newSession)
        {
            _applicationDbContext.StudySessions.Add(newSession);
            _applicationDbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = newSession.Id }, newSession);
        }

        // PUT <StudySessionController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StudySession updatedSession)
        {
            if (id != updatedSession.Id)
            {
                return BadRequest();
            }

            _applicationDbContext.Entry(updatedSession).State = EntityState.Modified;
            _applicationDbContext.SaveChanges();
            return NoContent();
        }

        // DELETE <StudySessionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var session = _applicationDbContext.StudySessions.Find(id);
            if (session == null)
            {
                return NotFound();
            }

            _applicationDbContext.StudySessions.Remove(session);
            _applicationDbContext.SaveChanges();
            return NoContent();
        }
    }
}
