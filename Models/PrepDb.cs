using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ColourAPI.Models
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var servicesScope = app.ApplicationServices.CreateScope())
            {
                SeedData(servicesScope.ServiceProvider.GetService<ColourContext>());            
            }
            
        }
        public static void SeedData(ColourContext context)
        {
           System.Console.WriteLine("Applying migrations..."); 
           context.Database.Migrate();
           if(!context.Colours.Any())
               {
                  System.Console.WriteLine("Adding data - seeding..."); 
                  context.Colours.AddRange(
                   new Colour() {ColourName = "Red"},
                   new Colour() {ColourName = "Orange"},
                   new Colour() {ColourName = "Yellow"},
                   new Colour() {ColourName = "Green"},
                   new Colour() {ColourName = "LightBlue"},
                   new Colour() {ColourName = "Blue"},
                   new Colour() {ColourName = "Purple"});
                  context.SaveChanges();
               }
           else
               {
                 System.Console.WriteLine("Already have data - not seeding."); 

               }
        }
    }
}