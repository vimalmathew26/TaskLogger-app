using System;
using Microsoft.Data.Sqlite;

namespace TaskLogger_app

{
    class ViewTask
{

    public static void viewTask(SqliteConnection connection)
    {
        Console.WriteLine("Viewing tasks:");
        var selectCmd = connection.CreateCommand();
        selectCmd.CommandText = "SELECT * FROM Task;";

        using (var reader = selectCmd.ExecuteReader())
        {
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string todolist = reader.GetString(2);
                Console.WriteLine($"User Id: {id}, Name: {name}");
                Console.WriteLine($"To do List:{todolist}");
            }
        }

    }

}

}

