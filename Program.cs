using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ToDoDbContext>(options => options.UseInMemoryDatabase($"ToDoDb"));
var app = builder.Build();
var todos = new List<ToDoItem>();

app.MapGet("/todos", () => todos);

app.MapPost("/todos", (ToDoItem todo) =>
{
    todos.Add(todo);
    return todo;
});

app.MapPut("/todos/{id}", (int id, ToDoItem todo) =>
{
    var index = todos.FindIndex(todo => todo.Id == id);
    if (index == -1)
        return Results.NotFound();

    todos[index] = todo;
    return Results.NoContent();
});

app.MapDelete("/todos/{id}", (int id) =>
{
    var index = todos.FindIndex(todo => todo.Id == id);
    if (index == -1)
    {
        return Results.NotFound();
    }

    todos.RemoveAt(index);
    return Results.NoContent();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();

public class ToDoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsDone { get; set; }
}

public class ToDoDbContext : DbContext
{
    public DbSet<ToDoItem> Todos { get; set; }

    public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
    {
    }
}