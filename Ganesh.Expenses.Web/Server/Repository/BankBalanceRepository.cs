
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
    public interface IBankBalanceRepository
    {
        public Task<ActionResult<IEnumerable<BankBalance>>> GetBankBalance();
        public Task<ActionResult<BankBalance>> GetBankBalance(int id);
        public Task<IActionResult> PutBankBalance(int id, BankBalance BankBalance);
        public Task<ActionResult<BankBalance>> PostBankBalance(BankBalance BankBalance);
        public Task<IActionResult> DeleteBankBalance(int id);
    }
    public class BankBalanceRepository : IBankBalanceRepository
    {
        private readonly GaneshExpensesWebServerContext _context;

        public BankBalanceRepository(GaneshExpensesWebServerContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<BankBalance>>> GetBankBalance()
        {
            return await _context.BankBalance.Include(b => b.Bank).ToListAsync();
        }

        public async Task<ActionResult<BankBalance>> GetBankBalance(int id)
        {
            return await _context.BankBalance.Where(i => i.Id == id).Include(b => b.Bank).FirstOrDefaultAsync();
        }

        public async Task<IActionResult> PutBankBalance(int id, BankBalance BankBalance)
        {
            _context.Entry(BankBalance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankBalanceExists(id))
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

        public async Task<ActionResult<BankBalance>> PostBankBalance(BankBalance BankBalance)
        {
            _context.BankBalance.Add(BankBalance);

            await _context.SaveChangesAsync();

            return default;
        }

        public async Task<IActionResult> DeleteBankBalance(int id)
        {
            var BankBalance = await _context.BankBalance.FindAsync(id);
            if (BankBalance == null)
            {
                return new NotFoundResult();
            }
            _context.BankBalance.Remove(BankBalance);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
        private bool BankBalanceExists(int id)
        {
            return _context.BankBalance.Any(e => e.Id == id);
        }
    }
}
