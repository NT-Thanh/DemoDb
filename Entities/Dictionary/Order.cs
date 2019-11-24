using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int order_id { get; set; }
        public int total_money { get; set; }
        public int store_id { get; set; }
        public int customer_id { get; set; }
    }
}
