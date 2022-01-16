using SQLite;

namespace contacts_app.Services
{
    public class ConnectionHandlerService : IConnectionHandlerService
    {
        public SQLiteAsyncConnection AsyncConnection { get; }

        public ConnectionHandlerService()
        {
            AsyncConnection = new SQLiteAsyncConnection(DbConfigurationVariables.DatabaseLocation, DbConfigurationVariables.OperationsAllowed);
        }
    }
}
