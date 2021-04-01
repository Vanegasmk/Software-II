using Microsoft.EntityFrameworkCore;
using SoftwareII.Models;
using System.Collections.Generic;
using System.Linq;
namespace SoftwareII.Controllers
{
    public class ProjectController
    {
        [ApiController]
        [Route("[controller]")]
        public class ProjectController: ControllerBase
        {
            private readonly DatabaseContext _context;
            public ProjectController(DatabaContext context){
                _context = context;
            }

            [HttpGet("{nameFilter}")]
            public async Task<ActionResult<IEnumerable<Project>>> nameFilter(string name){
                var results = await _context.Products.Where(p => p.Name.Contains(name));
            }
            [HttpGet("{categoryFilter}")]
            public async Task<ActionResult<IEnumerable<Project>>> nameFilter(string category){
                var results = await _context.Products.Where(p => p.Category.Contains(category));
            }
        }
    }
}