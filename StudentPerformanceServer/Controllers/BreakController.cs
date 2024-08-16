using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPerformanceServer.Data;
using System.Collections.Generic;
using System.Linq;

namespace StudentPerformanceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BreakController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BreakController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // GET: break
        [HttpGet]
        public ActionResult<IEnumerable<Break>> Get()
        {
            return Ok(_applicationDbContext.Break.ToArray());
        }

        // GET break/5
        [HttpGet("{id}")]
        public ActionResult<Break> Get(int id)
        {
            var breakEntity = _applicationDbContext.Break.Find(id);
            if (breakEntity == null)
            {
                return NotFound();
            }
            return Ok(breakEntity);
        }

        // GET: break/session/5
        [HttpGet("session/{studySessionId}")]
        public ActionResult<IEnumerable<Break>> GetByStudySessionId(int studySessionId)
        {
            var breaks = _applicationDbContext.Break.Where(b => b.StudySessionId == studySessionId).ToArray();
            if (breaks == null || breaks.Length == 0)
            {
                return NotFound();
            }
            return Ok(breaks);
        }

        // POST break
        [HttpPost]
        public ActionResult<Break> Post([FromBody] Break newBreak)
        {
            _applicationDbContext.Break.Add(newBreak);
            _applicationDbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = newBreak.Id }, newBreak);
        }

        // PUT break/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Break updatedBreak)
        {
            if (id != updatedBreak.Id)
            {
                return BadRequest();
            }

            _applicationDbContext.Entry(updatedBreak).State = EntityState.Modified;
            _applicationDbContext.SaveChanges();
            return NoContent();
        }

        // DELETE break/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var breakEntity = _applicationDbContext.Break.Find(id);
            if (breakEntity == null)
            {
                return NotFound();
            }

            _applicationDbContext.Break.Remove(breakEntity);
            _applicationDbContext.SaveChanges();
            return NoContent();
        }
    }
}
