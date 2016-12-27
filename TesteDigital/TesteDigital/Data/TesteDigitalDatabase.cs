using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDigital
{
    public class TesteDigitalDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TesteDigitalDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);          

        }

        public async Task<bool> CreateTable()
        {
            try
            {
                database.CreateTableAsync<PersonagemEN>().Wait();
                database.CreateTableAsync<FasciculoEN>().Wait();
                database.CreateTableAsync<SincronizacaoEN>().Wait();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        public Task<List<PersonagemEN>> GetPersonagensAsync()
        {
            var result = database.Table<PersonagemEN>().ToListAsync();
            return result;
        }

        public Task<SincronizacaoEN> GetSincronizacaoAsync()
        {
            var result = database.Table<SincronizacaoEN>().OrderByDescending(t => t.data).FirstOrDefaultAsync();
            return result;
        }

        /*public Task<List<Personagem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Personagem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<Personagem> GetItemAsync(int id)
        {
            return database.Table<Personagem>().Where(i => i.id == id.ToString()).FirstOrDefaultAsync();
        }*/

        public Task<List<FasciculoEN>> GetFasciculosAsync()
        {
            var result = database.Table<FasciculoEN>().ToListAsync();
            return result;
        }

        public Task<int> SavePersonagemAsync(PersonagemEN item)
        {       
            return database.InsertAsync(item);        
        }

        public Task<int> SaveFasciculosAsync(FasciculoEN item)
        {
            return database.InsertAsync(item);
        }

        public Task<int> SaveDataSync()
        {
            var sync = new SincronizacaoEN();
            sync.data = DateTime.Now;

            return database.InsertAsync(sync);
        }

        public Task<int> DeletePersonagemAsync(PersonagemEN item)
        {
            return database.DeleteAsync(item);
        }

        public Task<int> DropTablePersonagemAsync()
        {
            return database.DropTableAsync<PersonagemEN>();
        }

        public Task<int> DropTableFasciculosAsync()
        {
            return database.DropTableAsync<FasciculoEN>();
        }
    }
}
