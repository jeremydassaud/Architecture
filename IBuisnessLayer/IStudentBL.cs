﻿using Domaine.Models;

namespace IBuisnessLayer
{
	public interface IStudentBL : IDisposable
	{
		// Méthode qui renvoit  la liste des étudiants
		IQueryable<Student> GetStudents();

        Task<Student> GetStudentById(int id);

        // Méthode pour créer un étudiant
        Task<Student> CreateStudent(Student student);

		Task<Student> UpdateStudent(Student student);

		Task<Student> DeleteStudent(Student student);
	}
}
