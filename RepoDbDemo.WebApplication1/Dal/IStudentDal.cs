using RepoDbDemo.WebApplication1.Models;
using System.Collections.Generic;

namespace RepoDbDemo.WebApplication1.Dal
{
    public interface IStudentDal
    {
        IEnumerable<Student> GetAll();
        Student GetById(int studentId);
        void Create(Student newStudent);
        void Update(Student existingStudent);
        void Delete(Student existingStudent);
    }
}
