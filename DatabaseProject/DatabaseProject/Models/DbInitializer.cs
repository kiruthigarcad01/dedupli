using DatabaseProject.Data;
using DatabaseProject.Models;
using System.Linq;

namespace DatabaseProject
{
    public static class DbInitializer
    {
        public static void Initialize(DatabaseProjectContext context)
        {
            // Look for any existing records in the Person table
            if (context.DataDeduplication.Any())
            {
                return;   // Data already seeded, so exit
            }

            // Seed sample data for the Person table
            var persons = new DataDeduplication[]
            {
                new DataDeduplication { Name = "John Doe", Email = "john@example.com" },
                new DataDeduplication { Name = "Jane Smith", Email = "jane@example.com" },
                new DataDeduplication { Name = "Bob Johnson", Email = "bob@example.com" },
                // Add more sample data as needed
            };

            context.DataDeduplication.AddRange(persons);
            context.SaveChanges();
        }
    }
}