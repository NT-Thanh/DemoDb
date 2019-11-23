using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace DemoDL
{
    public class StudentSqlDL
    {
        public static readonly string connectionString = @"Data Source=THANH;Initial Catalog=School;Integrated Security=True";
        public long Get()
        {
            SqlConnection sqlConnection = new SqlConnection(StudentSqlDL.connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();

            sqlCommand.CommandText = "SELECT * FROM Student";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var student = new Student();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    var fieldName = sqlDataReader.GetName(i);
                    var fieldValue = sqlDataReader.GetValue(i);
                    var property = student.GetType().GetProperty(fieldName);
                    if (property != null && fieldValue != DBNull.Value)
                    {
                        property.SetValue(student, fieldValue);
                    }
                }
            }
            sqlConnection.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public long GetOne(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(StudentSqlDL.connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();

            sqlCommand.CommandText = "SELECT * FROM Student WHERE Student.student_id = " + id;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();
            var student = new Student();
            for (int i = 0; i < sqlDataReader.FieldCount; i++)
            {
                var fieldName = sqlDataReader.GetName(i);
                var fieldValue = sqlDataReader.GetValue(i);
                var property = student.GetType().GetProperty(fieldName);
                if (property != null && fieldValue != DBNull.Value)
                {
                    property.SetValue(student, fieldValue);
                }
            }

            sqlConnection.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public long Update()
        {
            SqlConnection sqlConnection = new SqlConnection(StudentSqlDL.connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();

            sqlCommand.CommandText = "UPDATE dbo.Student SET class_id = class_id + 1 WHERE student_id < 10000";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            sqlCommand.ExecuteNonQuery();
            stopwatch.Stop();

            sqlConnection.Close();
            return stopwatch.ElapsedMilliseconds;
        }
        public long UpdateOne(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(StudentSqlDL.connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();

            sqlCommand.CommandText = "UPDATE dbo.Student SET class_id = class_id + 1 WHERE student_id = " + id;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            sqlCommand.ExecuteNonQuery();
            stopwatch.Stop();

            sqlConnection.Close();
            return stopwatch.ElapsedMilliseconds;
        }
        public long Delete(int number)
        {
            SqlConnection sqlConnection = new SqlConnection(StudentSqlDL.connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();

            sqlCommand.CommandText = "DELETE TOP (" + number + ") FROM [dbo].[Student]";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            sqlCommand.ExecuteNonQuery();
            stopwatch.Stop();

            sqlConnection.Close();
            return stopwatch.ElapsedMilliseconds;
        }
        public long DeleteOne(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(StudentSqlDL.connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();

            sqlCommand.CommandText = "DELETE FROM [dbo].[Student] WHERE Student.student_id = " + id;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            sqlCommand.ExecuteNonQuery();
            stopwatch.Stop();

            sqlConnection.Close();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
