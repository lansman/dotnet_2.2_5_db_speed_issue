using Microsoft.EntityFrameworkCore;

namespace Dotnet2._2AspnetSimple
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
        
        // insert your tables
    }
}