using System;
using Npgsql;
/////http://zetcode.com/csharp/postgresql/

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = "Host=localhost;Username=user2;Password=123;Database=testdb";
            using var con = new NpgsqlConnection(cs);
            con.Open();

            var sql2 = "SELECT * FROM employee";

            var sql = "SELECT version()";

            using var cmd = new NpgsqlCommand(sql2, con);

            var version = cmd.ExecuteScalar().ToString();
            Console.WriteLine($"PostgreSQL version: {version}");
           

            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("{0} {1} {2}", rdr.GetInt32(0), rdr.GetString(1),
                        rdr.GetString(2));
            }
        }
    }
}
