using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace contacts_app.Services
{
    public interface IConnectionHandlerService
    {
        SQLiteAsyncConnection AsyncConnection { get; }
    }
}
