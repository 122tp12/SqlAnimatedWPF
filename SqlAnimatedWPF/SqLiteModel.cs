using System.Data.Common;
using System;
using System.Data.SQLite;
using SqlAnimatedWPF.Models;
using System.Collections.Generic;

namespace SqlAnimatedWPF
{
    public class SqLiteModel
    {
        SQLiteConnection connection;
        public SqLiteModel()
        {
            SQLiteConnection.CreateFile(".db");

            string connectionString = "Data Source=MyDatabase.sqlite;Version=3;";
            connection = new SQLiteConnection(connectionString);

            connection.Open();
            string sql = "CREATE TABLE \"comment\" (\"id\" INTEGER,\"applicationName\" TEXT,\"userName\" TEXT,\"comment\" TEXT, PRIMARY KEY(\"id\" AUTOINCREMENT));";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }
        public int Insert(string appName, string userName, string comment)
        {
            string sql = "INSERT INTO \"comment\" (\"applicationName\", \"userName\", \"comment\") VALUES ('"+appName+"', '"+userName+"', '"+comment+"');";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            return command.ExecuteNonQuery();
        }
        public List<CommentDto> selectAll()
        {
            string sql = "SELECT * FROM \"comment\"";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<CommentDto> list= new List<CommentDto>();
            while (reader.Read())
            {
                list.Add(new CommentDto(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString()));
            }
            return list;
        }
        public void Close()
        {
            connection.Close();
        }
        ~SqLiteModel()
        {
            connection.Close();
        }
    }
}
