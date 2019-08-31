using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SQLite;
using Foundation;
using UIKit;

namespace FijiDiscover.iOS
{
    public class DatabaseConnection_iOS : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "FijiDiscover.sqlite";
            string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", dbName);
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }


    }
}