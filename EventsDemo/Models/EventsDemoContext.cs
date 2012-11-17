using System.Data.Entity;

namespace EventsDemo.Models
{
    public class EventsDemoContext : DbContext
    {
        public IDbSet<Event> Events { get; set; }
    }
}