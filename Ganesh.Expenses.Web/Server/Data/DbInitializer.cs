using Ganesh.Expenses.Web.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ganesh.Expenses.Web.Server.Data
{
    public class DbInitializer
    {
        public static void Initialize(GaneshExpensesWebServerContext context)
        {
            context.Database.EnsureCreated();
            if (context.Bank.Any())
            {
                return;
            }
            var banks = new Bank[]
            {
                new Bank{ AccountNumber ="111", Branch="aaa", IFSC="a1", Name="aaa"},
                new Bank{ AccountNumber ="222", Branch="bbb", IFSC="a2", Name="ab"},
                new Bank{ AccountNumber ="333", Branch="ccc", IFSC="a3", Name="ac"},
                new Bank{ AccountNumber ="444", Branch="ddd", IFSC="a4", Name="ad"},
            };
            foreach (var bank in banks)
            {
                context.Bank.Add(bank);
            }
            context.SaveChanges();
        }
    }
}
