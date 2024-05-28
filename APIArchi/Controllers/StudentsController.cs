using Microsoft.AspNetCore.Mvc;
using Castle.Windsor;
using IBuisnessLayer;
using Domaine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuisnessLayer;

namespace APIArchi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {

        private static WindsorContainer InitDependency()
        {
            var container = new WindsorContainer();
            container.Register(Castle.MicroKernel.Registration.Component.For<IStudentBL>().ImplementedBy<StudentBL>());
            return container;
        }

        IStudentBL context = InitDependency().Resolve<IStudentBL>();

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await context.GetStudents().ToListAsync();
            return Ok(students);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await context.GetStudentById(id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            await context.CreateStudent(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if(id != student.Id)
            {
                return BadRequest();
            }

            await context.UpdateStudent(student);
            return NoContent();
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await context.GetStudentById(id);
            if(student == null)
            {
                return NotFound();
            }

            await context.DeleteStudent(student);
            return NoContent();
        }
    }
}
