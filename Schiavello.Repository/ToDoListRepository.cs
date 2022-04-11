using System.Collections.Generic;
using System.Linq;
using Schiavello.Contracts;
using Schiavello.Contracts.Repositories;
using Schiavello.Data;
using Schiavello.Model;
using System.Threading.Tasks;

namespace Schiavello.Repository
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly ISqlExecutionEngine _sqlExecutionEngine;

        public ToDoListRepository(ISchiavelloSqlConnectionSettingsProvider schiavelloSqlConnectionSettingsProvider)
        {
            _sqlExecutionEngine = new SqlExecutionEngine(schiavelloSqlConnectionSettingsProvider.SchiavelloSqlConnectionSettings);
        }

        public async Task CreateTodo(string description, string status)
        {
            var query = @"INSERT INTO todo(description, status) VALUES(@description, @status)";

            await _sqlExecutionEngine.ExecuteNonQueryAsync(query, new
            {
                description,
                status
            });
        }

        public async Task UpdateTodo(int id, string description, string status)
        {
            var query = @"UPDATE todo SET description = @description, status = @status WHERE id = @id";

            await _sqlExecutionEngine.ExecuteNonQueryAsync(query, new
            {
                id,
                description,
                status
            });
        }

        public async Task<IEnumerable<Todo>> GetAllTodo(string status)
        {
            var query = @"SELECT id, description, status FROM todo WHERE status = @status";

            var result = await _sqlExecutionEngine.ExecuteReaderAsync<Todo>(query, new
            {
                status
            });

            return result.ToList();
        }
    }
}