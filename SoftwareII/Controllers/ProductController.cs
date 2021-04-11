using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SoftwareII.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SoftwareII.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public ProductController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductos()
        {
            return await _context.Products.ToListAsync();
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducto(long id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return product;
        }


        [HttpGet("{category}/filter")]
        public IEnumerable<Product> CategoryFilter(string category)
        {
            var results = _context.Products.Where(p => p.Category.Contains(category));

            return results;
        }
    }

}