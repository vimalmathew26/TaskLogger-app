using System;
using Microsoft.Data.Sqlite;

namespace TaskLogger_app

{
    class AddTask
    {
        public void addTask(SqliteConnection connection)
        {
            try
            {
                Console.WriteLine("Enter details of the task: ");
                Console.Write("Enter the Task Name:");
                var taskName = Console.ReadLine();
                while (string.IsNullOrEmpty(taskName))
                {
                    Console.WriteLine("Please enter valid Task name!");
                    taskName = Console.ReadLine();
                }
                Console.Write("Enter to do list of the task:");
                var todoList = Console.ReadLine();
                while (string.IsNullOrEmpty(todoList)) {
                    Console.WriteLine("Please enter valid to do list!");
                    todoList = Console.ReadLine();
                }

                var insertTable = connection.CreateCommand();
                insertTable.CommandText = @"
            INSERT INTO Task (name,todolist)
            VALUES (@name, @todolist);
        ";

                insertTable.Parameters.AddWithValue("@name", taskName);
                insertTable.Parameters.AddWithValue("@todolist", todoList);
                insertTable.ExecuteNonQuery();

                Console.WriteLine("Task added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while adding task:" + ex.Message);
            }
        }
    }

}

