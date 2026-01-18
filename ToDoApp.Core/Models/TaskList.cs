using System.Xml.Serialization;
using System.Linq;

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
        Console.WriteLine("\nEnter task:\n");
        Id = TaskList.ActualTaskList.Count + 1;
        Title = Console.ReadLine() ?? "";
        CreatedAt = DateTime.Now;
        Console.WriteLine("Enter due date (yyyy-mm-dd) or leave blank:\n");
        DueDate = DateTime.TryParse(Console.ReadLine(), out DateTime dueDate) ? dueDate : null;
        IsCompleted = false;
        TaskList.ActualTaskList.Add(this);
    }

    public void EditTask()
    {
        if (TaskList.ActualTaskList.Count == 0)
        {
            Console.WriteLine("\nNo tasks available to edit.\n");
            return;
        }
        Console.WriteLine("\nEnter the ID of the task to edit:\n");
        if (!int.TryParse(Console.ReadLine() ?? "0", out int id))
        {
            Console.WriteLine("\nInvalid ID. Please try again.\n");
            return;
        }

        var currentlyEditing = TaskList.ActualTaskList.FirstOrDefault(t => t.Id == id);
        if (currentlyEditing == null)
        {
            Console.WriteLine("\nTask not found. Please try again.\n");
            return;
        }
        bool editing = true;

        while (editing)
        {
            Console.WriteLine($"\nEditing Task ID {currentlyEditing.Id}: {currentlyEditing.Title}\n");
            Console.WriteLine("\nEnter new title (or leave blank to keep current):\n");
            string? newTitle = Console.ReadLine();
            if (!string.IsNullOrEmpty(newTitle))
            {
                currentlyEditing.Title = newTitle;
            }

            Console.WriteLine("\nEnter new due date (yyyy-mm-dd) or leave blank:\n");
            string? dueDateInput = Console.ReadLine();
            if (DateTime.TryParse(dueDateInput, out DateTime newDueDate))
            {
                currentlyEditing.DueDate = newDueDate;
            }

            Console.WriteLine("\nAre you done editing? (yes/no):\n");
            string? isCompletedInput = Console.ReadLine();
            if (isCompletedInput?.ToLower() == "yes")
            {
                editing = false;
                return;
            }
        }

    }

    public void DeleteTask()
    {
        if (TaskList.ActualTaskList.Count == 0)
        {
            Console.WriteLine("\nNo tasks available to delete.\n");
            return;
        }
        Console.WriteLine("\nEnter the ID of the task to delete:\n");
        if (!int.TryParse(Console.ReadLine() ?? "0", out int id))
        {
            Console.WriteLine("\nInvalid ID. Please try again.\n");
            return;
        }
        foreach (var task in TaskList.ActualTaskList)
        {
            if (task.Id == id)
            {
                TaskList.ActualTaskList.Remove(task);
                Console.WriteLine("\nTask deleted successfully.\n");
                return;
            }
        }
        Console.WriteLine("\nTask not found. Please try again.\n");
    }

    public void MarkTaskAsCompleted()
    {
        if (TaskList.ActualTaskList.Count == 0)
        {
            Console.WriteLine("\nNo tasks available to mark as complete.\n");
            return;
        }
        Console.WriteLine("\nEnter the ID of the task to mark as completed:\n");
        if (!int.TryParse(Console.ReadLine() ?? "0", out int id))
        {
            Console.WriteLine("\nInvalid ID. Please try again.\n");
            return;
        }
        foreach (var task in TaskList.ActualTaskList)
        {
            if (task.Id == id)
            {
                task.IsCompleted = true;
                Console.WriteLine("\nTask marked as completed.\n");
                return;
            }
        }
        Console.WriteLine("\nTask not found. Please try again.\n");
    }

    public void ViewTasks()
    {
        if (TaskList.ActualTaskList.Count == 0)
        {
            Console.WriteLine("\nNo tasks available to view.\n");
            return;
        }
        Console.WriteLine("\nAll Tasks:\n");
        foreach (var task in TaskList.ActualTaskList)
        {
            Console.WriteLine($"{task.Id}:\t Task: {task.Title}\t Created At: {task.CreatedAt}\t Due Date: {task.DueDate}\t Completed: {task.IsCompleted}");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
        }
    }

    public void ViewIncompleteTasks()
    {
        if (TaskList.ActualTaskList.Count == 0)
        {
            Console.WriteLine("\nNo tasks available to view.\n");
            return;
        }
        var incompleteTasks = TaskList.ActualTaskList.Where(t => !t.IsCompleted).ToList();
        if (incompleteTasks.Count == 0)
        {
            Console.WriteLine("\nNo incomplete tasks available.\n");
            return;
        }
        Console.WriteLine("\nIncomplete Tasks:\n");
        foreach (var task in incompleteTasks)
        {
            Console.WriteLine($"{task.Id}:\t Task: {task.Title}\t Created At: {task.CreatedAt}\t Due Date: {task.DueDate}\t Completed: {task.IsCompleted}");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
        }
    }
}