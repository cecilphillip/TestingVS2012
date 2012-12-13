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

namespace EventsDemo.Web.Test
{
    public class EventsController_StatCode_Tests
    {
        [Fact]
        [Trait("Category","Status Codes")]
        public void GetEvents_Returns_204_NoContent_For_No_Events()
        {
            //Arrange
            var eventService = new StubIEventsService() { 
                GetEvents = () => Enumerable.Empty<Event>()
            };

            EventsController sut = new EventsController(eventService);
            
            ContextConfigure.SetupController(sut, "events");

            //acct
            HttpResponseMessage response =  sut.GetEvents();

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.NoContent);

        }


        [Fact]
        [Trait("Category", "Status Codes")]
        public void GetEvents_Returns_200_OK_For_Events()
        {
            //Arrange
            var eventService = new StubIEventsService()
            {
                GetEvents = () => EventTestData.SingleEvent
            };

            EventsController sut = new EventsController(eventService);
            ContextConfigure.SetupController(sut, "events");

            //acct
            HttpResponseMessage response = sut.GetEvents();

            //Assert
            Assert.True(response.StatusCode == HttpStatusCode.OK);

        }
    }
}
