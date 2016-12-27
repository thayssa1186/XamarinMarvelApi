using System;
using TesteDigital;
using Xamarin.Forms;
using TesteDigital.iOS;
using System.IO;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace TesteDigital.iOS
{

    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS()
        {
        }

        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "TesteDigitalSQLite.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);

          
            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}
