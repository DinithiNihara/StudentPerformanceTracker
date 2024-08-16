using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentPerformanceServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentPerformanceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<SubjectController> _logger;

        public SubjectController(ApplicationDbContext applicationDbContext, ILogger<SubjectController> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        // GET: api/Subject
        [HttpGet]
        public ActionResult<IEnumerable<Subject>> Get()
        {
            return Ok(_applicationDbContext.Subject.ToArray());
        }

        // GET api/Subject/5
        [HttpGet("{id}")]
        public ActionResult<Subject> Get(int id)
        {
            var subject = _applicationDbContext.Subject.Find(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        // GET: api/Subject/Student/5
        [HttpGet("Student/{studentId}")]
        public ActionResult<IEnumerable<Subject>> GetSubjectsByStudentId(int studentId)
        {
            var subjects = _applicationDbContext.Subject
                .Where(s => s.StudentId == studentId)
                .ToArray();

            if (subjects == null || subjects.Length == 0)
            {
                return NotFound();
            }

            return Ok(subjects);
        }

        // POST api/Subject
        [HttpPost]
        public ActionResult<Subject> Post([FromBody] Subject newSubject)
        {
            try
            {
                _applicationDbContext.Subject.Add(newSubject);
                _applicationDbContext.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = newSubject.Id }, newSubject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating subject");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/Subject/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Subject updatedSubject)
        {
            if (id != updatedSubject.Id)
            {
                return BadRequest();
            }

            try
            {
                _applicationDbContext.Entry(updatedSubject).State = EntityState.Modified;
                _applicationDbContext.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating subject");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/Subject/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var subject = _applicationDbContext.Subject.Find(id);
            if (subject == null)
            {
                return NotFound();
            }

            try
            {
                _applicationDbContext.Subject.Remove(subject);
                _applicationDbContext.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting subject");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
