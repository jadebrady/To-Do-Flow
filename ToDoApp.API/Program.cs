// simple Main menu to run console app
using ToDoApp.Core.Models;
using ToDoApp.Data;

namespace ToDoApp.API
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleApp app = new ConsoleApp();
            app.Run();

            // Uncomment below to test database connection
            
            // using var db = new ToDoDbContext();

            // var tasks = db.ToDoList.ToList();

            // foreach (var task in tasks)
            // {
            //     Console.WriteLine($"{task.Id} - {task.Title}");
            // }

        }
    }
}

