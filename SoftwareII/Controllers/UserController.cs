namespace SoftwareII.Controllers
{
    public class UserController
    {
        [ApiController]
        [Route("[controller]")]
        public class UserController: ControllerBase
        {
            private readonly DatabaseContext _context;
            public UserController(DataBaseContext context){
                _context = context;
            }

            public async  Task<ActionResult<User>> getUser(long id)
            {
                var user = await _context.Users.FindAsync(id);
                if(user == null){
                    return NotFound();
                }
                return user;
            }


            [HttpPost("register")]
            
            public async Task<ActionResult<User>> register(User user){
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return CreatedAtAction("getUser", new {id = user.id}, user);
            }
            [HttpPost("login")]
            public async Task<ActionResult<User>> login(AunthInfo info){
                
                var users = await _context
                var usersInfo = users.Value;
                User finalUser = null;
                foreach (var user in usersInfo)
                {
                    if(user.email == info.email && user.password == info.password){
                        finalUser = user;
                    }
                }
                if(finalUser == null){
                    return NotFound();
                }else{
                    return finalUser;
                }
            }
        }
    }
}