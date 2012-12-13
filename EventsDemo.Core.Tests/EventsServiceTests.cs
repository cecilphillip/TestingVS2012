using System;
using System.Collections.Generic;
using System.Fakes;
using System.Linq;
using EventsDemo.Caching;
using EventsDemo.Caching.Fakes;
using EventsDemo.Data;
using EventsDemo.Data.Fakes;
using EventsDemo.Models;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventsDemo.Core.Tests
{
    [TestClass]
    public class EventsServiceTests
    {
        [TestMethod]
        [TestCategory("Cache")]
        public void GetEvents_Caches_Results()
        {
            //Arrange
            var eventsRepo = new StubIRepository<Event>()
            {
                All = () => EventTestData.SingleEvent.AsQueryable()
            };
            var cacheService = new DefaultMemoryCache();
            var eventService = new EventsService(eventsRepo, cacheService);

            //Act
            eventService.GetEvents();
            //Assert
            Assert.IsTrue(cacheService.Exists("events:all"));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void GetEvents_Returns_Results_From_Cache()
        {
            //arrange
            var cacheService = new StubICacheService()
            {
                ExistsString = (key) => true
            };

            cacheService.RetrieveOf1String<IEnumerable<Event>>(
                (key) => EventTestData.SingleEvent.AsEnumerable()
            );
            var eventsRepo = new StubIRepository<Event>();
            var eventService = new EventsService(eventsRepo, cacheService);

            //Act
            var results = eventService.GetEvents();
            Assert.AreEqual(results.Count(), EventTestData.SingleEvent.Count);
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void GetEvents_Does_Not_Call_Repository_All_When_Cache_Available()
        {
            //arrange
            var cacheService = new DefaultMemoryCache();
            cacheService.Store("events:all", EventTestData.SingleEvent.AsQueryable());
            bool allWasCalled = false;
            var eventsRepo = new StubIRepository<Event>()
            {
                All = () =>
                {
                    allWasCalled = true;
                    return Enumerable.Empty<Event>().AsQueryable();
                }
            };
            var eventService = new EventsService(eventsRepo, cacheService);

            //Act
            var results = eventService.GetEvents();

            //Assert
            Assert.IsFalse(allWasCalled);
        }

        [TestMethod]
        public void GetUpcomingEvents_Only_Returns_Future_Events()
        {
            //Arrange
            var cacheService = new StubICacheService();
            var eventsRepo = new StubIRepository<Event>() { 
                FindExpressionOfFuncOfT0Boolean = (func) => EventTestData.MultipleEvents.AsQueryable().Where(func)
            };
            var eventService = new EventsService(eventsRepo, cacheService);

            //act
            using (ShimsContext.Create())
            {
                //Set current DateTime.Now to 12/12/12
                ShimDateTime.NowGet = () => new DateTime(2012, 12, 12);
                var results = eventService.GetUpcomingEvents();

                //assert
                Assert.AreEqual(3, results.Count());
            }
        }

        [TestMethod]
        public void GetPastEvents_Only_Returns_Previous_Events()
        {
            //Arrange
            var cacheService = new StubICacheService();
            var eventsRepo = new StubIRepository<Event>()
            {
                FindExpressionOfFuncOfT0Boolean = (func) => EventTestData.MultipleEvents.AsQueryable().Where(func)
            };
            var eventService = new EventsService(eventsRepo, cacheService);

            //act
            using (ShimsContext.Create())
            {
                //Set current DateTime.Now to 12/12/12
                ShimDateTime.NowGet = () => new DateTime(2012, 12, 12);
                var results = eventService.GetPastEvents();

                //assert
                Assert.AreEqual(2, results.Count());
                
            }
        }

    }
}