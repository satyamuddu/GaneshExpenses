using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ganesh.Expenses.Web.Client.Services
{
    public interface IServiceParameter
    {
        string GetList();
        string GetItem(int id);
        string GetDeleteItem(int id);
        string AddItem();
        string GetUpdateItem(int id);
    }
    public class ServiceParameter : IServiceParameter
    {
        private readonly string baseroute;
        public ServiceParameter(string baseroute)
        {
            this.baseroute = baseroute;
        }
        public string GetItem(int id) => $"{baseroute}/{id}";
        public string GetList() => baseroute;
        public string AddItem() => baseroute;
        public string GetDeleteItem(int id) => $"{baseroute}/{id}";
        public string GetUpdateItem(int id) => $"{baseroute}/{id}";
    }
}
