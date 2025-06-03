using System;
using Microsoft.Data.Sqlite;

namespace TaskLogger_app
{
    class UpdateTask
    {
        public static void updateTask(SqliteConnection connection)
        {
            try
            {
                bool value = ViewTask.viewTask(connection);
                if (!value)
                {
                    return;
                }

                Console.Write("Enter the Task ID to update: ");
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
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while updating task:" + ex.Message);
            }
        }
    }
}
