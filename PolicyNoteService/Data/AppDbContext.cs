using Microsoft.EntityFrameworkCore;
using PolicyNoteService.Models;
namespace PolicyNoteService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PolicyNote> PolicyNotes => Set<PolicyNote>();
    }
}
