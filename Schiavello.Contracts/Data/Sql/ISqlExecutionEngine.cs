using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schiavello.Contracts
{
    public interface ISqlExecutionEngine
    {
        Task<int> ExecuteNonQueryAsync(string sqlQuery, object parameters);
        Task<T> ExecuteScalarAsync<T>(string sqlQuery, object parameters);
        Task<IEnumerable<T>> ExecuteReaderAsync<T>(string sqlQuery, object parameters);
    }
}