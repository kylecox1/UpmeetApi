using Microsoft.AspNetCore.Mvc;
using UpmeetApi.Models;

namespace UpmeetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        // GET: api/<EventController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        //// POST api/demoEventData
        //[HttpPost]
        //public void PostDemoEventData(int quantityEvents)
        //{
        //    for (int i = 0; i < quantityEvents; i++)
        //    {
        //        using (UpmeetApiContext context = new UpmeetApiContext())
        //        {
        //            Event event = new Event();
        //            event.EventId = i;
        //            event
        //            event.EventName = "Test Event " + i.ToString();
        //            context.Users.Add(user);
        //            context.SaveChanges();
        //        }
        //    }
        //}

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
