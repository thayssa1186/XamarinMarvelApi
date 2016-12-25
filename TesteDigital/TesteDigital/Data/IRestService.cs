using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDigital
{
    public interface IRestService
    {
        Task<List<Personagem>> RefreshDataAsync();

        Task SaveTodoItemAsync(Personagem item, bool isNewItem);

        Task DeleteTodoItemAsync(string id);
    }
}
