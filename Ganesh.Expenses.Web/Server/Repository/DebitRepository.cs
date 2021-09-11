using Ganesh.Expenses.Web.Server.Data;
using Ganesh.Expenses.Web.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ganesh.Expenses.Web.Server.Repository
{
    public interface IDebitRepository
    {
        public Task<ActionResult<IEnumerable<Debit>>> GetDebit();
        public Task<ActionResult<Debit>> GetDebit(int id);
        public Task<IActionResult> PutDebit(int id, Debit Debit);
        public Task<ActionResult<Debit>> PostDebit(Debit Debit);
        public Task<IActionResult> DeleteDebit(int id);

    }
    public class DebitRepository : IDebitRepository
    {
        private readonly IBankBalanceRepository bankBalanceRepository;
        private readonly GaneshExpensesWebServerContext _context;

        public DebitRepository(GaneshExpensesWebServerContext context, IBankBalanceRepository bankBalanceRepository)
        {
            _context = context;
            this.bankBalanceRepository = bankBalanceRepository;
        }
        public async Task<ActionResult<IEnumerable<Debit>>> GetDebit()
        {
            return await _context.Debit.Include(i => i.IncomeType).Include(a => a.PersonAndRelation).Include(b => b.Bank).ToListAsync();
        }

        public async Task<ActionResult<Debit>> GetDebit(int id)
        {
            return await _context.Debit.Where(i => i.Id == id).Include(i => i.IncomeType).Include(a => a.PersonAndRelation).Include(b => b.Bank).FirstOrDefaultAsync();
        }

        public async Task<IActionResult> PutDebit(int id, Debit Debit)
        {
            _context.Entry(Debit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DebitExists(id))
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

        public async Task<ActionResult<Debit>> PostDebit(Debit debit)
        {
            _context.Debit.Add(debit);

            var result = await _context.SaveChangesAsync();
            if (result != 0)
{
                if (debit.BankId != null && debit.BankId.Value > 0)
                {
                    BankBalance bankBalance = new BankBalance();
                    bankBalance.Balance -= debit.Amount;
                    bankBalance.BankId = debit.BankId;
                    bankBalance.Date = debit.Date;
                    await bankBalanceRepository.PostBankBalance(bankBalance);
                }
            }
            return default;
        }

        public async Task<IActionResult> DeleteDebit(int id)
        {
            var Debit = await _context.Debit.FindAsync(id);
            if (Debit == null)
            {
                return new NotFoundResult();
            }
            _context.Debit.Remove(Debit);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
        private bool DebitExists(int id)
        {
            return _context.Debit.Any(e => e.Id == id);
        }
    }
}
