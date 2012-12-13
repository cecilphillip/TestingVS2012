using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EventsDemo.Data;
using EventsDemo.Models;

namespace EventsDemo.Migrations
{    
    internal sealed class Configuration : DbMigrationsConfiguration<EventsDemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }       
    }
}
