using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsApp.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
