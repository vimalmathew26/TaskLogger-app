using System;
using Microsoft.Data.Sqlite;

namespace TaskLogger_app

{
    class ViewTask
{

    public bool viewTask(SqliteConnection connection)
    {
            try
            {
                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT * FROM Task;";

                using (var reader = selectCmd.ExecuteReader())
                {
                    int count = 0;
                    while (reader.Read())
                    {
                        count++;
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string todolist = reader.GetString(2);
                        Console.WriteLine($"User Id: {id}");
                        Console.WriteLine($"Name: {name}");
                        Console.WriteLine($"To do List:{todolist}");

                    }
                    if (count == 0)
                    {
                        Console.WriteLine("No tasks found.");
                        return false;
                    }
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while viewing task:" + ex.Message);
                return false;
            }

    }
}
}

