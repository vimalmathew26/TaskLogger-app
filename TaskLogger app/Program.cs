using System;
using Microsoft.Data.Sqlite;

namespace TaskLogger_app
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqliteConnection("Data Source= mydatabase.db"))
            {
                
                connection.Open();

                var createTable = connection.CreateCommand();
                createTable.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Task (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        name TEXT NOT NULL,
                        todolist TEXT NOT NULL
                    );";
                createTable.ExecuteNonQuery();

                while (true)
                {
                    Console.WriteLine("\nPlease select an option:");
                    Console.WriteLine("1. Create a new task");
                    Console.WriteLine("2. View all tasks");
                    Console.WriteLine("3. Update a task");
                    Console.WriteLine("4. Delete a task");
                    Console.WriteLine("5. Exit");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            var addobj = new AddTask();
                            addobj.addTask(connection);
                            break;
                        case "2":
                            var viewobj = new ViewTask();
                            viewobj.viewTask(connection);
                            break;
                        case "3":
                            var updateobj = new UpdateTask();
                            updateobj.updateTask(connection);
                            break;
                        case "4":
                            var deleteobj = new DeleteTask();
                            deleteobj.deleteTask(connection);
                            break;
                        case "5":
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Enter a valid input!");
                            break;
                    }
                }
            }
        }
    }
}