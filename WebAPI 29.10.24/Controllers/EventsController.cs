using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;    

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_29._10._24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        public static List<Event> eventList = new List<Event>();
//===================================================================
        [HttpGet]
        public List<Event> Get()
        {
            return eventList;
        }
//===================================================================
        [HttpPost]
        public void Post([FromBody] Event e)
        {
            int i = eventList.Count;
            e.Id = i + 1;
            eventList.Add(e);   
        }
//===================================================================
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event e)
        {
            var existingEvent= eventList.Find(ev=>ev.Id == id);
            if (existingEvent != null)
            {
              existingEvent.Title = e.Title; // דוגמה, עדכן את השדה Name
              existingEvent.Start = e.Start;
              existingEvent.End = e.End;
            }
            return;

        }
//===================================================================
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            eventList.Remove(eventList.Find(ev => ev.Id == id));
        }
    }
}
