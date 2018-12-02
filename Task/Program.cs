﻿using System;
using System.Data.SqlClient;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = @"Data Source=.\sqlexpress;Initial Catalog=NORTHWND;Integrated Security=True";

            using (var conn = new SqlConnection(connection))
            {
                conn.Open();

                // *** PART 1 ***

                // Task 2
                Console.WriteLine("Employees from London");
                Execute(conn, @"
                     SELECT FirstName, LastName FROM [Employees] WHERE City = 'London'");

                // Task 5
                Console.WriteLine("Count of Employees from London");
                Execute(conn, @"
                     SELECT COUNT(*) FROM [Employees] WHERE City = 'London'");
                
                // *** PART 2 ***

                // Task 12
                Console.WriteLine("Employees, who celebrate birthday this month");
                Execute(conn, @"
                        SELECT FirstName, LastName, BirthDate
                        FROM [Employees]
                        WHERE month(BirthDate) = month(getdate());
                        ");

                // Task 13
                Console.WriteLine("Employees, who serve orders shipped to Madrid");
                Execute(conn, @"SELECT FirstName, LastName
                        FROM[Employees] LEFT JOIN[Orders]
                        ON[Orders].EmployeeID = [Employees].EmployeeID
                        WHERE [Orders].ShipCity = 'Madrid';");

            }
     
            
        }

        static void Execute(SqlConnection connection, string sql)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                Print(command);
            }
        }

        static void Print(SqlCommand command)
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (var i = 0; i < reader.FieldCount; ++i)
                    {
                        Console.Write("{0}:", reader.GetName(i));
                        Console.WriteLine("  {0}", reader[i]);
                    }
                    Console.WriteLine();
                }
                reader.NextResult();
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
