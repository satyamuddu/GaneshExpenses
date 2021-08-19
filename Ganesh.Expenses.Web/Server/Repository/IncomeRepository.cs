using Ganesh.Expenses.Web.Server.Data;
using Ganesh.Expenses.Web.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ganesh.Expenses.Web.Server.Repository
{
    public interface IIncomeRepository
    {
        public Task<ActionResult<IEnumerable<Income>>> GetIncome();
        public Task<ActionResult<Income>> GetIncome(int id);
        public Task<IActionResult> PutIncome(int id, Income Income);
        public Task<ActionResult<Income>> PostIncome(Income Income);
        public Task<IActionResult> DeleteIncome(int id);

    }
    public class IncomeRepository : IIncomeRepository
    {
        private readonly GaneshExpensesWebServerContext _context;

        public IncomeRepository(GaneshExpensesWebServerContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Income>>> GetIncome()
        {
            return await _context.Income.Include(i=>i.IncomeType).Include(b=>b.Bank).ToListAsync();
        }

        public async Task<ActionResult<Income>> GetIncome(int id)
        {
            return await _context.Income.Where(i=>i.Id==id).Include(b=>b.Bank).Include(it=>it.IncomeType).FirstOrDefaultAsync();
        }

        public async Task<IActionResult> PutIncome(int id, Income Income)
        {
            _context.Entry(Income).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeExists(id))
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }
            return new NoContentResult();
        }

        public async Task<ActionResult<Income>> PostIncome(Income Income)
        {
            _context.Income.Add(Income);
            
            await _context.SaveChangesAsync();
            
            return default;
        }

        public async Task<IActionResult> DeleteIncome(int id)
        {
            var Income = await _context.Income.FindAsync(id);
            if (Income == null)
            {
                return new NotFoundResult();
            }
            _context.Income.Remove(Income);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
        private bool IncomeExists(int id)
        {
            return _context.Income.Any(e => e.Id == id);
        }
    }
}
