using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using RepoDb;
using RepoDbDemo.WebApplication1.Models;
using RepoDbDemo.WebApplication1.Options;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RepoDbDemo.WebApplication1.Dal
{
    internal class StudentDal : IStudentDal
    {
        private readonly StudentDalOptions _studentDalOptions;

        public StudentDal(IOptionsMonitor<StudentDalOptions> studentDalOptionsAccessor)
        {
            _studentDalOptions = studentDalOptionsAccessor.CurrentValue;
        }

        IEnumerable<Student> IStudentDal.GetAll()
        {
            using IDbConnection connection = new SqlConnection(_studentDalOptions.ConStr).EnsureOpen();
            return connection.QueryAll<Student>().OrderBy(student => student.Id);
        }

        Student IStudentDal.GetById(int studentId)
        {
            using IDbConnection connection = new SqlConnection(_studentDalOptions.ConStr).EnsureOpen();
            return connection.Query<Student>(student => student.Id == studentId).FirstOrDefault();
        }

        void IStudentDal.Create(Student newStudent)
        {
            using IDbConnection connection = new SqlConnection(_studentDalOptions.ConStr).EnsureOpen();
            connection.Insert<Student>(newStudent);
        }

        void IStudentDal.Update(Student existingStudent)
        {
            using IDbConnection connection = new SqlConnection(_studentDalOptions.ConStr).EnsureOpen();
            connection.Update<Student>(existingStudent);
        }

        void IStudentDal.Delete(Student existingStudent)
        {
            using IDbConnection connection = new SqlConnection(_studentDalOptions.ConStr).EnsureOpen();
            connection.Delete<Student>(existingStudent.Id);
        }
    }
}
