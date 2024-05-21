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
			return View();
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
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: StudentController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			} catch
			{
				return View();
			}
		}

		// GET: StudentController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: StudentController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			} catch
			{
				return View();
			}
		}
	}
}
