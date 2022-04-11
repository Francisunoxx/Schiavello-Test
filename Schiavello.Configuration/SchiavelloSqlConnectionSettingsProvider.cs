using Microsoft.Extensions.Options;
using Schiavello.Contracts;

namespace Schiavello.Configuration
{
    public class SchiavelloSqlConnectionSettingsProvider : ISchiavelloSqlConnectionSettingsProvider
    {
        public SchiavelloSqlConnectionSettingsProvider(IOptions<SchiavelloSqlConnectionSettings> schiavelloSqlConnectionSettings)
        {
            SchiavelloSqlConnectionSettings = schiavelloSqlConnectionSettings.Value;
        }
        public SchiavelloSqlConnectionSettings SchiavelloSqlConnectionSettings { get; }
    }
}