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

        public Task<Student> DeleteStudent(Student student)
        {
            return _dataFactory.DeleteStudent(student);
        }

        public void Dispose()
		{
			if (_dataFactory != null)
			{
				_dataFactory.Dispose();
			}
		}

        public Task<Student> GetStudentById(int id)
        {
            return _dataFactory.GetStudentById(id);
        }

        public IQueryable<Student> GetStudents()
		{
			return _dataFactory.GetStudents();
		}

        public Task<Student> UpdateStudent(Student student)
        {
            return _dataFactory.UpdateStudent(student);
        }
    }
}
