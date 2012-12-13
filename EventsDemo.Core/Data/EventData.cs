using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EventsDemo.Data
{
    public static class EventData
    {
        public static void Initialize()
        {
            Database.SetInitializer(new EventsDemoSeedInitializer());
        }
    }
}
