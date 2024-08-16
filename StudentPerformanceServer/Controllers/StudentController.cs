using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentPerformanceServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentPerformanceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ApplicationDbContext applicationDbContext, ILogger<StudentController> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        // GET: api/Student
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return Ok(_applicationDbContext.Student.ToArray());
        }

        // GET api/Student/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var student = _applicationDbContext.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST api/Student
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student newStudent)
        {
            try
            {
                _applicationDbContext.Student.Add(newStudent);
                _applicationDbContext.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = newStudent.Id }, newStudent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating student");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/Student/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student updatedStudent)
        {
            if (id != updatedStudent.Id)
            {
                return BadRequest();
            }

            try
            {
                _applicationDbContext.Entry(updatedStudent).State = EntityState.Modified;
                _applicationDbContext.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating student");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/Student/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _applicationDbContext.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            try
            {
                _applicationDbContext.Student.Remove(student);
                _applicationDbContext.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting student");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
