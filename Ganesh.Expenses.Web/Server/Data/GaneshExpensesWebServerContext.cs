using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ganesh.Expenses.Web.Shared;

namespace Ganesh.Expenses.Web.Server.Data
{
    public class GaneshExpensesWebServerContext : DbContext
    {
        public GaneshExpensesWebServerContext (DbContextOptions<GaneshExpensesWebServerContext> options)
            : base(options)
        {
        }

        public DbSet<Ganesh.Expenses.Web.Shared.Bank> Bank { get; set; }

        public DbSet<Ganesh.Expenses.Web.Shared.IncomeType> IncomeType { get; set; }
        public DbSet<Ganesh.Expenses.Web.Shared.Unit> Unit { get; set; }
        public DbSet<Ganesh.Expenses.Web.Shared.Category> Category { get; set; }
    }
}
