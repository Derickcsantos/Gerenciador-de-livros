using LibraryManager.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
