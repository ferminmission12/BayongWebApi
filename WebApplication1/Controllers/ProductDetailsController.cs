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
    public class ProductDetailsController : ControllerBase
    {
        private readonly BayongAppDBContext _context;

        public ProductDetailsController(BayongAppDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDetail>>> GetProductDetails()
        {
            return await _context.ProductDetails.Include(p => p.CategoryDetails).ToListAsync();
        }

        // GET: api/ProductDetails/5

        [HttpGet("byProductID/{id}")]
        public async Task<ActionResult<ProductDetail>> GetProductDetail(int id)
        {
            var productDetail = await _context.ProductDetails.FindAsync(id);

            if (productDetail == null)
            {
                return NotFound();
            }

            return productDetail;
        }
        // GET: api/ProductDetails/5
        [HttpGet("byCategory/{category}")]
        public async Task<ActionResult<IEnumerable<ProductDetail>>> GetProductDetailbyCategory(string category)
        {
            return await _context.ProductDetails.Include(p => p.CategoryDetails).Where(p => p.CategoryDetails.Name.ToLower().Contains(category)).ToListAsync();
        }

        // PUT: api/ProductDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDetail(int id, ProductDetail productDetail)
        {
            if (id != productDetail.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(productDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDetailExists(id))
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

        // POST: api/ProductDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductDetail>> PostProductDetail(ProductDetail productDetail)
        {
            _context.ProductDetails.Add(productDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDetail", new { id = productDetail.ProductId }, productDetail);
        }

        // DELETE: api/ProductDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDetail>> DeleteProductDetail(int id)
        {
            var productDetail = await _context.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }

            _context.ProductDetails.Remove(productDetail);
            await _context.SaveChangesAsync();

            return productDetail;
        }

        private bool ProductDetailExists(int id)
        {
            return _context.ProductDetails.Any(e => e.ProductId == id);
        }
    }
}
