namespace ASP.NET_WebAPI6.Controllers
{
    using ASP.NET_WebAPI6.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class StudentResultController : ControllerBase
    {
        private readonly DBContext _context;

        public StudentResultController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResult>>> GetStudentResults()
        {
            return await _context.StudentResults
                .Include(sr => sr.Student)
                .Include(sr => sr.Result)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResult>> GetStudentResult(int id)
        {
            var studentResult = await _context.StudentResults
                .Include(sr => sr.Student)
                .Include(sr => sr.Result)
                .FirstOrDefaultAsync(sr => sr.StudentId == id);

            if (studentResult == null)
            {
                return NotFound();
            }

            return studentResult;
        }

        [HttpPost]
        public async Task<ActionResult<StudentResult>> PostStudentResult(StudentResult studentResult)
        {
            _context.StudentResults.Add(studentResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentResult), new { id = studentResult.StudentId }, studentResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentResult(int id, StudentResult studentResult)
        {
            if (id != studentResult.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentResultExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentResult(int id)
        {
            var studentResult = await _context.StudentResults.FindAsync(id);
            if (studentResult == null)
            {
                return NotFound();
            }

            _context.StudentResults.Remove(studentResult);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentResultExists(int id)
        {
            return _context.StudentResults.Any(sr => sr.StudentId == id);
        }
    }

}
