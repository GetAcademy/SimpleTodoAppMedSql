using System.Data.SqlClient;
using Dapper;
using SimpleTodoApp;
using SimpleTodoApp.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
const string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Todo;Integrated Security=True";

app.MapGet("/todo/{id}", TodoService.ReadOne);
app.MapGet("/todo", TodoService.ReadAll);
app.MapPost("/todo", TodoService.Create);
app.MapPut("/todo", TodoService.UpdateDone);
app.MapDelete("/todo/{id}", TodoService.Delete);

//app.MapGet("/todo/{id}", async (Guid id) =>
//{
//    var conn = new SqlConnection(connStr);
//    const string sql = "SELECT Id, Text, Done FROM Todo WHERE Id = @Id";
//    var todoItems = await conn.QueryAsync<TodoItem>(sql, new { Id = id });
//    return todoItems.FirstOrDefault();
//});
//app.MapGet("/todo", async () =>
//{
//    var conn = new SqlConnection(connStr);
//    const string sql = "SELECT Id, Text, Done FROM Todo";
//    var todoItems = await conn.QueryAsync<TodoItem>(sql);
//    return todoItems;
//});
//app.MapPost("/todo", async (TodoItem todoItem) =>
//{
//    var conn = new SqlConnection(connStr);
//    const string sql = "INSERT Todo (Id, Text) VALUES (@Id, @Text)";
//    var rowsAffected = await conn.ExecuteAsync(sql, todoItem);
//    return rowsAffected;
//});
//app.MapPut("/todo", async (TodoItem todoItem) =>
//{
//    todoItem.Done = DateTime.Today;
//    var conn = new SqlConnection(connStr);
//    const string sql = "UPDATE Todo SET Done = @Done WHERE Id = @Id";
//    var rowsAffected = await conn.ExecuteAsync(sql, todoItem);
//    return rowsAffected;
//});
//app.MapDelete("/todo/{id}", async (Guid id) =>
//{
//    var conn = new SqlConnection(connStr);
//    const string sql = "DELETE FROM Todo WHERE Id = @Id";
//    var rowsAffected = await conn.ExecuteAsync(sql, new { Id = id });
//    return rowsAffected;
//});

app.UseStaticFiles();
app.Run();
