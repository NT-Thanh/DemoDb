using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int student_id { get; set; }
        public string student_name { get; set; }
        public int student_age { get; set; }
        public int class_id { get; set; }
    }
}
