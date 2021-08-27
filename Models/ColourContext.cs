using Microsoft.EntityFrameworkCore;

namespace ColourAPI.Models
{
    public class ColourContext: DbContext
    {
        public ColourContext(DbContextOptions<ColourContext> options)
        :base(options)
        {
            
        }

        public DbSet<Colour> Colours { get; set; }
        
    }
}