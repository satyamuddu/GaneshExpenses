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
    public interface IRelationTypeRepository
    {
        public Task<ActionResult<IEnumerable<RelationType>>> GetRelationType();
        public Task<ActionResult<RelationType>> GetRelationType(int id);
        public Task<IActionResult> PutRelationType(int id, RelationType RelationType);
        public Task<ActionResult<RelationType>> PostRelationType(RelationType RelationType);
        public Task<IActionResult> DeleteRelationType(int id);

    }
    public class RelationTypeRepository : IRelationTypeRepository
    {
        private readonly GaneshExpensesWebServerContext _context;

        public RelationTypeRepository(GaneshExpensesWebServerContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<RelationType>>> GetRelationType()
        {
            return await _context.RelationType.ToListAsync();
        }

        public async Task<ActionResult<RelationType>> GetRelationType(int id)
        {
            return await _context.RelationType.FindAsync(id);
        }

        public async Task<IActionResult> PutRelationType(int id, RelationType RelationType)
        {
            _context.Entry(RelationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelationTypeExists(id))
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

        public async Task<ActionResult<RelationType>> PostRelationType(RelationType RelationType)
        {
            _context.RelationType.Add(RelationType);

            await _context.SaveChangesAsync();

            return default;
        }

        public async Task<IActionResult> DeleteRelationType(int id)
        {
            var RelationType = await _context.RelationType.FindAsync(id);
            if (RelationType == null)
            {
                return new NotFoundResult();
            }
            _context.RelationType.Remove(RelationType);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
        private bool RelationTypeExists(int id)
        {
            return _context.RelationType.Any(e => e.Id == id);
        }
    }
}
