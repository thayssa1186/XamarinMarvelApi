using SQLite;

namespace TesteDigital
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
