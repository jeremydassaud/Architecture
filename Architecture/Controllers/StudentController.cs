using BuisnessLayer;
using Castle.Windsor;
using Domaine.Models;
using IBuisnessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Architecture.Controllers
{
	public class StudentController : Controller
	{
		private static WindsorContainer InitDependency()
		{
			var container = new WindsorContainer();
			container.Register(Castle.MicroKernel.Registration.Component.For<IStudentBL>().ImplementedBy<StudentBL>());
			return container;
		}

		IStudentBL context = InitDependency().Resolve<IStudentBL>();

		// GET: StudentController
		public ActionResult Index()
		{
			return View(context.GetStudents().ToList<Student>());
		}

		// GET: StudentController/Details/5
		public ActionResult Details(int id)
		{
            var student = context.GetStudentById(id).Result;
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }

		// GET: StudentController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: StudentController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Student student)
		{
			try
			{
				await context.CreateStudent(student);
				return RedirectToAction(nameof(Index));
			} catch
			{
				return View();
			}
		}

		// GET: StudentController/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
            var student = await context.GetStudentById(id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
		}

		// POST: StudentController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(int id, Student student)
		{
            if(id != student.Id)
            {
                return BadRequest();
            }

            try
			{
                await context.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
			} catch
			{
				return View(student);
			}
		}

		// GET: StudentController/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
            var student = await context.GetStudentById(id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }

		// POST: StudentController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(int id, Student students)
		{
            var student = await context.GetStudentById(id);
            if(student == null)
            {
                return NotFound();
            }

            try
			{
                await context.DeleteStudent(student);
                return RedirectToAction(nameof(Index));
            } catch
			{
				return View(student);
			}
		}
	}
}
