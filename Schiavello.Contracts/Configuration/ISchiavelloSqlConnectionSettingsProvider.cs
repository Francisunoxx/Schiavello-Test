namespace Schiavello.Contracts
{
    public interface ISchiavelloSqlConnectionSettingsProvider
    {
        SchiavelloSqlConnectionSettings SchiavelloSqlConnectionSettings { get; }
    }
}