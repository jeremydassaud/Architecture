using Domaine;
using Domaine.Models;
using IDataRepository;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Student> UpdateStudent(Student student)
        {
            var existingStudent = await _context.Student.FindAsync(student.Id);
            if(existingStudent != null)
            {
                _context.Entry(existingStudent).State = EntityState.Detached;
            }

            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudent(Student student)
        {
            var existingStudent = await _context.Student.FindAsync(student.Id);
            if(existingStudent != null)
            {
                _context.Entry(existingStudent).State = EntityState.Detached;
            }

            _context.Entry(student).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _context.Student.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
