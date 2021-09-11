
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
    public interface IBankRepository
    {
        public Task<ActionResult<IEnumerable<Bank>>> GetBank();
        public Task<ActionResult<Bank>> GetBank(int id);
        public Task<IActionResult> PutBank(int id, Bank Bank);
        public Task<ActionResult<Bank>> PostBank(Bank Bank);
        public Task<IActionResult> DeleteBank(int id);

    }
    public class BankRepository : IBankRepository
    {
        private readonly GaneshExpensesWebServerContext _context;

        public BankRepository(GaneshExpensesWebServerContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Bank>>> GetBank()
        {
            return await _context.Bank.ToListAsync();
        }

        public async Task<ActionResult<Bank>> GetBank(int id)
        {
            return await _context.Bank.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IActionResult> PutBank(int id, Bank Bank)
        {
            _context.Entry(Bank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankExists(id))
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

        public async Task<ActionResult<Bank>> PostBank(Bank Bank)
        {
            _context.Bank.Add(Bank);

            await _context.SaveChangesAsync();

            return default;
        }

        public async Task<IActionResult> DeleteBank(int id)
        {
            var Bank = await _context.Bank.FindAsync(id);
            if (Bank == null)
            {
                return new NotFoundResult();
            }
            _context.Bank.Remove(Bank);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
        private bool BankExists(int id)
        {
            return _context.Bank.Any(e => e.Id == id);
        }
    }
}
