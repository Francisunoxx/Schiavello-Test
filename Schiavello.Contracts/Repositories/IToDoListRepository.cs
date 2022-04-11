using System.Collections.Generic;
using System.Threading.Tasks;
using Schiavello.Model;

namespace Schiavello.Contracts.Repositories
{
    public interface IToDoListRepository
    {
        Task CreateTodo(string description, string status);
        Task UpdateTodo(int id, string description, string status);
        Task<IEnumerable<Todo>> GetAllTodo(string status);
    }
}