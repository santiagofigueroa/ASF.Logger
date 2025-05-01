using ASF.Logger.Models;
using Dapper;
using Npgsql;

namespace ASF.Logger.Services
{
    public class PostgresLogger
    {
        private readonly string _connectionString;

        public PostgresLogger(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Optional sample SQL schema fi we like to write it to the DB.  
        public void LogToDatabase(Entry entry)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            const string sql = @"
            INSERT INTO logs (timestamp, message, severity, username, context, exception)
            VALUES (@Timestamp, @Message, @Severity, @User, @Context, @Exception)";
            conn.Execute(sql, entry);
        }
    }
}
