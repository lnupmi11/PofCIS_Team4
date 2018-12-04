using System;
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

                // Task 2
                Console.WriteLine("Employees from London");
                Execute(conn, @"
                     SELECT FirstName, LastName FROM [Employees] WHERE City = 'London'");

                // Task 5
                Console.WriteLine("Count of Employees from London");
                Execute(conn, @"
                     SELECT COUNT(*) FROM [Employees] WHERE City = 'London'");

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
				
				// Task 24
                Console.WriteLine("French customers’ names who used to order french products.");
                Execute(conn, @"
                        SELECT [Customers].ContactName FROM [Customers] 
                        INNER JOIN [Orders] ON [Orders].CustomerID = [Customers].CustomerID
                        WHERE [Orders].ShipCountry = 'France' AND [Customers].Country = 'France';
                        ");

                // Task 23
                Console.WriteLine("French customers’ names who used to order non-french products.");
                Execute(conn, @"
                        SELECT [Customers].ContactName FROM [Customers] 
                        INNER JOIN [Orders] ON [Orders].CustomerID = [Customers].CustomerID
                        WHERE [Orders].ShipCountry != 'France' AND [Customers].Country = 'France';
                        ");
		    
		    // * PART 4 *

                // Task 31
                Execute(conn, @"
                            INSERT INTO [Employees] 
                            (LastName, FirstName, BirthDate, HireDate, Address, 
                            City, Country, Notes)
                            VALUES ('Smoliak', 'Andriy', '06.05.1998', '02.12.2017', 'Lyubinska 96/28',
                            'Lviv', 'Ukraine', 'Some notes about A.Smoliak'),
                                   ('Hrytsiv', 'Nazar', '01.08.1998', '05.10.2017', 'G.Washyngton 10/3',
                            'Lviv', 'Ukraine', 'Some notes about N.Hrytsiv'),
                                   ('Romaniv', 'Dmytro', '06.06.1998', '08.10.2018', 'L.Ukrainky 8',
                            'Lviv', 'Ukraine', 'Some notes about D.Romaniv'),
                                   ('Orest', 'Gopiak', '12.13.1997', '09.10.2017', 'Kamenyariv 10',
                            'Lviv', 'Ukraine', 'Some notes about O.Gopiak'),
                                   ('Datskiv', 'Oleg', '03.14.1998', '02.12.2016', 'Lyubinska 102/136',
                            'Lviv', 'Ukraine', 'Some notes about O.Datskiv');
                            ");

                Console.WriteLine("5 inserted Employees");
                Execute(conn, @"Select FirstName, LastName, City from [Employees] Where City = 'Lviv'");

                // Task 35
                Execute(conn, @"
                        DELETE FROM [Employees] WHERE LastName = 'Datskiv';
                        ");
                Console.WriteLine("Recently inserted Employees after delete 1 with LastName 'Datskiv'");
                Execute(conn, @"Select FirstName, LastName, City from [Employees] Where City = 'Lviv'");
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
