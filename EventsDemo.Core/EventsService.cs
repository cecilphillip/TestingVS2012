using System;
using System.Linq;
using System.Collections.Generic;
using EventsDemo.Caching;
using EventsDemo.Data;
using EventsDemo.Models;

namespace EventsDemo
{
    public class EventsService : IEventsService
    {
        private IRepository<Event> eventsRepo;
        private ICacheService cacheService;

        public EventsService(IRepository<Event> repo, ICacheService cache)
        {
            this.eventsRepo = repo;
            this.cacheService = cache;
        }

        public IEnumerable<Event> GetEvents()
        {
            if (this.cacheService.Exists("events:all"))
            {
                return this.cacheService.Retrieve<IEnumerable<Event>>("events:all");
            }
            else
            {
                var results = this.eventsRepo.All().ToList();
                this.cacheService.Store("events:all", results);
                return results;
            }
        }

        public IEnumerable<Event> GetPastEvents()
        {
            if (this.cacheService.Exists("events:past"))
            {
                return this.cacheService.Retrieve<IEnumerable<Event>>("events:past");
            }
            else
            {
                var results = this.eventsRepo.Find(evt => evt.StartDateTime < DateTime.Now).ToList();
                this.cacheService.Store("events:past", results);
                return results;
            }
        }

        public IEnumerable<Event> GetUpcomingEvents()
        {
            if (this.cacheService.Exists("events:past"))
            {
                return this.cacheService.Retrieve<IEnumerable<Event>>("events:past");
            }
            else
            {
                var results = this.eventsRepo.Find(evt => evt.StartDateTime > DateTime.Now).ToList();
                this.cacheService.Store("events:past", results);
                return results;
            }
        }

        public IEnumerable<Event> SearchEvent(string searchTerm)
        {
            if (this.cacheService.Exists("events:past"))
            {
                return this.cacheService.Retrieve<IEnumerable<Event>>("events:past");
            }
            else
            {
                var results = this.eventsRepo.Find(evt => evt.Title.Contains(searchTerm) || evt.Description.Contains(searchTerm)).ToList();
                this.cacheService.Store("events:past", results);
                return results;
            }
        }

        public Event GetEventByID(int eventID)
        {
            if (this.cacheService.Exists("events:single:" + eventID))
            {
                return this.cacheService.Retrieve<Event>("events:single:" + eventID);
            }
            else
            {
                var result = this.eventsRepo.FindSingle(evt => evt.ID == eventID);
                this.cacheService.Store("events:single:" + eventID, result);
                return result;
            }
        }
    }
}