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
        Console.WriteLine("3. Edit Task");
        Console.WriteLine("4. Delete Task");
        Console.WriteLine("5. Mark a task as completed");
        Console.WriteLine("6. Exit");
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
                newTask.EditTask();
                break;
            case "4":
                newTask.DeleteTask();
                break;
            case "5":
                newTask.MarkTaskAsCompleted();
                break;  
            case "6":
                Console.WriteLine("Exiting the application. Goodbye!");
                return false;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
        return true;
    }
}