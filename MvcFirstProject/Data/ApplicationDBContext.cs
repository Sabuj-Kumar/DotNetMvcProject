using Microsoft.EntityFrameworkCore;
using MvcFirstProject.Models;

namespace MvcFirstProject.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }
        public DbSet<Category> categories { get; set; }

    }

}
