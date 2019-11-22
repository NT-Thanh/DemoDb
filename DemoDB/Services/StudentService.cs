using DemoDB.Models;
using Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DemoDB.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(ISchoolDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _students = database.GetCollection<Student>(settings.StudentsCollectionName);
        }

        public List<Student> Get() =>
            _students.Find(student => true).ToList();

        //public Student Get(string id) =>
        //    _students.Find<Student>(student => student.student_id == id).FirstOrDefault();

        //public Student Create(Student student)
        //{
        //    _students.InsertOne(student);
        //    return student;
        //}

        //public void Update(string id, Student studentIn) =>
        //    _students.ReplaceOne(student => student.student_id == id, studentIn);

        //public void Remove(Student studentIn) =>
        //    _students.DeleteOne(student => student.student_id == studentIn.student_id);

        //public void Remove(string id) =>
        //    _students.DeleteOne(student => student.student_id == id);
    }
}