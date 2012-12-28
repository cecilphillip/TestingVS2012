using System.Collections.Generic;
using EventsDemo.Models;

namespace EventsDemo
{
    public interface IEventsService
    {
        IEnumerable<Event> GetEvents();
        IEnumerable<Event> GetPastEvents();
        IEnumerable<Event> GetUpcomingEvents();
        IEnumerable<Event> SearchEvent(string searchTerm);
        Event GetEventByID(int eventID);
    }
}