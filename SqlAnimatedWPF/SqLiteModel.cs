using System.Data.SQLite;

namespace SqlAnimatedWPF
{
    public class SqLiteModel
    {
        public SqLiteModel()
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");

            string connectionString = "Data Source=MyDatabase.sqlite;Version=3;";
            SQLiteConnection m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();

            string sql = "CREATE TABLE \"comment\" (\"id\" INTEGER,\"applicationName\" TEXT,\"userName\" TEXT,\"comment\" TEXT, PRIMARY KEY(\"id\" AUTOINCREMENT));";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            

            m_dbConnection.Close();
        }
    }
}
