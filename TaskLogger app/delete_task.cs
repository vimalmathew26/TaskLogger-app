using System;
using Microsoft.Data.Sqlite;

namespace TaskLogger_app
{
    class DeleteTask
    {
        public static void deleteTask(SqliteConnection connection)
        {
            Console.WriteLine("Deleting a task...");

            Console.Write("Enter the Task ID to delete: ");
            var taskId = Console.ReadLine();

            var deleteCmd = connection.CreateCommand();
            deleteCmd.CommandText = @"
                DELETE FROM Task
                WHERE id = @id;
            ";

            deleteCmd.Parameters.AddWithValue("@id", taskId);

            int affectedRows = deleteCmd.ExecuteNonQuery();

            if (affectedRows > 0)
                Console.WriteLine("Task deleted successfully!");
            else
                Console.WriteLine("No task found with the given ID.");
        }
    }
}
