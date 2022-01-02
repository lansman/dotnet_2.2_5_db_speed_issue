using Microsoft.EntityFrameworkCore;

namespace Dotnet5AspnetSimple
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