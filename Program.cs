using System;
using Npgsql;
/////http://zetcode.com/csharp/postgresql/
namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = "Host=localhost;Username=user2;Password=123;Database=users";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            var sql2 = "SELECT * FROM users";
            var sql = "SELECT version()";
            using var cmd = new NpgsqlCommand(sql2, con);
            using var versioncmd = new NpgsqlCommand(sql, con);
            var version = versioncmd.ExecuteScalar().ToString();
            Console.WriteLine($"PostgreSQL version: {version}");
            using NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                Console.WriteLine("{0} {1} ", rdr.GetString(0), rdr.GetString(1));
            
        }
    }
}
