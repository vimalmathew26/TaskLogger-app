using System;
using Microsoft.Data.Sqlite;

namespace TaskLogger_app

{
    class AddTask {
    public static void addTask(SqliteConnection connection)
    {
        Console.WriteLine("Adding task...");
        Console.WriteLine("Enter details of the task: ");
        Console.Write("Enter the Task Name:");
        var taskName = Console.ReadLine();
        Console.Write("Enter to do list of the task:");
        var todoList = Console.ReadLine();

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
}

}

