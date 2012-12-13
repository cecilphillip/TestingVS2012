using System;
using System.Collections.Generic;
using EventsDemo.Models;

namespace EventsDemo.Web.Test
{
    public static class EventTestData
    {
        public static List<Event> SingleEvent = new List<Event>()
        {
            new Event()
            {
                Title = "MEF",
                Host = "Sam",
                Description = "Description",
                Address = "Coral Gables, FL",
                StartDateTime = new DateTime(2012, 7, 19)
            }
        };

        public static List<Event> MultipleEvents = new List<Event>()
        {
            new Event()
            {
                Title = "Event 1",
                Host = "Host 1",
                Description = "Description",
                Address = "Coral Gables, FL",
                StartDateTime = new DateTime(2012, 12, 7)
            },
            new Event()
            {
                Title = "Event 2",
                Host = "Host 2",
                Description = "Description",
                Address = "Fort Lauderdale, FL",
                StartDateTime = new DateTime(2012, 12, 7)
            },
            new Event()
            {
                Title = "Event 3",
                Host = "Host 3",
                Description = "Description",
                Address = "Miami, FL",
                StartDateTime = new DateTime(2012, 12, 13)
            },
            new Event()
            {
                Title = "Event 4",
                Host = "Host 4",
                Description = "Description",
                Address = "Tampa Bay, FL",
                StartDateTime = new DateTime(2012, 12, 13)
            },
            new Event()
            {
                Title = "Event 5",
                Host = "Host 5",
                Description = "Description",
                Address = "Palm Beach, FL",
                StartDateTime = new DateTime(2012, 12, 30)
            }
        };
    }
}
