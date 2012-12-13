using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EventsDemo.Fakes;
using EventsDemo.Models;
using Microsoft.QualityTools.Testing.Fakes;
using Xunit;

namespace EventsDemo.Web.Test
{
    public class EventsController_Response_Format_Tests
    {
        [Fact]
        [Trait("Category", "Response Format")]
        public async void GetEvents_Returns_JSON_Format()
        {
            //Arrange
            var server = ContextConfigure.ConfigureServer();
            var client = new HttpClient(server);
            var request = ContextConfigure.createRequest("/events/list", "application/json", HttpMethod.Get);

            //Act
            using (ShimsContext.Create())
            {
                ShimEventsService.AllInstances.GetEvents = (self) => EventTestData.MultipleEvents;
                HttpResponseMessage response = await client.SendAsync(request);                
                
                //Assert
                Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);                
            }
        }
    }
}