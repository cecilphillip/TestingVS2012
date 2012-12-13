using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EventsDemo.Fakes;
using EventsDemo.Models;
using Xunit;
using Xunit.Extensions;

namespace EventsDemo.Web.Test
{
    public class EventsController_Response_Data_Tests
    {
        [Fact]
        [Trait("Category", "Response Data")]
        public async void GetEvents_Returns_Correct_Events()
        {
            //Arrange
            var eventService = new StubIEventsService()
            {
                GetEvents = () => EventTestData.MultipleEvents
            };

            EventsController sut = new EventsController(eventService);

            ContextConfigure.SetupController(sut, "events");

            //acct
            HttpResponseMessage response = sut.GetEvents();
            var results = await response.Content.ReadAsAsync<IEnumerable<Event>>();
            results.First().Description = results.First().Host = "";

            //Assert
            Assert.Equal(results, EventTestData.MultipleEvents);
            Assert.Equal(results.Count(), EventTestData.MultipleEvents.Count());            
        }
    }
}
