using RepoDbDemo.Models;
using System.Collections.Generic;

namespace RepoDbDemo.Dal
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
