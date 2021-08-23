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
    public interface IPersonAndRelationRepository
    {
        public Task<ActionResult<IEnumerable<PersonAndRelation>>> GetPersonAndRelation();
        public Task<ActionResult<PersonAndRelation>> GetPersonAndRelation(int id);
        public Task<IActionResult> PutPersonAndRelation(int id, PersonAndRelation PersonAndRelation);
        public Task<ActionResult<PersonAndRelation>> PostPersonAndRelation(PersonAndRelation PersonAndRelation);
        public Task<IActionResult> DeletePersonAndRelation(int id);

    }
    public class PersonAndRelationRepository : IPersonAndRelationRepository
    {
        private readonly GaneshExpensesWebServerContext _context;

        public PersonAndRelationRepository(GaneshExpensesWebServerContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<PersonAndRelation>>> GetPersonAndRelation()
        {
            return await _context.PersonAndRelation.Include(i => i.FamilyGroup).Include(b => b.RelationType).ToListAsync();
        }

        public async Task<ActionResult<PersonAndRelation>> GetPersonAndRelation(int id)
        {
            return await _context.PersonAndRelation.Where(i => i.Id == id).Include(b => b.FamilyGroup).Include(it => it.RelationType).FirstOrDefaultAsync();
        }

        public async Task<IActionResult> PutPersonAndRelation(int id, PersonAndRelation PersonAndRelation)
        {
            _context.Entry(PersonAndRelation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonAndRelationExists(id))
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

        public async Task<ActionResult<PersonAndRelation>> PostPersonAndRelation(PersonAndRelation PersonAndRelation)
        {
            _context.PersonAndRelation.Add(PersonAndRelation);

            await _context.SaveChangesAsync();

            return default;
        }

        public async Task<IActionResult> DeletePersonAndRelation(int id)
        {
            var PersonAndRelation = await _context.PersonAndRelation.FindAsync(id);
            if (PersonAndRelation == null)
            {
                return new NotFoundResult();
            }
            _context.PersonAndRelation.Remove(PersonAndRelation);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
        private bool PersonAndRelationExists(int id)
        {
            return _context.PersonAndRelation.Any(e => e.Id == id);
        }
    }
}
