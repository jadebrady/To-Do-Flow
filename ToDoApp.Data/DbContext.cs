using Microsoft.EntityFrameworkCore;
using ToDoApp.Core.Models;

namespace ToDoApp.Data
{
    public class ToDoDbContext : DbContext
    {   

        public DbSet<TaskList> ToDoList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use your actual database path here
            optionsBuilder.UseSqlite($"Data Source=C:\\Users\\jadeb\\Documents\\To-Do-Flow\\To-Do-Flow\\ToDoApp.Data\\ToDoDB.db");
        }

    }
}