public class TaskList
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public static List<TaskList> ActualTaskList { get; set; } = new List<TaskList>();


    public TaskList(int id, string title, DateTime createdAt, DateTime? dueDate = null, bool isCompleted = false)
    {
        Id = id;
        Title = title;
        CreatedAt = createdAt;
        DueDate = dueDate;
        IsCompleted = isCompleted;
    }

    public void AddTask()
    {
        Id = TaskList.ActualTaskList.Count + 1;
        Title = Console.ReadLine() ?? "";
        CreatedAt = DateTime.Now;
        Console.WriteLine("Enter due date (yyyy-mm-dd) or leave blank:");
        DueDate = DateTime.TryParse(Console.ReadLine(), out DateTime dueDate) ? dueDate : null;
        IsCompleted = false;
        TaskList.ActualTaskList.Add(this);
    }

    public void EditTask()
    {
        Console.WriteLine("Enter the ID of the task to edit:");
        if (!int.TryParse(Console.ReadLine() ?? "0", out int id))
        {
            Console.WriteLine("Invalid ID. Please try again.");
            return;
        }
        
        while (true)
        {
            foreach (var task in TaskList.ActualTaskList)
            {
                if (task.Id == id)
                {
                    Console.WriteLine("Enter new title:");
                    string? newTitle = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newTitle))
                    {
                        task.Title = newTitle;
                    }
                    Console.WriteLine("Enter new due date (yyyy-mm-dd) or leave blank:");
                    string? dueDateInput = Console.ReadLine();
                    if (DateTime.TryParse(dueDateInput, out DateTime newDueDate))
                    {
                        task.DueDate = newDueDate;
                    }

                    Console.WriteLine("Are you done editing? (yes/no):");
                    string? isCompletedInput = Console.ReadLine();
                    if (isCompletedInput?.ToLower() == "yes")
                    {
                        return;
                    }
                    else if (isCompletedInput?.ToLower() == "no")
                    {
                        continue;
                    }
                }
            }
        }
    }

    public void DeleteTask()
    {
        Console.WriteLine("Enter the ID of the task to delete:");
        if (!int.TryParse(Console.ReadLine() ?? "0", out int id))
        {
            Console.WriteLine("Invalid ID. Please try again.");
            return;
        }
        foreach (var task in TaskList.ActualTaskList)
        {
            if (task.Id == id)
            {
                TaskList.ActualTaskList.Remove(task);
                Console.WriteLine("Task deleted successfully.");
                return;
            }
        }
        Console.WriteLine("Task not found. Please try again.");
    }

    public void MarkTaskAsCompleted()
    {
        Console.WriteLine("Enter the ID of the task to mark as completed:");
        if (!int.TryParse(Console.ReadLine() ?? "0", out int id))
        {
            Console.WriteLine("Invalid ID. Please try again.");
            return;
        }
        foreach (var task in TaskList.ActualTaskList)
        {
            if (task.Id == id)
            {
                task.IsCompleted = true;
                Console.WriteLine("Task marked as completed.");
                return;
            }
        }
        Console.WriteLine("Task not found. Please try again.");
    }

    public void ViewTasks()
    {
        foreach (var task in TaskList.ActualTaskList)
        {
            Console.WriteLine($"{task.Id}:\t Task: {task.Title}\t Created At: {task.CreatedAt}\t Due Date: {task.DueDate}\t Completed: {task.IsCompleted}");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
        }
    }
}