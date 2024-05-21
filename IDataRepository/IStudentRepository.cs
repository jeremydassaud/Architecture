using Domaine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataRepository
{
	public interface IStudentRepository : IDisposable // Pattern de gestion de la mémoire
	{
		// Méthode qui renvoit  la liste des étudiants
		IQueryable<Student> GetStudents();

		// Méthode pour créer un étudiant
		Task<Student> CreateStudent(Student student);
	}
}