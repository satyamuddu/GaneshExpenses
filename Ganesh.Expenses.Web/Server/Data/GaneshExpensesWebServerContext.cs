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
        public DbSet<Ganesh.Expenses.Web.Shared.Product> Product { get; set; }
        public DbSet<Ganesh.Expenses.Web.Shared.Income> Income { get; set; }
        public DbSet<Ganesh.Expenses.Web.Shared.TransactionMode> TransactionMode { get; set; }
        public DbSet<Ganesh.Expenses.Web.Shared.RelationType> RelationType { get; set; }
        public DbSet<Ganesh.Expenses.Web.Shared.FamilyGroup> FamilyGroup { get; set; }
        public DbSet<Ganesh.Expenses.Web.Shared.PersonAndRelation> PersonAndRelation { get; set; }
    }
}
