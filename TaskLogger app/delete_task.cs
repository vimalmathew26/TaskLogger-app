using System;
using Microsoft.Data.Sqlite;

namespace TaskLogger_app
{
    class DeleteTask
    {
        public void deleteTask(SqliteConnection connection)
        {
            try
            {
                bool value=ViewTask.viewTask(connection);
                if (!value)
                {
                    return;
                }
                Console.Write("Enter the Task ID to delete: ");
                var taskId = Console.ReadLine();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = @"SELECT * FROM Task where id= @taskId;";
                selectCmd.Parameters.AddWithValue("@taskId", taskId);

                using (var reader = selectCmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        Console.WriteLine("No tasks found with the specified id. Please try again!");
                        return;
                    }
                }

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
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while deleting task:" + ex.Message);
            }
        }
    }
}
