using Domaine.Models;

namespace IBuisnessLayer
{
	public interface IStudentBL : IDisposable
	{
		// Méthode qui renvoit  la liste des étudiants
		IQueryable<Student> GetStudents();

		// Méthode pour créer un étudiant
		Task<Student> CreateStudent(Student student);
	}
}
