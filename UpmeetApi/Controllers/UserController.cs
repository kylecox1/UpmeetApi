using Microsoft.AspNetCore.Mvc;
using UpmeetApi.Models;

namespace UpmeetApi.Controllers
{
    public class UserResults
    {
        public IEnumerable<User> results { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public UserResults GetAllUsers()
        {
            List<User> userCollection = new List<User>();
            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                userCollection = context.Users.ToList();
            }
            UserResults result = new UserResults();
            result.results = userCollection;
            return result;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User GetUserById(int id)
        {
            User result = null;
            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                result = context.Users.Where(x => x.UserId == id).First();
            }
            return result;
        }

        // POST api/<UserController>
        [HttpPost]
        public void AddUser(User user)
        {
            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void DeleteUserById(int id)
        {
            User result = null;
            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                result = context.Users.Where(x => x.UserId == id).First();
                context.Users.Remove(result);
                context.SaveChanges();
            }
        }
    }
}
