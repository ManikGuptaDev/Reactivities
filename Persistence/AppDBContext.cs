using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public required DbSet<Activity> Activities { get; set; }

    
    }
}
