using System;
using Microsoft.Data.Sqlite;

namespace TaskLogger_app
{
    class UpdateTask
    {
        public static void updateTask(SqliteConnection connection)
        {
            Console.WriteLine("Updating a task...");

            Console.Write("Enter the Task ID to update: ");
            var taskId = Console.ReadLine();

            Console.Write("Enter new Task Name: ");
            var newName = Console.ReadLine();

            Console.Write("Enter new To-Do List: ");
            var newTodo = Console.ReadLine();

            var updateCmd = connection.CreateCommand();
            updateCmd.CommandText = @"
                UPDATE Task
                SET name = @name, todolist = @todolist
                WHERE id = @id;
            ";

            updateCmd.Parameters.AddWithValue("@name", newName);
            updateCmd.Parameters.AddWithValue("@todolist", newTodo);
            updateCmd.Parameters.AddWithValue("@id", taskId);

            int affectedRows = updateCmd.ExecuteNonQuery();

            if (affectedRows > 0)
                Console.WriteLine("Task updated successfully!");
            else
                Console.WriteLine("No task found with the given ID.");
        }
    }
}
