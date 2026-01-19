using ToDoApp.Core.Models;
using ToDoApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseSqlite("Data Source=C:\\Users\\jadeb\\Documents\\To-Do-Flow\\To-Do-Flow\\ToDoApp.Data\\ToDoDB.db"));


var app = builder.Build();

app.MapGet("/tasks", async (ToDoDbContext db) 
    => await db.ToDoList.ToListAsync());


app.Run();