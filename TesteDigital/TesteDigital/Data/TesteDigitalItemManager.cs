
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDigital;

namespace TodoREST
{
    public class TesteDigitalItemManager
    {
        IRestService restService;

        public TesteDigitalItemManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Personagem>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(Personagem item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }

        public Task DeleteTaskAsync(Personagem item)
        {
            return restService.DeleteTodoItemAsync(item.ID);
        }
    }
}
