using Domaine;
using Domaine.Models;
using IDataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
	public class StudentRepository : IStudentRepository
	{
		// context DB
		private masterContext _context;

		// injection de dépendence par le constructeur
		public StudentRepository() 
		{ 
			_context = masterContext.Instance; // Appelle singleton
		}

		public IQueryable<Student> GetStudents()
		{
			return _context.Student;
		}

		public async Task<Student> CreateStudent(Student student)
		{
			_context.Student.Add(student);

			await _context.SaveChangesAsync();
			return student;
		}

		public void Dispose()
		{
			if(_context != null)
			{
				_context.Dispose();
			}
		}

	}
}
