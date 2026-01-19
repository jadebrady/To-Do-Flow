namespace ToDoApp.Core.Models
{
    public class Menu
    {

        public static void DisplayHeader()
        {
            Console.WriteLine("======= To-Do App =======");
        }
        public static bool DisplayMainMenu()
        {
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. View Incomplete Tasks");
            Console.WriteLine("4. Edit Task");
            Console.WriteLine("5. Delete Task");
            Console.WriteLine("6. Mark a task as completed");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            string? choice = Console.ReadLine();

            TaskList? newTask = new TaskList(0, "", DateTime.Now);
            switch (choice)
            {
                case "1":
                    newTask.AddTask();
                    break;
                case "2":
                    newTask.ViewTasks();
                    break;
                case "3":
                    newTask.ViewIncompleteTasks();
                    break;
                case "4":
                    newTask.EditTask();
                    break;
                case "5":
                    newTask.DeleteTask();
                    break;
                case "6":
                    newTask.MarkTaskAsCompleted();
                    break;
                case "7":
                    Console.WriteLine("Exiting the application. Goodbye!");
                    return false;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            return true;
        }
    }
}