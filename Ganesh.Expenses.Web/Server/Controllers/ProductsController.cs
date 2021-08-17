using Ganesh.Expenses.Web.Server.Data;
using Ganesh.Expenses.Web.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Ganesh.Expenses.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly GaneshExpensesWebServerContext _context;

        public ProductsController(GaneshExpensesWebServerContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.Include(p => p.Category)
                .Include(p => p.Unit).ToListAsync();
            //return await _context.Product.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var Product = await _context.Product.Where(p => p.Id == id).Include(p => p.Category)
                .Include(p => p.Unit).FirstOrDefaultAsync();
            //var Product = await _context.Product.FindAsync(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product Product)
        {
            if (id != Product.Id)
            {
                return BadRequest();
            }
            Product.CategoryId = Product.Category.Id;
            Product.UnitId = Product.Unit.Id;

            _context.Entry(Product).State = EntityState.Modified;

            try
            {
                int count = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (DbUpdateException ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product Product)
        {
            if (Product.Unit != null)
            {
                Product.UnitId = Product.Unit.Id;
            }
            if(Product.Category != null)
            {
                Product.CategoryId = Product.Category.Id;
            }
            Product.Category = null;
            Product.Unit = null;
            _context.Product.Add(Product);

            try
            {
                int changes = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex) 
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                System.Console.WriteLine(ex.Message);

            }
            return CreatedAtAction("GetProduct", new { id = Product.Id }, Product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var Product = await _context.Product.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(Product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
