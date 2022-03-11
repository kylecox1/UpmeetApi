using Microsoft.AspNetCore.Mvc;
using UpmeetApi.Models;

namespace UpmeetApi.Controllers
{
    public class Results
    {
        public IEnumerable<Event> results { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        // GET: api/<EventController>
        [HttpGet]
        public Results GetAllEvents()
        {
            List<Event> eventCollection = new List<Event>();
            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                eventCollection = context.Events.ToList();
            }
            Results result = new Results();
            result.results = eventCollection;
            return result;
        }
        
        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public Event GetEventById(int id)
        {
            Event result = null;
            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                result = context.Events.Where(x => x.EventId == id).First();
            }
            return result;
        }

        // POST api/<EventController>
        [HttpPost]
        public void AddEvent(Event addedEvent)
        {
            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                context.Events.Add(addedEvent);
                context.SaveChanges();
            }
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void DeleteByEventId(int id)
        {
            Event result = null;
            using (UpmeetApiContext context = new UpmeetApiContext())
            {
                result = context.Events.Where(x => x.EventId == id).First();
                context.Events.Remove(result);
                context.SaveChanges();
            }
        }       
    }
}
