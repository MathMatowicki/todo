using Microsoft.EntityFrameworkCore;
using Model;
using DTO;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });

});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ToDoDbContext>(options => options.UseInMemoryDatabase($"ToDoDb"));
var app = builder.Build();
app.UseCors("CorsPolicy");
var todos = new List<ToDoItem>();
app.MapGet("/todos", () => todos);

app.MapPost("/todos", (ToDoItemDTO todo) =>
{
    var todoItem = new ToDoItem
    {
        Id = Guid.NewGuid(),
        Title = todo.Title,
        IsDone = todo.IsDone
    };
    todos.Add(todoItem);
    return todo;
});

app.MapPut("/todos/{id}", (Guid id, ToDoItemDTO todo) =>
{
    var item = todos.Find(todo => todo.Id == id);
    if (item == null)
        return Results.NotFound();

    return Results.NoContent();
});

app.MapDelete("/todos/{id}", (Guid id) =>
{
    var item = todos.Find(todo => todo.Id == id);
    if (item == null)
        return Results.NotFound();

    todos.Remove(item);
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

public class ToDoDbContext : DbContext
{
    public DbSet<ToDoItem> Todos { get; set; }

    public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
    {
    }
}