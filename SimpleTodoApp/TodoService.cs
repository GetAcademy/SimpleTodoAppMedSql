using System.Data.SqlClient;
using Dapper;
using SimpleTodoApp.Model;

namespace SimpleTodoApp
{
    public class TodoService
    {
        const string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Todo;Integrated Security=True";

        public static async Task<TodoItem> ReadOne(Guid id)
        {
            var conn = new SqlConnection(connStr);
            const string sql = "SELECT Id, Text, Done FROM Todo WHERE Id = @Id";
            var todoItems = await conn.QueryAsync<TodoItem>(sql, new { Id = id });
            return todoItems.FirstOrDefault();
        }

        public static async Task<IEnumerable<TodoItem>> ReadAll()
        {
            var conn = new SqlConnection(connStr);
            const string sql = "SELECT Id, Text, Done FROM Todo";
            var todoItems = await conn.QueryAsync<TodoItem>(sql);
            return todoItems;
        }

        public static async Task<int> Create(TodoItem todoItem)
        {
            var conn = new SqlConnection(connStr);
            const string sql = "INSERT Todo (Id, Text) VALUES (@Id, @Text)";
            var rowsAffected = await conn.ExecuteAsync(sql, todoItem);
            return rowsAffected;
        }

        public static async Task<int> UpdateDone(TodoItem todoItem)
        {
            todoItem.Done = DateTime.Today;
            var conn = new SqlConnection(connStr);
            const string sql = "UPDATE Todo SET Done = @Done WHERE Id = @Id";
            var rowsAffected = await conn.ExecuteAsync(sql, todoItem);
            return rowsAffected;
        }

        public static async Task<int> Delete(TodoItem todoItem)
        {
            var conn = new SqlConnection(connStr);
            const string sql = "DELETE FROM Todo WHERE Id = @Id";
            var rowsAffected = await conn.ExecuteAsync(sql, new { Id = id });
            return rowsAffected;
        }
    }
}
