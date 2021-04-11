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
    public class UserController : ControllerBase
    {
        private readonly DataBaseContext _context;
        public UserController(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("getUser", new { id = user.Id }, user);
        }


        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(AuthInfo info)
        {

            var users = await _context.Users.ToListAsync();

            User finalUser = null;
            foreach (var user in users)
            {
                if (user.Email == info.Email && user.Password == info.Password)
                {
                    finalUser = user;
                }
            }
            if (finalUser == null)
            {
                return NotFound();
            }
            else
            {
                return finalUser;
            }
        }
    }

}