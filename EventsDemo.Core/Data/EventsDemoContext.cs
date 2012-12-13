using System.Data.Entity;
using EventsDemo.Models;

namespace EventsDemo.Data
{
    public class EventsDemoContext : DbContext
    {
        public IDbSet<Event> Events { get; set; }
    }
}