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
    public interface ICreditRepository
    {
        public Task<ActionResult<IEnumerable<Credit>>> GetCredit();
        public Task<ActionResult<Credit>> GetCredit(int id);
        public Task<IActionResult> PutCredit(int id, Credit Credit);
        public Task<ActionResult<Credit>> PostCredit(Credit Credit);
        public Task<IActionResult> DeleteCredit(int id);

    }
    public class CreditRepository : ICreditRepository
    {
        private readonly IBankBalanceRepository bankBalanceRepository;
        private readonly GaneshExpensesWebServerContext _context;

        public CreditRepository(GaneshExpensesWebServerContext context, IBankBalanceRepository bankBalanceRepository)
        {
            this.bankBalanceRepository = bankBalanceRepository;
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Credit>>> GetCredit()
        {
            return await _context.Credit.Include(i => i.IncomeType).Include(a => a.PersonAndRelation).Include(b => b.Bank).Include(t=>t.TransactionMode).ToListAsync();
        }

        public async Task<ActionResult<Credit>> GetCredit(int id)
        {
            return await _context.Credit.Where(i => i.Id == id).Include(i => i.IncomeType)
                .Include(a => a.PersonAndRelation).Include(b => b.Bank)
                .Include(t=>t.TransactionMode).FirstOrDefaultAsync();
        }

        public async Task<IActionResult> PutCredit(int id, Credit Credit)
        {
            _context.Entry(Credit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditExists(id))
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

        public async Task<ActionResult<Credit>> PostCredit(Credit credit)
        {
            _context.Credit.Add(credit);

            int result = await _context.SaveChangesAsync();
            if (result != 0)
            {
                if (credit.BankId != null && credit.BankId.Value > 0)
                {
                    BankBalance bankBalance = new BankBalance();
                    bankBalance.Balance += credit.Amount;
                    bankBalance.BankId = credit.BankId;
                    bankBalance.Date = credit.Date;
                    await bankBalanceRepository.PostBankBalance(bankBalance);
                }
            }

            return default;
        }

        public async Task<IActionResult> DeleteCredit(int id)
        {
            var Credit = await _context.Credit.FindAsync(id);
            if (Credit == null)
            {
                return new NotFoundResult();
            }
            _context.Credit.Remove(Credit);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
        private bool CreditExists(int id)
        {
            return _context.Credit.Any(e => e.Id == id);
        }
    }
}
