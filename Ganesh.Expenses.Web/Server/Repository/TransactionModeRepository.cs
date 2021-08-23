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
    public interface ITransactionModeRepository
    {
        public Task<ActionResult<IEnumerable<TransactionMode>>> GetTransactionMode();
        public Task<ActionResult<TransactionMode>> GetTransactionMode(int id);
        public Task<IActionResult> PutTransactionMode(int id, TransactionMode TransactionMode);
        public Task<ActionResult<TransactionMode>> PostTransactionMode(TransactionMode TransactionMode);
        public Task<IActionResult> DeleteTransactionMode(int id);

    }
    public class TransactionModeRepository : ITransactionModeRepository
    {
        private readonly GaneshExpensesWebServerContext _context;

        public TransactionModeRepository(GaneshExpensesWebServerContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<TransactionMode>>> GetTransactionMode()
        {
            return await _context.TransactionMode.ToListAsync();
        }

        public async Task<ActionResult<TransactionMode>> GetTransactionMode(int id)
        {
            return await _context.TransactionMode.FindAsync(id);
        }

        public async Task<IActionResult> PutTransactionMode(int id, TransactionMode TransactionMode)
        {
            _context.Entry(TransactionMode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionModeExists(id))
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

        public async Task<ActionResult<TransactionMode>> PostTransactionMode(TransactionMode TransactionMode)
        {
            _context.TransactionMode.Add(TransactionMode);

            await _context.SaveChangesAsync();

            return default;
        }

        public async Task<IActionResult> DeleteTransactionMode(int id)
        {
            var TransactionMode = await _context.TransactionMode.FindAsync(id);
            if (TransactionMode == null)
            {
                return new NotFoundResult();
            }
            _context.TransactionMode.Remove(TransactionMode);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
        private bool TransactionModeExists(int id)
        {
            return _context.TransactionMode.Any(e => e.Id == id);
        }
    }
}
