using Assessment_IzzahShazwani.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assessment_IzzahShazwani.Controllers
{
    [Route("api/UsersController")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UsersController(UserDbContext context) {
            _context = context;
        }

        //GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            var users = _context.User.ToList();
            return users;
        }

        //POST: api/Users
        [HttpPost]
        public ActionResult<Users> CreateUser(Users user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return user;
        }

        //PUT: api/Users
        [HttpPut("{id}")]
        public ActionResult<Users> UpdateUser(int id, Users updatedUser)
        {
            var user = _context.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            // Update user attributes here

            _context.SaveChanges();
            return user;
        }

        //POST: api/Users
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = _context.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
