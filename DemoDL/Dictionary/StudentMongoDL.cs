using Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public long Get()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _students.Find(student => true).ToList();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public long GetOne(int id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _students.Find(student => student.student_id == id).FirstOrDefault();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public long Update()
        {
            var builders = Builders<Student>.Update;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _students.UpdateOne<Student>(x => x.student_id < 10000, builders.Inc(x => x.class_id, 1));
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public long UpdateOne(int id)
        {
            var builders = Builders<Student>.Update;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _students.UpdateOne<Student>(x => x.student_id == id, builders.Inc(x => x.class_id, 1));
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public long Delete(int number)
        {
            Student student1st = _students.Find(new BsonDocument()).FirstOrDefault();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _students.DeleteMany<Student>(x => x.student_id < (student1st.student_id + 10000));
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public long DeleteOne(int id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _students.DeleteOne(student => student.student_id == id);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
