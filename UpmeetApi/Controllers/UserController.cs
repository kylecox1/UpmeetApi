using Microsoft.AspNetCore.Mvc;
using UpmeetApi.Models;

namespace UpmeetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            List<User> userCollection = new List<User>();

            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                userCollection = context.Users.ToList();
            }
            
            return userCollection;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            User result = null;

            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                result = context.Users.Where(x => x.UserId == id).First();
            }
            
            return result;
        }

        // POST api/demoUserData


        // POST api/<UserController>
        [HttpPost]
        public void Post(User user, IFormCollection collection)
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
        public void Delete(int id)
        {
        }
    }
}
