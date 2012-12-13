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
        private IEventsService eventService;

        //public EventsController()
        //{
        //    this.repo = new EventRepository();
        //}

        public EventsController(IEventsService repo)
        {
            this.eventService = repo;
        }

        [ActionName("list")]
        public HttpResponseMessage GetEvents()
        {
            var results = eventService.GetEvents();
            if (results.Any())
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, results);
            }
            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [ActionName("byid")]
        public HttpResponseMessage GetEventByID(int eventID)
        {
            var @event = this.eventService.GetEventByID(eventID);
            if (@event != null)
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, @event);
            }
            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [ActionName("past")]
        public HttpResponseMessage GetPastEvents()
        {
            var results = eventService.GetPastEvents();
            if (results.Any())
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, results);
            }
            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [ActionName("upcoming")]
        public HttpResponseMessage GetUpcomingEvents()
        {
            var results = eventService.GetUpcomingEvents();
            if (results.Any())
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, results);
            }
            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [ActionName("search")]
        [HttpGet]
        public HttpResponseMessage SearchEventTitle(string searchTerm) {
            var results = eventService.SearchEvent(searchTerm);
            if (results.Any())
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, results);
            }
            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}