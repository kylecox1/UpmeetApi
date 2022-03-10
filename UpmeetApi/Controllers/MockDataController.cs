using Microsoft.AspNetCore.Mvc;
using UpmeetApi.Models;

namespace UpmeetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockDataController : ControllerBase
    {
        // GET: api/<MockDataController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MockDataController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MockDataController>
        [HttpPost]
        public void PostMockData(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                using (UpmeetApiContext context = new UpmeetApiContext())
                {
                    User user = new User();
                    user.UserName = "Test User " + i.ToString();
                    context.Users.Add(user);

                    Event mockEvent = new Event();
                    mockEvent.EventTime = DateTime.Now;
                    mockEvent.EventName = "Test Event " + i.ToString();
                    mockEvent.Location = "Test Location";
                    mockEvent.EventMinutes = 60;
                    mockEvent.Description = "Test Description";
                    context.Events.Add(mockEvent);

                    context.SaveChanges();
                }
            }
        }

        // PUT api/<MockDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MockDataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
