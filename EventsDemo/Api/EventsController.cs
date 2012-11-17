using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventsDemo.Data;
using EventsDemo.Models;

namespace EventsDemo
{
    public class EventsController : ApiController
    {
        private IRepository<Event> repo;

        public EventsController()
        {
            this.repo = new EventRepository();
        }

        public EventsController(IRepository<Event> repo)
        {
            this.repo = repo;
        }

        [ActionName("list")]
        public HttpResponseMessage GetEvents()
        {
            var results = repo.All();
            if (results.Any())
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, results);
            }
            return this.Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [ActionName("byid")]
        public HttpResponseMessage GetEventByID(int eventID)
        {
            var @event = this.repo.FindSingle(e => e.ID == eventID);
            if (@event != null)
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, @event);
            }
            return this.Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [ActionName("past")]
        public HttpResponseMessage GetPastEvents()
        {
            var results = repo.Find(e => e.StartDateTime < DateTime.Now);
            if (results.Any())
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, results);
            }
            return this.Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [ActionName("upcoming")]
        public HttpResponseMessage GetUpcomingEvents()
        {
            var results = repo.Find(e => e.StartDateTime < DateTime.Now);
            if (results.Any())
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, results);
            }
            return this.Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [ActionName("search")]
        public HttpResponseMessage SearchEventTitle(string searchTerm) {
            var results = repo.Find(e => e.Title.Contains(searchTerm) || e.Description.Contains(searchTerm);
            if (results.Any())
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, results);
            }
            return this.Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}