using Ganesh.Expenses.Web.Shared;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
/// <summary>
/// This is obsolate, instead use the generic Service "ExpenseService" and "SerivceParameter".
/// </summary>
/// 
namespace Ganesh.Expenses.Web.Client.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> Categories();
        Task<Category> GetCategory(int id);
        Task<HttpResponseMessage> UpdateCategory(Category category);

    }
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient httpClient;

        public CategoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Category>> Categories()
        {
            var Categories = new List<Category>();

            foreach (Category b in await httpClient.GetFromJsonAsync<Category[]>("api/categories"))
            {
                Categories.Add(b);
            }
            return Categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            return await httpClient.GetFromJsonAsync<Category>($"api/categories/{id}");
        }

        public async Task<HttpResponseMessage> UpdateCategory(Category category)
        {
            return await httpClient.PutAsJsonAsync<Category>($"api/categories/{Convert.ToInt32(category.Id)}", category);
        }
    }
}
