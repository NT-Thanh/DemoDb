using Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DemoDL
{
    public class OrderMongoDL
    {
        private readonly IMongoCollection<Order> _orders;
        public OrderMongoDL()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("malmart");

            _orders = database.GetCollection<Order>("orders");
        }

        public long Get()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _orders.Find(order => true).ToList();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public long GetOne(int id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _orders.Find(order => order.order_id == id).FirstOrDefault();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public long Update()
        {
            var builders = Builders<Order>.Update;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _orders.UpdateOne<Order>(x => x.order_id < 10000, builders.Inc(x => x.total_money, 1));
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public long UpdateOne(int id)
        {
            var builders = Builders<Order>.Update;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _orders.UpdateOne<Order>(x => x.order_id == id, builders.Inc(x => x.total_money, 1000));
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public long Delete(int number)
        {
            Order order1st = _orders.Find(new BsonDocument()).FirstOrDefault();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _orders.DeleteMany<Order>(x => x.order_id < (order1st.order_id + number));
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public long DeleteOne(int id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _orders.DeleteOne(order => (order.order_id) == id);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
