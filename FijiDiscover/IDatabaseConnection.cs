using System;
using System.Collections.Generic;
using System.Text;

namespace FijiDiscover
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}

