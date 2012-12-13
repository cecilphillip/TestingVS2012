using System;
using System.Data.Entity;
using EventsDemo.Data;
using EventsDemo.Models;

namespace EventsDemo
{
    public class EventsDemoSeedInitializer : CreateDatabaseIfNotExists<EventsDemoContext>
    {
        protected override void Seed(EventsDemoContext context)
        {
            context.Events.Add(new Event()
            {
                Title = "Introducing MEF: the Managed Extensiblility Framework",
                Host = "Sam Abraham",
                Description = "The Managed Extensibility Framework (MEF) is a composition layer for .NET that improves the flexibility, maintainability and testability of large applications. Join us in this code-centric talk as we progressively introduce MEF and highlight how leveraging concepts including IoC Containers, Dependency Injection, Composition, Attribute Annotation and Inheritance can support development efforts in an agile environment.",
                Address = "1430 Ponce De Leon Blvd, Coral Gables, FL 33134 ",
                StartDateTime = new DateTime(2012, 7, 19)
            });

            context.Events.Add(new Event()
            {
                Title = "Entity Framework - Code First and Migrations",
                Host = "Rich Rump",
                Description = "Traditionally, Entity Framework has used a designer and XML files to define the conceptual and storage models. Now with Entity Framework Code First we can ditch the XML files and define the data model directly in code. This session will give an overview of all of the awesomeness that is Code First including Data Annotations, Fluent API, DbContext and the new Migrations feature. Be prepared for a fast moving and interactive session filled with great information on how to access your data.",
                Address = "1430 Ponce De Leon Blvd, Coral Gables, FL 33134 ",
                StartDateTime = new DateTime(2012, 6, 21)
            });


            context.Events.Add(new Event()
            {
                Title = "Introduction to PowerPivot",
                Host = "Alberto Santaballa",
                Description = "PowerPivot is Microsoft's answer to bridge the gap between traditional Business Intelligence systems with high startup costs and the ad-hoc approach of spreadsheets with potential high maintenance costs. A key component of Microsoft's Managed Self Service Business Intelligence, this free add on to Excel 2010  leverages the power of traditional Microsoft data sources such as SQL Server and SharePoint plus heterogeneous outside data sources while giving users a familiar interface with a much more robust analysis platform which supports fast access to internal data containing millions of rows. DAX, a new internal language for PowerPivots allows the user to work over multiple rows of data in a way traditional Excel formulas cannot. Lean some of the features of the exciting addition to the Excel family of analysis resources.",
                Address = "1430 Ponce De Leon Blvd, Coral Gables, FL 33134 ",
                StartDateTime = new DateTime(2012, 4, 19)
            });


            context.Events.Add(new Event()
            {
                Title = "Ninja Prototyping - Building an MVP Quickly",
                Host = "Eugene Alfonso",
                Description = "In this session, Eugene will be going over several of the latest and coolest libraries available for .NET developers to use to build out prototypes of projects they'd love to build. Thinking about doing a startup, or have a great idea in your head? With these libraries you'll be able to build out a prototype, or MVP (Minimum Viable Product) quickly and effectively. In particular, the following technologies will be reviewed: AppHarbor, Git, Nancy, Simple.Data, Bootstrap.",
                Address = "1430 Ponce De Leon Blvd, Coral Gables, FL 33134 ",
                StartDateTime = new DateTime(2012, 3, 15)
            });

            context.SaveChanges();
        }
    }
}