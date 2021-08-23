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
    public interface IFamilyGroupRepository
    {
        public Task<ActionResult<IEnumerable<FamilyGroup>>> GetFamilyGroup();
        public Task<ActionResult<FamilyGroup>> GetFamilyGroup(int id);
        public Task<IActionResult> PutFamilyGroup(int id, FamilyGroup FamilyGroup);
        public Task<ActionResult<FamilyGroup>> PostFamilyGroup(FamilyGroup FamilyGroup);
        public Task<IActionResult> DeleteFamilyGroup(int id);

    }
    public class FamilyGroupRepository : IFamilyGroupRepository
    {
        private readonly GaneshExpensesWebServerContext _context;

        public FamilyGroupRepository(GaneshExpensesWebServerContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<FamilyGroup>>> GetFamilyGroup()
        {
            return await _context.FamilyGroup.ToListAsync();
        }

        public async Task<ActionResult<FamilyGroup>> GetFamilyGroup(int id)
        {
            return await _context.FamilyGroup.FindAsync(id);
        }

        public async Task<IActionResult> PutFamilyGroup(int id, FamilyGroup FamilyGroup)
        {
            _context.Entry(FamilyGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilyGroupExists(id))
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

        public async Task<ActionResult<FamilyGroup>> PostFamilyGroup(FamilyGroup FamilyGroup)
        {
            _context.FamilyGroup.Add(FamilyGroup);

            await _context.SaveChangesAsync();

            return default;
        }

        public async Task<IActionResult> DeleteFamilyGroup(int id)
        {
            var FamilyGroup = await _context.FamilyGroup.FindAsync(id);
            if (FamilyGroup == null)
            {
                return new NotFoundResult();
            }
            _context.FamilyGroup.Remove(FamilyGroup);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
        private bool FamilyGroupExists(int id)
        {
            return _context.FamilyGroup.Any(e => e.Id == id);
        }
    }
}

