using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using MySql.Data.MySqlClient;

namespace DemoDL
{
    public class MalmartMySqlDL
    {
        public static readonly string connectionString = @"server=localhost;port=3306;database=malmart;user=root;password=12345678";
        public long Get()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(MalmartMySqlDL.connectionString);
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandType = CommandType.Text;
            mySqlConnection.Open();

            mySqlCommand.CommandText = "SELECT * FROM orders";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                var order = new Order();
                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    var fieldName = mySqlDataReader.GetName(i);
                    var fieldValue = mySqlDataReader.GetValue(i);
                    var property = order.GetType().GetProperty(fieldName);
                    if (property != null && fieldValue != DBNull.Value)
                    {
                        property.SetValue(order, fieldValue);
                    }
                }
            }
            mySqlConnection.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public long GetOne(int id)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(MalmartMySqlDL.connectionString);
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandType = CommandType.Text;
            mySqlConnection.Open();

            mySqlCommand.CommandText = "SELECT * FROM orders WHERE orders.order_id = " + id;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            mySqlDataReader.Read();
            var order = new Order();
            for (int i = 0; i < mySqlDataReader.FieldCount; i++)
            {
                var fieldName = mySqlDataReader.GetName(i);
                var fieldValue = mySqlDataReader.GetValue(i);
                var property = order.GetType().GetProperty(fieldName);
                if (property != null && fieldValue != DBNull.Value)
                {
                    property.SetValue(order, fieldValue);
                }
            }

            mySqlConnection.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public long Update()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(MalmartMySqlDL.connectionString);
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandType = CommandType.Text;
            mySqlConnection.Open();

            mySqlCommand.CommandText = "UPDATE orders SET total_money = total_money + 1 WHERE order_id < 1000000";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            mySqlCommand.ExecuteNonQuery();
            stopwatch.Stop();

            mySqlConnection.Close();
            return stopwatch.ElapsedMilliseconds;
        }
        public long UpdateOne(int id)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(MalmartMySqlDL.connectionString);
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandType = CommandType.Text;
            mySqlConnection.Open();

            mySqlCommand.CommandText = "UPDATE orders SET total_money = total_money + 100 WHERE order_id = " + id;


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            mySqlCommand.ExecuteNonQuery();
            stopwatch.Stop();

            mySqlConnection.Close();
            return stopwatch.ElapsedMilliseconds;
        }
        public long Delete(int number)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(MalmartMySqlDL.connectionString);
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandType = CommandType.Text;
            mySqlConnection.Open();

            mySqlCommand.CommandText = "DELETE FROM orders LIMIT " + number;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            mySqlCommand.ExecuteNonQuery();
            stopwatch.Stop();

            mySqlConnection.Close();
            return stopwatch.ElapsedMilliseconds;
        }
        public long DeleteOne(int id)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(MalmartMySqlDL.connectionString);
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandType = CommandType.Text;
            mySqlConnection.Open();

            mySqlCommand.CommandText = "DELETE FROM orders WHERE order_id = " + id;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            mySqlCommand.ExecuteNonQuery();
            stopwatch.Stop();

            mySqlConnection.Close();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
