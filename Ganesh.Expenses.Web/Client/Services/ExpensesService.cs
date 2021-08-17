using Ganesh.Expenses.Web.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Ganesh.Expenses.Web.Client.Services
{
    public interface IExpensesService<T>
    {
        Task<List<T>> GetList(IServiceParameter serviceParameter);
        Task<T> GetItem(int id, IServiceParameter serviceParameter);
        Task<HttpResponseMessage> UpdateItem(int id, T item, IServiceParameter serviceParameter);
        Task<HttpResponseMessage> AddItem(T item, IServiceParameter serviceParameter);
        Task<HttpResponseMessage> DeleteItem(int id, IServiceParameter serviceParameter);
    }
    public class ExpensesService<T> : IExpensesService<T>
    {
        private HttpClient httpClient;

        public ExpensesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddItem(T item, IServiceParameter serviceParameter)
        {
            return await httpClient.PostAsJsonAsync(serviceParameter.AddItem(), item);
        }

        public async Task<HttpResponseMessage> DeleteItem(int id, IServiceParameter serviceParameter)
        {
            return await httpClient.DeleteAsync(serviceParameter.GetDeleteItem(id));
        }

        public async Task<T> GetItem(int id, IServiceParameter serviceParameter)
        {
            return await httpClient.GetFromJsonAsync<T>(serviceParameter.GetItem(id));
        }

        public async Task<List<T>> GetList(IServiceParameter serviceParameter)
        {
            var Categories = new List<T>();

            foreach (T b in await httpClient.GetFromJsonAsync<T[]>(serviceParameter.GetList()))
            {
                Categories.Add(b);
            }
            return Categories;
        }

        public async Task<HttpResponseMessage> UpdateItem(int id, T item, IServiceParameter serviceParameter)
        {
            return await httpClient.PutAsJsonAsync<T>(serviceParameter.GetUpdateItem(id) , item);
        }
    }
}
