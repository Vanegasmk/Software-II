using Microsoft.AspNetCore.Mvc;
using SoftwareII.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
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

        [HttpGet("{name}")]
        public  IEnumerable<Product> NameFilter(string name)
        {
            var results = _context.Products.Where(p => p.Name.Contains(name));
            
            return results;
        }

        [HttpGet("{category}")]
        public IEnumerable<Product> CategoryFilter(string category)
        {
            var results = _context.Products.Where(p => p.Category.Contains(category));

            return results;
        }
    }

}