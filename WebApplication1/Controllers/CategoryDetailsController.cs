using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BayongWebAppApi.Models;

namespace BayongWebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryDetailsController : ControllerBase
    {
        private readonly BayongAppDBContext _context;

        public CategoryDetailsController(BayongAppDBContext context)
        {
            _context = context;
        }

        // GET: api/CategoryDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDetail>>> GetCategoryDetails()
        {
            return await _context.CategoryDetails.ToListAsync();
        }

        // GET: api/CategoryDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetail>> GetCategoryDetail(int id)
        {
            var categoryDetail = await _context.CategoryDetails.FindAsync(id);

            if (categoryDetail == null)
            {
                return NotFound();
            }

            return categoryDetail;
        }

        // PUT: api/CategoryDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryDetail(int id, CategoryDetail categoryDetail)
        {
            if (id != categoryDetail.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(categoryDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CategoryDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CategoryDetail>> PostCategoryDetail(CategoryDetail categoryDetail)
        {
            _context.CategoryDetails.Add(categoryDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryDetail", new { id = categoryDetail.CategoryId }, categoryDetail);
        }

        // DELETE: api/CategoryDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDetail>> DeleteCategoryDetail(int id)
        {
            var categoryDetail = await _context.CategoryDetails.FindAsync(id);
            if (categoryDetail == null)
            {
                return NotFound();
            }

            _context.CategoryDetails.Remove(categoryDetail);
            await _context.SaveChangesAsync();

            return categoryDetail;
        }

        private bool CategoryDetailExists(int id)
        {
            return _context.CategoryDetails.Any(e => e.CategoryId == id);
        }
    }
}
