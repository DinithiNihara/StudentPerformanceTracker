using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPerformanceServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentPerformanceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProgressController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // GET: api/Progress
        [HttpGet]
        public ActionResult<IEnumerable<Progress>> Get()
        {
            return Ok(_applicationDbContext.Progress.ToArray());
        }

        // GET api/Progress/5
        [HttpGet("{id}")]
        public ActionResult<Progress> Get(int id)
        {
            var progressEntity = _applicationDbContext.Progress.Find(id);
            if (progressEntity == null)
            {
                return NotFound();
            }
            return Ok(progressEntity);
        }

        // GET: progress/session/5
        [HttpGet("session/{studySessionId}")]
        public ActionResult<IEnumerable<Progress>> GetByStudySessionId(int studySessionId)
        {
            var progresses = _applicationDbContext.Progress.Where(p => p.StudySessionId == studySessionId).ToArray();
            if (progresses == null || progresses.Length == 0)
            {
                return NotFound();
            }
            return Ok(progresses);
        }

        // POST api/Progress
        [HttpPost]
        public ActionResult<Progress> Post([FromBody] Progress newProgress)
        {
            _applicationDbContext.Progress.Add(newProgress);
            Console.WriteLine(newProgress.Id);
            Console.WriteLine(newProgress.ToString());
            _applicationDbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = newProgress.Id }, newProgress);
        }

        // PUT api/Progress/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Progress updatedProgress)
        {
            if (id != updatedProgress.Id)
            {
                return BadRequest();
            }

            _applicationDbContext.Entry(updatedProgress).State = EntityState.Modified;
            _applicationDbContext.SaveChanges();
            return NoContent();
        }

        // DELETE api/Progress/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var progressEntity = _applicationDbContext.Progress.Find(id);
            if (progressEntity == null)
            {
                return NotFound();
            }

            _applicationDbContext.Progress.Remove(progressEntity);
            _applicationDbContext.SaveChanges();
            return NoContent();
        }
    }
}
