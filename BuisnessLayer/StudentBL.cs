using DataRepository;
using Domaine.Models;
using IBuisnessLayer;
using IDataRepository;

namespace BuisnessLayer
{
	public class StudentBL : IStudentBL
	{
		IStudentRepository _dataFactory;

		public StudentBL(): this(new StudentRepository())
		{
		}

		private StudentBL(IStudentRepository dataFactory)
		{
			_dataFactory = dataFactory;
		}

		public Task<Student> CreateStudent(Student student)
		{
			return _dataFactory.CreateStudent(student);
		}

		public void Dispose()
		{
			if (_dataFactory != null)
			{
				_dataFactory.Dispose();
			}
		}

		public IQueryable<Student> GetStudents()
		{
			return _dataFactory.GetStudents();
		}
	}
}
