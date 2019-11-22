using Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDL
{
    public class StudentMongoDL
    {
        private readonly IMongoCollection<Student> _students;
        public StudentMongoDL()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("SchoolDb");

            _students = database.GetCollection<Student>("Students");
        }

        public List<Student> Get() =>
            _students.Find(student => true).ToList();
    }
}
