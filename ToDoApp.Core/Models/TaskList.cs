using System.Xml.Serialization;
using System.Linq;
using ToDoApp.Data;

namespace ToDoApp.Core.Models
{

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
            using var db = new ToDoDbContext();
            Console.WriteLine("\nEnter task:\n");
            Title = Console.ReadLine() ?? "";
            CreatedAt = DateTime.Now;
            Console.WriteLine("Enter due date (yyyy-mm-dd) or leave blank:\n");
            DueDate = DateTime.TryParse(Console.ReadLine(), out DateTime dueDate) ? dueDate : null;
            IsCompleted = false;
            db.Add(this);
            db.SaveChanges();
        }

        public void EditTask()
        {
            using var db = new ToDoDbContext();
            if (db.ToDoList.Count() == 0)
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

            var currentlyEditing = db.ToDoList.FirstOrDefault(t => t.Id == id);
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
                    db.SaveChanges();
                    return;
                }
            }

        }

        public void DeleteTask()
        {
            using var db = new ToDoDbContext();
            if (db.ToDoList.Count() == 0)
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
            foreach (var task in db.ToDoList)
            {
                if (task.Id == id)
                {
                    db.ToDoList.Remove(task);
                    db.SaveChanges();
                    Console.WriteLine("\nTask deleted successfully.\n");
                    return;
                }
            }
            Console.WriteLine("\nTask not found. Please try again.\n");
        }

        public void MarkTaskAsCompleted()
        {
            using var db = new ToDoDbContext();
            if (db.ToDoList.Count() == 0)
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
            foreach (var task in db.ToDoList)
            {
                if (task.Id == id)
                {
                    task.IsCompleted = true;
                    Console.WriteLine("\nTask marked as completed.\n");
                    db.SaveChanges();
                    return;
                }
            }
            Console.WriteLine("\nTask not found. Please try again.\n");
        }

        public void ViewTasks()
        {
            using var db = new ToDoDbContext();
            if (db.ToDoList.Count() == 0)
            {
                Console.WriteLine("\nNo tasks available to view.\n");
                return;
            }
            Console.WriteLine("\nAll Tasks:\n");
            foreach (var task in db.ToDoList)
            {
                Console.WriteLine($"{task.Id}:\t Task: {task.Title}\t Created At: {task.CreatedAt}\t Due Date: {task.DueDate}\t Completed: {task.IsCompleted}");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            }
        }

        public void ViewIncompleteTasks()
        {
            using var db = new ToDoDbContext();
            if (db.ToDoList.Count() == 0)
            {
                Console.WriteLine("\nNo tasks available to view.\n");
                return;
            }
            var incompleteTasks = db.ToDoList.Where(t => !t.IsCompleted).ToList();
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
}