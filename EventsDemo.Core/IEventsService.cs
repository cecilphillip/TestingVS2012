using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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